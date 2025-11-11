using Microsoft.Data.SqlClient;
using ScreenSound.Modelo;

namespace ScreenSound.Banco;

internal class Connection
{
    private readonly string stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(stringConnection);
    }
}
