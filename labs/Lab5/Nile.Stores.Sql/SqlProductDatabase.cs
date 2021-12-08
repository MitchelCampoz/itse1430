using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        /// <summary>Connects the database with the connection string</summary>
        /// <param name="connectionString"></param>
        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        /// <summary>Gets the product via the specified ID</summary>
        /// <param name="id"></param>
        /// <returns>Returns the specified product</returns>
        protected override Product GetCore ( int id )
        {
            using (var connect = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product() {
                            Id = reader.GetFieldValue<int>("id"),
                            Name = reader.GetFieldValue<string>("name"),
                            Price = reader.GetFieldValue<decimal>("price"),
                            Description = reader.GetFieldValue<string>("description"),
                            IsDiscontinued = reader.GetFieldValue<bool>("isDiscontinued")
                        };
                    };
                };
            };

            return null;
        }

        /// <summary>Gets all the products in the list and puts them into a dataset</summary>
        /// <returns>All of the products</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            var set = new DataSet();

            using (var connect = OpenConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(set);
            };

            var table = set.Tables.OfType<DataTable>().FirstOrDefault();

            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Id = row.Field<int>("id"),
                        Name = row.Field<string>("name"),
                        Price = row.Field<decimal>("price"),
                        Description = row.Field<string>("description"),
                        IsDiscontinued = row.Field<bool>("isDiscontinued")
                    };
                };
            };
        }
        
        /// <summary>Handles the deletion of a product from the database</summary>
        /// <param name="id"></param>
        protected override void RemoveCore ( int id )
        {
            using (var connect = OpenConnection())
            {
                var cmd = new SqlCommand("RemoveProduct", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            };
        }

        /// <summary>Updates an item's existing properties with new data</summary>
        /// <param name="existing"></param>
        /// <param name="newItem"></param>
        /// <returns>An updated product</returns>
        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var connect = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", existing.Id);

                var paramName = cmd.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.SqlDbType = System.Data.SqlDbType.VarChar;
                paramName.Value = newItem.Name;
                cmd.Parameters.Add(paramName);

                var paramPrice = cmd.CreateParameter();
                paramPrice.ParameterName = "@price";
                paramPrice.SqlDbType = System.Data.SqlDbType.VarChar;
                paramPrice.Value = newItem.Price;
                cmd.Parameters.Add(paramPrice);

                var paramDescript = cmd.CreateParameter();
                paramDescript.ParameterName = "@description";
                paramDescript.SqlDbType = System.Data.SqlDbType.VarChar;
                paramDescript.Value = newItem.Description;
                cmd.Parameters.Add(paramDescript);

                var paramIsDisc = cmd.CreateParameter();
                paramIsDisc.ParameterName = "@isDiscontinued";
                paramIsDisc.SqlDbType = System.Data.SqlDbType.VarChar;
                paramIsDisc.Value = newItem.IsDiscontinued;
                cmd.Parameters.Add(paramIsDisc);

                cmd.ExecuteNonQuery();
            };

            return null;
        }

        /// <summary>Adds a new item to the database</summary>
        /// <param name="product"></param>
        /// <returns>A new item</returns>
        protected override Product AddCore ( Product product )
        {
            using (var connect = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var paramName = cmd.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.SqlDbType = System.Data.SqlDbType.VarChar;
                paramName.Value = product.Name;
                cmd.Parameters.Add(paramName);

                var paramPrice = cmd.CreateParameter();
                paramPrice.ParameterName = "@price";
                paramPrice.SqlDbType = System.Data.SqlDbType.VarChar;
                paramPrice.Value = product.Price;
                cmd.Parameters.Add(paramPrice);

                var paramDescript = cmd.CreateParameter();
                paramDescript.ParameterName = "@description";
                paramDescript.SqlDbType = System.Data.SqlDbType.VarChar;
                paramDescript.Value = product.Description;
                cmd.Parameters.Add(paramDescript);

                var paramIsDisc = cmd.CreateParameter();
                paramIsDisc.ParameterName = "@isDiscontinued";
                paramIsDisc.SqlDbType = System.Data.SqlDbType.VarChar;
                paramIsDisc.Value = product.IsDiscontinued;
                cmd.Parameters.Add(paramIsDisc);

                object result = cmd.ExecuteScalar();
                product.Id = Convert.ToInt32(result);
            }

            return product;
        }

        /// <summary>Finds the product with the specified ID</summary>
        /// <param name="id"></param>
        /// <returns>An item grabbed through the GetCore function</returns>
        protected override Product FindProduct ( int id ) => GetCore(id);

        /// <summary>Starts the connection of the database</summary>
        /// <returns>An open connection</returns>
        private SqlConnection OpenConnection ()
        {
            var connect = new SqlConnection(_connectionString);
            connect.Open();

            return connect;
        }
    }
}
