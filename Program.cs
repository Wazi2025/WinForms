using Microsoft.Data.SqlClient;

namespace WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());

    }

    static public void SQLInsert(List<string> data)
    {
        //Set connection string, instantiate DB object and open DB connection
        //Note: Had problems with accessing SqlConnection in it's own method, will look into it later
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=true";
        using SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string insertQuery = "INSERT INTO person (first_name, last_name, email) VALUES (@f_name, @l_name, @email)";

        //Instantiate SQL object with query and current connection (conn)
        using var insert = new SqlCommand(insertQuery, conn);

        //Note: Prolly add some sort of validation here
        insert.Parameters.AddWithValue("@f_name", data[0]);
        insert.Parameters.AddWithValue("@l_name", data[1]);
        insert.Parameters.AddWithValue("@email", data[2]);

        //Execute query
        insert.ExecuteNonQuery();
    }

    static public string SQLSelect()
    {
        //Set connection string, instantiate DB object and open DB connection
        //Note: Had problems with accessing SqlConnection in it's own method, will look into it later
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=true";
        using SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string query = "SELECT * FROM person";

        //Instantiate SQL object with query and current connection (conn)
        using var select = new SqlCommand(query, conn);

        using var reader = select.ExecuteReader();
        string result = "";

        //Read from DB using the query. Will continue until there are no more rows
        while (reader.Read())
        {
            result += $"{reader["person_id"]} {reader["first_name"]} {reader["last_name"]} {reader["phone"]} {reader["email"]} {reader["street"]} {reader["city"]} {reader["zip_code"]} {reader["country"]}\n";
        }
        return result;
    }
}