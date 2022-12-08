using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDataAccess.Models;

namespace SimpleDataAccess.DataAccess
{
    namespace CS_SimleDataAccess.DataAccess
    {
        internal class ProductDbAccess : IDbAccess<Product, int>
        {
            SqlConnection connection;
            SqlCommand command;

            public ProductDbAccess()
            {
                connection = new SqlConnection("Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=eShopping;Integrated Security=SSPI");
            }

            Product IDbAccess<Product, int>.Create(Product entity)
            {
                try
                {
                    connection.Open();
                    command=connection.CreateCommand();
                    command.CommandType=System.Data.CommandType.Text;
                    command.CommandText = "Insert into Product values(@ProductUniqueId,@ProductId,@ProductName,@Description,@Price,@CategoryId,@Manufacturer)";

                    command.Parameters.AddWithValue("@ProductUniqueId", entity.ProductUniqueId);
                    command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                    command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@Price", entity.Price);
                    command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                    command.Parameters.AddWithValue("@Manufacturer", entity.Manufacturer);

                    int res = command.ExecuteNonQuery();
                    if (res == 0)
                        throw new Exception("No Record Inserted");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return entity;
            }

            public bool Delete(int id)
            {
                bool isDeleted = false;
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "Delete Product Where ProductUniqueId=@ProductUniqueId";
                    // Set Parmeters
                    command.Parameters.AddWithValue("@ProductUniqueId", id);

                    // Execute
                    int res = command.ExecuteNonQuery();
                    if (res == 0)
                        throw new Exception("No Record Deleted");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return isDeleted;
            }

            Product IDbAccess<Product, int>.Get(int id)
            {
                var products = new Product();
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Category Where CategoryId=@CategoryId";
                    // Set Parmeters
                    command.Parameters.AddWithValue("@CategoryId", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        products =(new Product()
                        {
                            ProductUniqueId = Convert.ToInt32(reader["ProductUniqueId"]),
                            ProductId = reader["ProductId"].ToString()!,
                            ProductName = reader["ProductName"].ToString()!,
                            Description = reader["Description"].ToString()!,
                            Price = Convert.ToInt32(reader["Price"]),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            Manufacturer = reader["Manufacturer"].ToString()!,
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return products; 
            }

            IEnumerable<Product> IDbAccess<Product, int>.GetAll()
            {
                List<Product> products = new List<Product>();
                try
                {
                    connection.Open();
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "Select * from Product";  
                    SqlDataReader reader=command.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(new Product()
                        {
                            ProductUniqueId = Convert.ToInt32(reader["ProductUniqueId"]),
                            ProductId= reader["ProductId"].ToString()!,
                            ProductName = reader["ProductName"].ToString()!,
                            Description= reader["Description"].ToString()!,
                            Price = Convert.ToInt32(reader["Price"]),
                            CategoryId= Convert.ToInt32(reader["CategoryId"]),
                            Manufacturer= reader["Manufacturer"].ToString()!,
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                   throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return products;
            }

            Product IDbAccess<Product, int>.Update(int id, Product entity)
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "Update Category set @ProductUniqueId,@ProductId,@ProductName,@Description,@Price,@CategoryId,@Manufacturer";
                    // Set Parmeters
                    command.Parameters.AddWithValue("@ProductUniqueId", entity.ProductUniqueId);
                    command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                    command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@Price", entity.Price);
                    command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                    command.Parameters.AddWithValue("@Manufacturer", entity.Manufacturer);
                    // Execute
                    int res = command.ExecuteNonQuery();
                    if (res == 0)
                        throw new Exception("No Record Updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return entity;
            }

            void IDbAccess<Product, int>.Delete(int id)
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "Delete Category Where CategoryId=@CategoryId";
                    // Set Parmeters
                    command.Parameters.AddWithValue("@CategoryId", id);

                    // Execute
                    int res = command.ExecuteNonQuery();
                    if (res == 0)
                        throw new Exception("No REcord Deleted");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
