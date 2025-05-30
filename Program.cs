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

    public class Person()
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
    static public void SQLInsert(List<string> data)
    {
        //Set connection string, instantiate DB object and open DB connection
        //Note: Had problems with accessing SqlConnection in it's own method, will look into it later
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=true";
        using SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string insertQuery = "INSERT INTO person (first_name, last_name, phone, email, street, city, zip_code, country) VALUES (@f_name, @l_name, @phone, @email, @street, @city, @zip, @country)";

        //Instantiate SQL object with query and current connection (conn)
        using var insert = new SqlCommand(insertQuery, conn);

        //Note: Prolly add some sort of validation here
        insert.Parameters.AddWithValue("@f_name", data[0]);
        insert.Parameters.AddWithValue("@l_name", data[1]);
        insert.Parameters.AddWithValue("@phone", data[2]);
        insert.Parameters.AddWithValue("@email", data[3]);
        insert.Parameters.AddWithValue("@street", data[4]);
        insert.Parameters.AddWithValue("@city", data[5]);
        insert.Parameters.AddWithValue("@zip", data[6]);
        insert.Parameters.AddWithValue("@country", data[7]);

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

        // Person[] person = new Person[2];

        // int i = 0;
        // int amount = 0;

        //Read from DB using the query. Will continue until there are no more rows
        // while (reader.Read())
        // {
        //     person[i] = new Person();

        //     person[i].ID = ($"{reader["person_id"]}");
        //     person[i].FirstName = ($"{reader["first_name"]}");
        //     person[i].LastName = ($"{reader["last_name"]}");
        //     person[i].Phone = ($"{reader["phone"]}");
        //     person[i].Email = ($"{reader["email"]}");
        //     person[i].Street = ($"{reader["street"]}");
        //     person[i].City = ($"{reader["city"]}");
        //     person[i].Zip = ($"{reader["zip_code"]}");
        //     person[i].Country = ($"{reader["country"]}");
        //     i++;
        // }
        // amount = i;
        // return person[amount];

        while (reader.Read())
        {
            result += $"{reader["person_id"]} {reader["first_name"]} {reader["last_name"]} {reader["phone"]} {reader["email"]} {reader["street"]} {reader["city"]} {reader["zip_code"]} {reader["country"]}\n";
        }
        return result;
    }
}