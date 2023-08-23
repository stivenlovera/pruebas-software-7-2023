
using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;
namespace backend.servicios
{
    public class ProductoService
    {
        public static IEnumerable<T> GetAll<T>()
        {
            const string sql = "EXEC SP_producto;";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T GetOne<T>(int id)
        {
            const string sql = "EXEC SP_producto_by_id @id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int Store(Producto producto)
        {
            const string sql = "EXEC SP_producto_insert @nombre = @nombre, @id_categoria = @id_categoria, @usuario_registro = @usuario_registro, @fecha_registro = @fecha_registro, @estado_registro = @estado_registro";

            var parameters = new DynamicParameters();
            parameters.Add("nombre", producto.Nombre, DbType.String);
            parameters.Add("id_categoria", producto.CategoriaId, DbType.Int32);
            parameters.Add("usuario_registro", producto.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", producto.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", producto.EstadoRegistro, DbType.Int32);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Update(Producto producto, int id)
        {
            const string sql = "EXEC SP_producto_update @nombre = @nombre , @id_categoria = @id_categoria , @usuario_registro = @usuario_registro, @fecha_registro = @fecha_registro, @estado_registro =  @estado_registro , @id = @estado_registro;";

            var parameters = new DynamicParameters();
            parameters.Add("nombre", producto.Nombre, DbType.String);
            parameters.Add("id_categoria", producto.CategoriaId, DbType.Int32);
            parameters.Add("usuario_registro", producto.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", producto.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", producto.EstadoRegistro, DbType.Int32);
            parameters.Add("id", id, DbType.Int32);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Delete(int id)
        {
            const string sql = "EXEC SP_producto_delete @id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
    }
}