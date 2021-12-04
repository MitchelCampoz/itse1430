using System;
using System.Data;
using System.Data.SqlClient;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

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
                            Name = Convert.ToString()
                        }
                    }
                }
            }
        }

        protected override IEnumerable<Product> GetAllCore ();

        protected override void RemoveCore ( int id );

        protected override Product UpdateCore ( Product existing, Product newItem );

        protected override Product AddCore ( Product product )
        {
            using (var connect = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", connect);

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

        protected override Product FindProduct ( int id );

        private SqlConnection OpenConnection ()
        {
            var connect = new SqlConnection(_connectionString);
            connect.Open();

            return connect;
        }
    }
}
