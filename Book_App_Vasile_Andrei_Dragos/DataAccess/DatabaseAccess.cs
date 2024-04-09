using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Reflection;
using Book_App_Vasile_Andrei_Dragos.Utils;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class DatabaseAccess
    {
        public static SQLTypesMapper mapper = new SQLTypesMapper();

        public static List<Dictionary<string, string>> ExecuteCommandById(string commandText, int id, string idFieldName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;
            List<Dictionary<string, string>> listOfFields = new List<Dictionary<string, string>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add($"@{idFieldName}", SqlDbType.NVarChar);
                command.Parameters[$"@{idFieldName}"].Value = id;
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, string> fields = new Dictionary<string, string>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                fields[reader.GetName(i)] = reader.GetValue(i).ToString();
                            }
                            listOfFields.Add(fields);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return listOfFields;
            }
        }

        public static List<Dictionary<string, string>> ExecuteQueryAllCommand(string commandText)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;
            List<Dictionary<string, string>> listOfFields =  new List<Dictionary<string, string>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, string> fields = new Dictionary<string, string>(); 
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                fields[reader.GetName(i)] = reader.GetValue(i).ToString();
                            }
                            listOfFields.Add(fields);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return listOfFields;
        }

        public static int ExecuteCommand(string commandText, object entryToUpdate)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (PropertyInfo prop in entryToUpdate.GetType().GetProperties())
                {
                    string fieldToUpdate = $"@{prop.Name}";
                    Type fieldType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    command.Parameters.Add(fieldToUpdate, DatabaseAccess.mapper.MapToSqlType(fieldType));
                    object field = prop.GetValue(entryToUpdate, null);
                    command.Parameters[fieldToUpdate].Value = field?.ToString();
                }

                try
                {
                    connection.Open();
                    int modified = Convert.ToInt32(command.ExecuteScalar());

                    return modified;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return -1;
            }
        }
    }
}
