using System;
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

    static public string SQLAction()
    {
        //rtbDataWindow.Clear();

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=true";

        using SqlConnection conn = new SqlConnection(connectionString);

        conn.Open();

        string query = "SELECT * FROM person";

        //Instantiate SQL object with query and current connection (conn) from Main()
        using var select = new SqlCommand(query, conn);

        using var reader = select.ExecuteReader();
        string temp = "";

        //Read from DB using the query. Will continue until there are no more rows
        while (reader.Read())
        {
            temp += $"{reader["person_id"]} {reader["first_name"]} {reader["last_name"]} {reader["phone"]} {reader["email"]} {reader["street"]} {reader["city"]} {reader["zip_code"]} {reader["country"]}\n";
            //  form.rtbDataWindow.AppendText(temp);
        }
        return temp;

    }

}