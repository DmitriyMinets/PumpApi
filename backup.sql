PGDMP      ,                |            postgres    16.3    16.3                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    5    postgres    DATABASE     |   CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE postgres;
                postgres    false            	           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                   postgres    false    4872                        3079    16384 	   adminpack 	   EXTENSION     A   CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;
    DROP EXTENSION adminpack;
                   false            
           0    0    EXTENSION adminpack    COMMENT     M   COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';
                        false    2            �            1259    16423 	   Materials    TABLE     q   CREATE TABLE public."Materials" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Description" text
);
    DROP TABLE public."Materials";
       public         heap    postgres    false            �            1259    16422    Materials_Id_seq    SEQUENCE     �   ALTER TABLE public."Materials" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Materials_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    218            �            1259    16431    Motors    TABLE       CREATE TABLE public."Motors" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Power" double precision NOT NULL,
    "Current" double precision NOT NULL,
    "RatedSpeed" double precision NOT NULL,
    "Description" text,
    "Price" numeric(16,2) NOT NULL
);
    DROP TABLE public."Motors";
       public         heap    postgres    false            �            1259    16430    Motors_Id_seq    SEQUENCE     �   ALTER TABLE public."Motors" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Motors_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            �            1259    16439    Pumps    TABLE     �  CREATE TABLE public."Pumps" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "MaxPressure" double precision NOT NULL,
    "LiquidTemperature" double precision NOT NULL,
    "Weight" double precision NOT NULL,
    "MotorId" integer NOT NULL,
    "BodyMaterialId" integer NOT NULL,
    "ImpellerMaterialId" integer NOT NULL,
    "Description" text,
    "ImageUrl" text,
    "Price" numeric(16,2) NOT NULL
);
    DROP TABLE public."Pumps";
       public         heap    postgres    false            �            1259    16438    Pumps_Id_seq    SEQUENCE     �   ALTER TABLE public."Pumps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Pumps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    222            �            1259    16417    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            �          0    16423 	   Materials 
   TABLE DATA           B   COPY public."Materials" ("Id", "Name", "Description") FROM stdin;
    public          postgres    false    218   &$                  0    16431    Motors 
   TABLE DATA           j   COPY public."Motors" ("Id", "Name", "Power", "Current", "RatedSpeed", "Description", "Price") FROM stdin;
    public          postgres    false    220   �$                 0    16439    Pumps 
   TABLE DATA           �   COPY public."Pumps" ("Id", "Name", "MaxPressure", "LiquidTemperature", "Weight", "MotorId", "BodyMaterialId", "ImpellerMaterialId", "Description", "ImageUrl", "Price") FROM stdin;
    public          postgres    false    222   %       �          0    16417    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    216   �%                  0    0    Materials_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Materials_Id_seq"', 25, true);
          public          postgres    false    217                       0    0    Motors_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Motors_Id_seq"', 17, true);
          public          postgres    false    219                       0    0    Pumps_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Pumps_Id_seq"', 71, true);
          public          postgres    false    221            b           2606    16429    Materials PK_Materials 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Materials"
    ADD CONSTRAINT "PK_Materials" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Materials" DROP CONSTRAINT "PK_Materials";
       public            postgres    false    218            d           2606    16437    Motors PK_Motors 
   CONSTRAINT     T   ALTER TABLE ONLY public."Motors"
    ADD CONSTRAINT "PK_Motors" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Motors" DROP CONSTRAINT "PK_Motors";
       public            postgres    false    220            i           2606    16445    Pumps PK_Pumps 
   CONSTRAINT     R   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "PK_Pumps" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "PK_Pumps";
       public            postgres    false    222            `           2606    16421 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    216            e           1259    16461    IX_Pumps_BodyMaterialId    INDEX     Y   CREATE INDEX "IX_Pumps_BodyMaterialId" ON public."Pumps" USING btree ("BodyMaterialId");
 -   DROP INDEX public."IX_Pumps_BodyMaterialId";
       public            postgres    false    222            f           1259    16462    IX_Pumps_ImpellerMaterialId    INDEX     a   CREATE INDEX "IX_Pumps_ImpellerMaterialId" ON public."Pumps" USING btree ("ImpellerMaterialId");
 1   DROP INDEX public."IX_Pumps_ImpellerMaterialId";
       public            postgres    false    222            g           1259    16463    IX_Pumps_MotorId    INDEX     K   CREATE INDEX "IX_Pumps_MotorId" ON public."Pumps" USING btree ("MotorId");
 &   DROP INDEX public."IX_Pumps_MotorId";
       public            postgres    false    222            j           2606    16446 '   Pumps FK_Pumps_Materials_BodyMaterialId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "FK_Pumps_Materials_BodyMaterialId" FOREIGN KEY ("BodyMaterialId") REFERENCES public."Materials"("Id") ON DELETE CASCADE;
 U   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "FK_Pumps_Materials_BodyMaterialId";
       public          postgres    false    4706    218    222            k           2606    16451 +   Pumps FK_Pumps_Materials_ImpellerMaterialId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "FK_Pumps_Materials_ImpellerMaterialId" FOREIGN KEY ("ImpellerMaterialId") REFERENCES public."Materials"("Id") ON DELETE CASCADE;
 Y   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "FK_Pumps_Materials_ImpellerMaterialId";
       public          postgres    false    218    4706    222            l           2606    16456    Pumps FK_Pumps_Motors_MotorId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "FK_Pumps_Motors_MotorId" FOREIGN KEY ("MotorId") REFERENCES public."Motors"("Id") ON DELETE CASCADE;
 K   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "FK_Pumps_Motors_MotorId";
       public          postgres    false    4708    222    220            �   `   x����� �᳝�0��6��a��	�W(�ռ����yСTw庪(�r-�zU����bu�?Jni-�,Ao��ֆ.�hm����&��          n   x��λ�0���2�		�00b$
+H�(���|Z���Oז� �PG\Ύ7.��_��.E��ѐ�pu�Dj_"�O��Ҏ�+�g�M4�s��a1         �   x�����0���]��v�$^�	�L�rA�X�݈�N�8ْ�'�)�.V���:1H<�xn)��v��m����6�M-|&���TT��Ke��}�J�����й�gqIG.��_.�個#�瑓?8��.��f/��8��X>�s��'q�wν ���`      �   F   x�3202107014217�����,�L���3�3�2�H����;g$楧�%�z�&��B��qqq v��     