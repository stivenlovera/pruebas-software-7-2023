
USE database-stivenlovera;  
DROP PROCEDURE  IF EXISTS  SP_detalle_carrito_insert;
CREATE PROCEDURE SP_detalle_carrito_insert   
    @cantidad int,  
    @id_producto int,
    @id_carrito_compra int
AS   
insert into 
   "DETALLE_CARRITO" (
    "CANTIDAD",
    "ID_PRODUCTO",
    "ID_CARRITO_COMPRA"
  )
values
  (
    @cantidad,
    @id_producto,
    @id_carrito_compra
  );
EXEC SP_detalle_carrito_insert 
    @cantidad = 23, 
    @id_producto = 1,
    @id_carrito_compra=1;

DROP PROCEDURE  IF EXISTS  SP_detalle_carrito_update;
CREATE PROCEDURE SP_detalle_carrito_update 
    @cantidad int,  
    @id_producto int,
    @id_carrito_compra int,
    @id int
AS   
    update 
        "DETALLE_CARRITO" 
    set 
        CANTIDAD = @cantidad, 
        ID_PRODUCTO =  @id_producto,
        ID_CARRITO_COMPRA =  @id_carrito_compra
    where 
    ID = @id;
EXEC SP_detalle_carrito_update 
    @cantidad = 23, 
    @id_producto = 1,
    @id_carrito_compra = 1,
    @id = 1;
DROP PROCEDURE  IF EXISTS  SP_detalle_carrito_delete;
CREATE PROCEDURE SP_detalle_carrito_delete 
    @id int
AS   
 delete from 
    "DETALLE_CARRITO" 
    where 
    "ID" = @id;


DROP PROCEDURE  IF EXISTS  SP_detalle_carrito_by_id;
CREATE PROCEDURE SP_detalle_carrito_by_id 
    @id int
AS   
 SELECT
    "ID",
    "CANTIDAD",
    "ID_PRODUCTO",
    "ID_CARRITO_COMPRA"
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "DETALLE_CARRITO" WHERE "ID"=@id;

EXEC SP_detalle_carrito_by_id @id=1;

DROP PROCEDURE  IF EXISTS  SP_detalle_carrito;
CREATE PROCEDURE SP_detalle_carrito 
AS   
 SELECT
    "ID",
    "CANTIDAD",
    "ID_PRODUCTO",
    "ID_CARRITO_COMPRA"
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "DETALLE_CARRITO"
GO
EXEC SP_detalle_carrito;