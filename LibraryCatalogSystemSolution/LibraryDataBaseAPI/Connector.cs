using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataBaseAPI;

internal class Connector
{
    private string connectionString;    
    
    private DbProviderFactory factory;

    internal Connector(string provider, string connectionString)
    {
        this.connectionString = connectionString;

        DbProviderFactories.RegisterFactory(provider, SqlClientFactory.Instance);
        factory = DbProviderFactories.GetFactory(provider);
    }

    internal DbDataReader? GetFromDataBase(string sqlCommand)
    {
        // The DBConnection represents the DB connection
        DbConnection? connection = factory.CreateConnection();

        // Check if a connection was made
        if (connection == null)
        {
            Console.WriteLine("Connection Error");
            return null;
        }

        // The DB data needed to open the correct DB
        connection.ConnectionString = connectionString;

        // Open the DB connection
        connection.Open();

        // Allows you to pass queries to the DB
        DbCommand? command = factory.CreateCommand();

        if (command == null)
        {
            Console.WriteLine("Command Error");
            return null;
        }

        // Set the DB connection for commands
        command.Connection = connection;

        // The query you want to issue
        command.CommandText = sqlCommand;

        var reader = command.ExecuteReader();

        return reader;
    }

    internal bool PostToDataBase(string sqlCommand)
    {
        return PostToDataBase(sqlCommand, out string mess);
    }

    internal bool PostToDataBase(string sqlCommand, out string errorMessage)
    {
        // The DBConnection represents the DB connection
        using (DbConnection? connection = factory.CreateConnection())
        {
            // Check if a connection was made
            if (connection == null)
            {
                errorMessage = "Connection Error";
                return false;
            }

            // The DB data needed to open the correct DB
            connection.ConnectionString = connectionString;

            // Open the DB connection
            connection.Open();

            // Allows you to pass queries to the DB
            DbCommand? command = factory.CreateCommand();

            if (command == null)
            {
                errorMessage = "Connection Error";
                return false;
            }

            // Set the DB connection for commands
            command.Connection = connection;

            // The query you want to issue
            command.CommandText = sqlCommand;
            try
            {
                errorMessage = "";
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
