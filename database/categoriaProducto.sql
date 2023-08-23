
USE database-stivenlovera;  
DROP PROCEDURE  IF EXISTS  SP_categoria_producto_insert;
CREATE PROCEDURE SP_categoria_producto_insert   
    @nombre nvarchar(100),  
    @usuario_registro nvarchar(50),
    @fecha_registro datetime,   
    @estado_registro int    
AS   
insert into 
   "CATEGORIA_PRODUCTO" (
    "NOMBRE", 
    "USUARIO_REGISTRO", 
    "FECHA_REGISTRO", 
    "ESTADO_REGISTRO"
  )
values
  (
    @nombre, 
    @usuario_registro, 
    @fecha_registro,
    @estado_registro
  );
EXEC SP_categoria_producto_insert 
    @nombre = 'ali stiven lovera huarachi', 
    @usuario_registro = 'stiven lovera', 
    @fecha_registro = '20230815', 
    @estado_registro = 1;

DROP PROCEDURE  IF EXISTS  SP_categoria_producto_update;
CREATE PROCEDURE SP_categoria_producto_update 
    @id int, 
    @nombre nvarchar(100),   
    @usuario_registro nvarchar(50),
    @fecha_registro datetime,   
    @estado_registro int   
AS   
    update 
        "CATEGORIA_PRODUCTO" 
    set 
        NOMBRE =  @nombre,
        USUARIO_REGISTRO = @usuario_registro,
        FECHA_REGISTRO = @fecha_registro,
        ESTADO_REGISTRO = @estado_registro
    where 
    ID = @id;
EXEC SP_categoria_producto_update 
    @nombre = 'stiven',
    @usuario_registro = 'stiven lovera', 
    @fecha_registro = '20230815', 
    @estado_registro = 1,
    @id = 1;
DROP PROCEDURE  IF EXISTS  SP_categoria_producto_delete;
CREATE PROCEDURE SP_categoria_producto_delete 
    @id int
AS   
 delete from 
    "CATEGORIA_PRODUCTO" 
    where 
    "ID" = @id;


DROP PROCEDURE  IF EXISTS  SP_categoria_producto_by_id;
CREATE PROCEDURE SP_categoria_producto_by_id 
    @id int
AS   
 SELECT
    "ID",
    "NOMBRE",
    "PASSWORD",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "CATEGORIA_PRODUCTO" WHERE "ID"=@id;

EXEC SP_categoria_producto_by_id @id=1;

DROP PROCEDURE  IF EXISTS  SP_categoria_producto;
CREATE PROCEDURE SP_categoria_producto 
AS   
 SELECT
    "ID",
    "NOMBRE",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "CATEGORIA_PRODUCTO"
 WHERE "ID"=1;
GO
EXEC SP_categoria_producto;