using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;
namespace backend.servicios
{
    public class CarritoCompraService
    {
        public static IEnumerable<T> GetAll<T>()
        {
            const string sql = "EXEC SP_carrito_compra";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T GetOne<T>(int id)
        {
            const string sql = "EXEC SP_carrito_compra_by_id @id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int Store(CarritoCompra carritoCompra)
        {
            const string sql = "EXEC SP_carrito_compra_insert @fecha =  @fecha, @id_usuario = @id_usuario ";

            var parameters = new DynamicParameters();
            parameters.Add("fecha", carritoCompra.Fecha, DbType.DateTime);
            parameters.Add("id_usuario", carritoCompra.UsuarioId, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Update(CarritoCompra carritoCompra,int id)
        {
            const string sql = "EXEC SP_carrito_compra_update @fecha = @fecha, @id_usuario = @id_usuario , @id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("fecha", carritoCompra.Fecha, DbType.DateTime);
            parameters.Add("id_usuario", carritoCompra.UsuarioId, DbType.Int32);
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Delete(int id)
        {
            const string sql = "EXEC SP_carrito_compra_update @id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
    }
}