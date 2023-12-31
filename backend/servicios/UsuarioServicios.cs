using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class UsuariosServicios
    {
        public static IEnumerable<T> GetAll<T>()
        {
            const string sql = "EXEC SP_usuario;";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T GetOne<T>(int id)
        {
            const string sql = "select * from usuarios where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int Store(Usuario usuarios)
        {
            const string sql = "EXEC SP_usuario_insert @user_name = @user_name, @nombre_completo =  @nombre_completo, @password = @password, @usuario_registro = @usuario_registro, @fecha_registro = @fecha_registro, @estado_registro = @estado_registro;";

            var parameters = new DynamicParameters();
            parameters.Add("user_name", usuarios.UserName, DbType.String);
            parameters.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameters.Add("password", usuarios.Password, DbType.String);
            parameters.Add("usuario_registro", usuarios.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", usuarios.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", usuarios.EstadoRegistro, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Update(Usuario usuarios, int id)
        {
            const string sql = "EXEC SP_usuario_update @user_name = @user_name, @nombre_completo = @nombre_completo, @password = @password, @usuario_registro = @usuario_registro, @fecha_registro =  @fecha_registro, @estado_registro = @estado_registro, @id = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("user_name", usuarios.UserName, DbType.String);
            parameters.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameters.Add("password", usuarios.Password, DbType.String);
            parameters.Add("usuario_registro", usuarios.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", usuarios.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", usuarios.EstadoRegistro, DbType.Int32);
            parameters.Add("id", id, DbType.Int32);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int Delete(int id)
        {
            const string sql = "EXEC SP_usaurio_delete @id = @id ";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            var result = BDManager.GetInstance.SetData(sql, parameters);

            return result;
        }
    }
}