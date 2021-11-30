﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = OpenConnection())
            {

                // SQL-injection attack potential
                // Always use parameters
                // var badCommand = "UPDATE Movie SET name = '" + userInput + "'";

                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters ; Approach 1
                var parmName = new SqlParameter("@name", System.Data.SqlDbType.VarChar) { Value = movie.Title };
                cmd.Parameters.Add(parmName);

                // Approach 2 (Database Agnostic)
                var parmRating = cmd.CreateParameter();
                parmRating.ParameterName = "@rating";
                parmRating.SqlDbType = System.Data.SqlDbType.VarChar;
                parmRating.Value = movie.Rating;
                cmd.Parameters.Add(parmRating);

                // Approach 3 (SQL Server)
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);


                object result = cmd.ExecuteScalar();
                movie.Id = Convert.ToInt32(result);
            };
            
            //}finally
            //{
            //    // Ensure you always close the connection
            //    conn.Close();
            //};

            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("DeleteMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            };
        }
        protected override Movie FindById ( int id ) => GetCore(id);
        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", title);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Movie() {
                            Id = Convert.ToInt32(reader[0]),                            // Ordinal and indexing
                            Title = Convert.ToString(reader["Name"]),                   // Name and indexing
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),// Ordinal and Get
                            Rating = reader.GetString("Rating"),                        // Name and Get
                            ReleaseYear = reader.GetFieldValue<int>(4),                 // Ordinal and Generic
                            RunLength = reader.GetFieldValue<int>("RunLength"),         // Name and Generic
                            IsClassic = reader.GetFieldValue<bool>("IsClassic")         // Name and Generic
                        };
                    };
                };
            };

            return null;
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovies", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Load the Data, connection must be open
                // 1. Must create adapter and associate with command
                // 2. Must create DAtaset
                // 3. Call Fill on adapter
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            };

            // Enumerate the results
            // 1. Find the table
            // 2. Enumerate the rows
            // 3. Extract the data by ordinal or name
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if(table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    // Ordinal find the array index of the property, thus is faster, just not as readable as name
                    // Ordinals depend on the order in which values are oriented in the table, which is generally undefined
                    // Name is readable though slower to lookup
                    yield return new Movie() {
                        Id = Convert.ToInt32(row[0]),                               // Ordinal and indexing
                        Title = Convert.ToString(row["Name"]),                      // Name and indexing
                        Description = row .IsNull(2) ? "" : row.Field<string>(2),   // Ordinal and Generic
                        Rating = row.Field<string>("Rating"),                       // Name and Generic
                        ReleaseYear = row.Field<int>("ReleaseYear"),                // Name and Generic
                        RunLength = row.Field<int>("RunLength"),                    // Name and Generic
                        IsClassic = row.Field<bool>("isClassic")                    // Name and Generic
                    };
                };
            };
        }
        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Movie() {
                            Id = Convert.ToInt32(reader[0]),                            // Ordinal and indexing
                            Title = Convert.ToString(reader["Name"]),                   // Name and indexing
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),// Ordinal and Get
                            Rating = reader.GetString("Rating"),                        // Name and Get
                            ReleaseYear = reader.GetFieldValue<int>(4),                 // Ordinal and Generic
                            RunLength = reader.GetFieldValue<int>("RunLength"),         // Name and Generic
                            IsClassic = reader.GetFieldValue<bool>("IsClassic")         // Name and Generic
                        };
                    };
                };
            };

            return null;
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {

                // SQL-injection attack potential
                // Always use parameters
                // var badCommand = "UPDATE Movie SET name = '" + userInput + "'";

                var cmd = new SqlCommand("UpdateMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                // Add Parameters ; Approach 1
                var parmName = new SqlParameter("@name", System.Data.SqlDbType.VarChar) { Value = movie.Title };
                cmd.Parameters.Add(parmName);

                // Approach 2 (Database Agnostic)
                var parmRating = cmd.CreateParameter();
                parmRating.ParameterName = "@rating";
                parmRating.SqlDbType = System.Data.SqlDbType.VarChar;
                parmRating.Value = movie.Rating;
                cmd.Parameters.Add(parmRating);

                // Approach 3 (SQL Server)
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                cmd.ExecuteNonQuery();
            };
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
    }
}
