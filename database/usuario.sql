
USE database-stivenlovera;  
DROP PROCEDURE  IF EXISTS  SP_usuario_insert;
CREATE PROCEDURE SP_usuario_insert   
    @user_name nvarchar(40),   
    @nombre_completo nvarchar(100),
    @password nvarchar(100),   
    @usuario_registro nvarchar(50),
    @fecha_registro datetime,   
    @estado_registro int    
AS   
insert into 
            "USUARIOS" (
              "USER_NAME", 
              "NOMBRE_COMPLETO", 
              "PASSWORD", 
              "USUARIO_REGISTRO", 
              "FECHA_REGISTRO", 
              "ESTADO_REGISTRO"
            )
          values
            (
                @user_name, 
                @nombre_completo, 
                @password, 
                @usuario_registro, 
                @fecha_registro, 
                @estado_registro
            );
EXEC SP_usuario_insert @user_name = 'stiven', @nombre_completo = 'ali stiven lovera huarachi', 
                @password = '12345', 
                @usuario_registro = 'stiven lovera', 
                @fecha_registro = '20230815', 
                @estado_registro = 1;


DROP PROCEDURE  IF EXISTS  SP_usuario_update;
CREATE PROCEDURE SP_usuario_update 
    @id int, 
    @user_name nvarchar(40),   
    @nombre_completo nvarchar(100),
    @password nvarchar(100),   
    @usuario_registro nvarchar(50),
    @fecha_registro datetime,   
    @estado_registro int    
AS   
    update 
            "USUARIOS" 
            set 
            USER_NAME =  @user_name,
            NOMBRE_COMPLETO = @nombre_completo,
            PASSWORD = @password,
            USUARIO_REGISTRO = @usuario_registro,
            FECHA_REGISTRO = @fecha_registro,
            ESTADO_REGISTRO = @estado_registro
            where 
            ID = @id;
EXEC SP_usuario_insert 
    @user_name = 'stiven', 
    @nombre_completo = 'ali stiven lovera huarachi', 
    @password = '12345', 
    @usuario_registro = 'stiven lovera', 
    @fecha_registro = '20230815', 
    @estado_registro = 1
    @id = 1;
DROP PROCEDURE  IF EXISTS  SP_usaurio_delete;
CREATE PROCEDURE SP_usaurio_delete 
    @id int
AS   
 delete from 
    "USUARIOS" 
    where 
    "ID" = @id;


DROP PROCEDURE  IF EXISTS  SP_usuario_by_id;
CREATE PROCEDURE SP_usuario_by_id 
    @id int
AS   
 SELECT
    "ID",
    "USER_NAME",
    "NOMBRE_COMPLETO",
    "PASSWORD",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "USUARIOS" WHERE "ID"=@id;

EXEC SP_usuario_by_id @id=1;

DROP PROCEDURE  IF EXISTS  SP_usuario;
CREATE PROCEDURE SP_usuario 
AS   
 SELECT
    "ID",
    "USER_NAME",
    "NOMBRE_COMPLETO",
    "PASSWORD",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "USUARIOS";
GO
EXEC SP_usuario;