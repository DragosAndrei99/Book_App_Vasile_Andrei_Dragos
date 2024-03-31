﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.Models;

namespace Book_App_Vasile_Andrei_Dragos.Utils
{
    public class DbUtils
    {

        public static ObservableCollection<Author> QueryAuthors(string commandText)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;
            ObservableCollection<Author> results = new ObservableCollection<Author>();
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
                            Author author = new Author(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.IsDBNull(3) ? new DateTime() :  reader.GetDateTime(3), reader.GetBoolean(4));
                            results.Add(author);
                        }
                    }
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return results;
        }

        public static Author ExecuteCommand(string commandText, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;
            Author author = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@AuthorId", SqlDbType.NVarChar);
                command.Parameters["@AuthorId"].Value = id;
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Author authorFound = new Author(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.IsDBNull(3) ? new DateTime() : reader.GetDateTime(3), reader.GetBoolean(4));
                            author = authorFound;
                        }
                    }
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return author;
        }

        public static void ExecuteQuery(string query)
        {

        }

        public static void AddAuthor(string firstName, string lastName, DateTime birthDate)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spAuthorInsert";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                command.Parameters["@FirstName"].Value = firstName;

                command.Parameters.Add("@LastName", SqlDbType.NVarChar);
                command.Parameters["@LastName"].Value = lastName;
                

                // change this to make it work
                command.Parameters.Add("@BirthDate", SqlDbType.DateTime);
                command.Parameters["@BirthDate"].Value = birthDate;

                try
                {
                    connection.Open();

                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
