using Database.Models;
using PumpService.Models.Request;

namespace PumpService.Interface
{
    public interface IPumpService
    {
        /// <summary>
        /// Возвращает все насосы
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pump>> GetPumps();
        /// <summary>
        /// Добавляет новый насос
        /// </summary>
        /// <param name="pump"></param>
        /// <returns></returns>
        Task AddPump(PumpRQ pump);
        /// <summary>
        /// Обновляет данные о насосе
        /// </summary>
        /// <param name="pump"></param>
        /// <returns></returns>
        Task UpdatePump(PumpRQ pump);
        /// <summary>
        /// Удаляет насос
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteById(int id);
        /// <summary>
        /// Возвращает все моторы
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Motor>> GetMotors();
        /// <summary>
        /// Возвращает все материалы
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Material>> GetMaterials();
        /// <summary>
        /// Добавляет мотор
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>
        Task AddMotor(MotorRQ motor);
    }
}
