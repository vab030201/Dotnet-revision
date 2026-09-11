
using MySqlConnector;

namespace ShoppingCartDapper.Data
{
    


public class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }   

    public MySqlConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
}
