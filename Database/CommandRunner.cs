using System.Data.SqlClient;

public class Database
{
    private SqlConnection connection;
    private string connectionString;

    public Database()
    {
        this.connectionString = @"Data Source=SINISTER;Initial Catalog=e_comm;Integrated Security=True;MultipleActiveResultSets=true";
        this.connection = new SqlConnection(connectionString);
    }

    public void Open()
    {
        connection.Open();
    }

    public void Close()
    {
        connection.Close();
    }

    public SqlDataReader ExecuteQuery(string query)
    {
        SqlCommand command = new SqlCommand(query, connection);
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public void ExecuteNonQuery(string query)
    {
        SqlCommand command = new SqlCommand(query, connection);
        command.ExecuteNonQuery();
    }
}