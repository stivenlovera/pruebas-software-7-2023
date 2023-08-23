using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;
namespace backend.servicios
{
    public class DetalleCarritoService
    {
        public static IEnumerable<T> GetAll<T>()
        {
            const string sql = "EXEC SP_detalle_carrito";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T GetOne<T>(int id)
        {
            const string sql = "EXEC SP_detalle_carrito_by_id @id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int Store(DetalleCarrito detalleCarrito)
        {
            const string sql = "EXEC SP_detalle_carrito_insert @cantidad = @cantidad, @id_producto = @id_producto , @id_carrito_compra=@id_carrito_compra";

            var parameters = new DynamicParameters();
            parameters.Add("cantidad", detalleCarrito.Cantidad, DbType.Int32);
            parameters.Add("id_producto", detalleCarrito.ProductoId, DbType.Int32);
            parameters.Add("id_carrito_compra", detalleCarrito.CarritoCompraId, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Update(DetalleCarrito detalleCarrito, int id)
        {
            const string sql = "EXEC SP_detalle_carrito_update @cantidad = @cantidad , @id_producto = id_producto,@id_carrito_compra = @id_carrito_compra ,@id = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("cantidad", detalleCarrito.Cantidad, DbType.Int32);
            parameters.Add("id_producto", detalleCarrito.ProductoId, DbType.Int32);
            parameters.Add("id_carrito_compra", detalleCarrito.CarritoCompraId, DbType.Int32);
            parameters.Add("id", id, DbType.Int32);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Delete(int id)
        {
            const string sql = "EXEC SP_detalle_carrito_by_id @id = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
    }
}