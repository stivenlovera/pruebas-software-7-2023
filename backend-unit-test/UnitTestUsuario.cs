using backend.connection;
using backend.entidades;
using backend.servicios;
namespace backen_unit_test;

public class UnitTestUsuario
{
    public UnitTestUsuario()
    {
        BDManager.GetInstance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
    }

    [Fact]
    public void Usuarios_Get_Verificar_NotNull()
    {
        var result = UsuariosServicios.ObtenerTodo<Usuario>();
        Assert.NotNull(result);
    }
}