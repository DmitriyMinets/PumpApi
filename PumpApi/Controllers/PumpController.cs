using Microsoft.AspNetCore.Mvc;
using PumpService.Interface;
using PumpService.Models.Request;

namespace PumpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpController : ControllerBase
    {
        private readonly IPumpService _pumpService;
        private IWebHostEnvironment _webHostEnvironment;

        public PumpController(IPumpService pumpService, IWebHostEnvironment webHostEnvironment)
        {
            _pumpService = pumpService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetPumps()
        {
            return Ok(await _pumpService.GetPumps());
        }

        [HttpPost("AddPump")]
        public async Task<IActionResult> AddPump([FromForm] PumpRQ pump)
        {
            pump.Valid();
            if (pump.Image != null)
            {
                pump.ImageUrl = SaveImageAndCreateUrl(pump.Image);
            }
            await _pumpService.AddPump(pump);
            return Ok();
        }

        [HttpPut("UpdatePump")]
        public async Task<IActionResult> UpdatePump([FromForm] PumpRQ pump)
        {
            pump.Valid();
            if (pump.Image != null)
            {
                pump.ImageUrl = CreateImageUrl(pump.Image, pump.ImageUrl);
            }
            await _pumpService.UpdatePump(pump);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleptePump(int id)
        {
            var pathToImage = await _pumpService.DeleteById(id);
            if (pathToImage != null)
            {
                RemoveImage(pathToImage);
            }
            return Ok();
        }

        [HttpGet("GetMotors")]
        public async Task<IActionResult> GetMotors()
        {
            return Ok(await _pumpService.GetMotors());
        }

        [HttpGet("GetMaterials")]
        public async Task<IActionResult> GetMaterials()
        {
            return Ok(await _pumpService.GetMaterials());
        }

        [HttpPost("AddMotor")]
        public async Task<IActionResult> AddMotor(MotorRQ motor)
        {
            motor.Valid();
            await _pumpService.AddMotor(motor);
            return Ok();
        }
        [NonAction]
        private string CreateImageUrl(IFormFile image, string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                string filePathToDelete = GetImagePath(imageUrl);
                return ChangeImageAndCreateUrl(image, filePathToDelete);
            }
            else
            {
                return SaveImageAndCreateUrl(image);
            }
        }

        /// <summary>
        /// Сохраняет изображения и возвращает url для данного изображения
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [NonAction]
        private string SaveImageAndCreateUrl(IFormFile image)
        {
            var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var imagePath = Path.Combine(directoryPath, imageName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            var imageUrl = $"https://localhost:7235/Images/{imageName}";
            return imageUrl;
        }

        /// <summary>
        /// Добавляет новое изображение, удаляет старое и возвращает новый url для нового изображения
        /// </summary>
        /// <param name="newImage"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>

        [NonAction]
        private string ChangeImageAndCreateUrl(IFormFile newImage, string filePath)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(newImage.FileName);
            string imagePath = Path.Combine(directoryPath, imageName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                newImage.CopyTo(stream);
            }

            RemoveImage(filePath);
            return $"https://localhost:7235/Images/{imageName}";
        }

        /// <summary>
        /// Удаляет изображения 
        /// </summary>
        /// <param name="pathToImage"></param>
        [NonAction]
        private void RemoveImage(string pathToImage)
        {
            var pathToDelete = GetImagePath(pathToImage);
            if (System.IO.File.Exists(pathToDelete))
            {
                System.IO.File.Delete(pathToDelete);
            }
        }

        /// <summary>
        /// Получает локальный путь до изображения
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        [NonAction]
        private string GetImagePath(string imageUrl)
        {
            Uri uri = new Uri(imageUrl);
            string relativePath = uri.LocalPath;
            return Path.Combine(_webHostEnvironment.WebRootPath, relativePath.TrimStart('/'));
        }
    }
}
