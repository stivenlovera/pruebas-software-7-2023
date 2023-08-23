
USE database-stivenlovera;  
DROP PROCEDURE  IF EXISTS  SP_carrito_compra_insert;
CREATE PROCEDURE SP_carrito_compra_insert   
    @fecha datetime,  
    @id_usuario int
AS   
insert into 
   "CARRITO_COMPRA" (
    "FECHA",
    "ID_USUARIO"
  )
values
  (
    @fecha, 
    @id_usuario
  );
EXEC SP_carrito_compra_insert 
    @fecha = '20230815', 
    @id_usuario = 1;

DROP PROCEDURE  IF EXISTS  SP_carrito_compra_update;
CREATE PROCEDURE SP_carrito_compra_update 
    @fecha datetime,  
    @id_usuario int,
    @id int
AS   
    update 
        "CARRITO_COMPRA" 
    set 
        FECHA = @fecha, 
        ID_USUARIO = @id_usuario
    where 
    ID = @id;
EXEC SP_carrito_compra_update 
    @fecha = '20230815', 
    @id_usuario = 1,
    @id = 1;
DROP PROCEDURE  IF EXISTS  SP_carrito_compra_delete;
CREATE PROCEDURE SP_carrito_compra_delete 
    @id int
AS   
 delete from 
    "CARRITO_COMPRA" 
    where 
    "ID" = @id;


DROP PROCEDURE  IF EXISTS  SP_carrito_compra_by_id;
CREATE PROCEDURE SP_carrito_compra_by_id 
    @id int
AS   
 SELECT
    "ID",
    "FECHA",
    "ID_USUARIO",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "CARRITO_COMPRA" WHERE "ID"=@id;

EXEC SP_carrito_compra_by_id @id=1;

DROP PROCEDURE  IF EXISTS  SP_carrito_compra;
CREATE PROCEDURE SP_carrito_compra 
AS   
 SELECT
    "ID",
    "FECHA",
    "ID_USUARIO",
    "USUARIO_REGISTRO",
    "FECHA_REGISTRO",
    "ESTADO_REGISTRO"
FROM "CARRITO_COMPRA"
GO
EXEC SP_carrito_compra;