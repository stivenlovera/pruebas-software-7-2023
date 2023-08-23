
USE database-stivenlovera;  
DROP PROCEDURE  IF EXISTS  SP_producto_insert;
CREATE PROCEDURE SP_producto_insert   
    @nombre nvarchar(100),
    @id_categoria nvarchar(100),   
    @usuario_registro nvarchar(50),
    @fecha_registro datetime,   
    @estado_registro int    
AS   
insert into 
  "PRODUCTO" (
    "NOMBRE", 
    "ID_CATEGORIA", 
    "USUARIO_REGISTRO", 
    "FECHA_REGISTRO", 
    "ESTADO_REGISTRO"
  )
values
  (
    @nombre, 
    @id_categoria, 
    @usuario_registro, 
    @fecha_registro,
    @estado_registro
  );
EXEC SP_producto_insert 
    @nombre = 'stiven', 
    @id_categoria = 'ali stiven lovera huarachi', 
    @usuario_registro = '12345', 
    @fecha_registro = 'stiven lovera', 
    @estado_registro = '20230815'

DROP PROCEDURE  IF EXISTS  SP_producto_update;
CREATE PROCEDURE SP_producto_update 
    @id int, 
    @nombre nvarchar(100),
    @id_categoria nvarchar(100),   
    @usuario_registro nvarchar(50),
    @fecha_registro datetime,   
    @estado_registro int   
AS   
    update 
        "PRODUCTO" 
    set 
    NOMBRE =  @nombre,
    ID_CATEGORIA = @id_categoria,
    USUARIO_REGISTRO = @usuario_registro,
    FECHA_REGISTRO = @fecha_registro,
    ESTADO_REGISTRO = @estado_registro
    where 
    ID = @id;
EXEC SP_producto_update 
    @nombre = 'stiven', 
    @id_categoria = 'ali stiven lovera huarachi',
    @usuario_registro = 'stiven lovera', 
    @fecha_registro = '20230815', 
    @estado_registro = 1,
    @id = 1;
DROP PROCEDURE  IF EXISTS  SP_producto_delete;
CREATE PROCEDURE SP_producto_delete 
    @id int
AS   
 delete from 
    "PRODUCTO" 
    where 
    "ID" = @id;


DROP PROCEDURE  IF EXISTS  SP_producto_by_id;
CREATE PROCEDURE SP_producto_by_id 
    @id int
AS   
 SELECT
    "ID",
    "NOMBRE",
    "ID_CATEGORIA",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "PRODUCTO"
 WHERE "ID"=@id;

EXEC SP_producto_by_id @id=1;

DROP PROCEDURE  IF EXISTS  SP_producto;
CREATE PROCEDURE SP_producto 
AS   
 SELECT
    "ID",
    "NOMBRE",
    "ID_CATEGORIA",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "PRODUCTO"
GO
EXEC SP_producto;