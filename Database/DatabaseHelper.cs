using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

public class DatabaseHelper
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

    public static DataTable ExecuteQuery(string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

    public static void ExecuteNonQuery(string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public static void ExecuteNonQueryParameterized(string query, Dictionary<string, object> parameters)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                    
                command.ExecuteNonQuery();
            }
        }
    }

    public static int ExecuteNonQueryIParameterized(string query, Dictionary<string, object> parameters, bool returnIdentity = false)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                if (returnIdentity)
                {
                    // Add an output parameter for returning the generated identity value
                    SqlParameter outputParameter = new SqlParameter("@Identity", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputParameter);

                    // Execute the query and return the generated identity value
                    command.ExecuteNonQuery();
                    return Convert.ToInt32(outputParameter.Value);
                }
                else
                {
                    // Execute the query and return the number of affected rows
                    return command.ExecuteNonQuery();
                }
            }
        }
    }


    public static DataTable ExecuteQueryParameterized(string query, Dictionary<string, object> parameters)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }

}
