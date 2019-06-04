using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace InClassAspNetMarkVii
{
    public class ProductRepository
    {
        private string connectionStr = "";

        public List<Models.Product> GetAllProducts()
        {
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText =
                "SELECT ProductId, Name, Price " +
                "FROM products";

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Models.Product> products = new List<Models.Product>();

                while(dataReader.Read())
                {
                    Models.Product product = new Models.Product()
                    {
                        Id = dataReader.GetInt32("ProductId"),
                        Name = dataReader.GetString("Name"),
                        Price = dataReader.GetDecimal("Price")
                    };

                    products.Add(product);
                }

                return products;
            }
        }
        public void DeleteProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText =
                "DELETE FROM products " +
                "WHERE ProductId = @id;";
            cmd.Parameters.AddWithValue("id", id);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertProduct(string name, decimal price)
        {
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText =
                "INSERT INTO products (Name, Price, CategoryId, Onsale, StockLevel) " +
                "VALUES (@name, @price, 1, 0, 100)";
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("price", price);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
            
    }
}
