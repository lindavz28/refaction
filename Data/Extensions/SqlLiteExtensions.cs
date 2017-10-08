using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Data.Extensions
{
    public static class SqlLiteExtensions
    {

        public static int ExecuteNonQuery( this SQLiteConnection connection, string commandText, object param = null)
        {
            // Ensure we have a connection
            // Previously I've done validation using a method attribute but this is quicker for this assignment
            if (connection == null)
            {
                throw new NullReferenceException("Please provide a connection");
            }

            if (string.IsNullOrEmpty(commandText))
            {
                throw new NullReferenceException("No SQL command provided");
            }
                       
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // Use Dapper to execute the command
            connection.Execute(commandText, param);

            return connection.Changes;
        }

        public static IEnumerable<T> ExecuteQuery<T>(this SQLiteConnection connection, string queryText, object param = null)
        {
            // Ensure we have a connection
            if (connection == null)
            {
                throw new NullReferenceException("Please provide a connection");
            }

            if (string.IsNullOrEmpty(queryText))
            {
                throw new NullReferenceException("No SQL command provided");
            }

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // Use Dapper to execute the given query
            return connection.Query<T>(queryText, param );
        }
    }
}
