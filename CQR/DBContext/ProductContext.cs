using CQR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.DBContext
{
    public class ProductContext : IProductContext
    {
        private readonly string connectionString;

        public ProductContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> Add(Product product)
        {
            Object commandExecutionResult = null;

            var Connection = new SqlConnection(connectionString);


            try
            {
                var command = Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                command.CommandText =
                $"INSERT INTO Products({nameof(product.Name)},{nameof(product.QuantityPerUnit)},{nameof(product.Description)},{nameof(product.UnitPrice)},{nameof(product.UnitsInStock)},{nameof(product.Reporderlevel)},{nameof(product.Discontinued)},{nameof(product.UnitsOnOrder)}) VALUES(@{nameof(product.Name)},@{nameof(product.QuantityPerUnit)},@{nameof(product.Description)},@{nameof(product.UnitPrice)},@{nameof(product.UnitsInStock)},@{nameof(product.Reporderlevel)},@{nameof(product.Discontinued)},@{nameof(product.UnitsOnOrder)});  SELECT @@Identity";

                SetSqlParameters(command.Parameters, product);

                await Connection.OpenAsync();
                commandExecutionResult = await command.ExecuteScalarAsync();

                await command.DisposeAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await Connection.DisposeAsync();
            }

            return commandExecutionResult == null ? -1 : Convert.ToInt32(commandExecutionResult);

        }



        public async Task<IEnumerable<Product>> GetAll()
        {
            List<Product> Products = null;
            var connection = new SqlConnection(connectionString);


            try
            {
                var commad = connection.CreateCommand();
                commad.CommandType = CommandType.Text;
                commad.CommandText = "SELECT * FROM Products";
                await connection.OpenAsync();
                var reader = await commad.ExecuteReaderAsync();

                if (reader != null)
                {
                    Products = new List<Product>();

                    while (await reader.ReadAsync())
                    {
                        Products.Add(GetProduct(reader));
                    }

                    await reader.DisposeAsync();
                }
                await commad.DisposeAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await connection.DisposeAsync();
            }

            return Products;

        }



        public async Task<Product> GetById(int id)
        {
            Product Product = null;
            var connection = new SqlConnection(connectionString);


            try
            {
                var commad = connection.CreateCommand();
                commad.CommandType = CommandType.Text;
                commad.CommandText = $"SELECT * FROM Products WHERE Id = @{nameof(Product.Id)}";

                commad.Parameters.AddWithValue($"@{nameof(Product.Id)}", id);

                await connection.OpenAsync();

                var reader = await commad.ExecuteReaderAsync();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Product = GetProduct(reader);
                    }

                    await reader.DisposeAsync();
                }


                await commad.DisposeAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await connection.DisposeAsync();
            }

            return Product;
        }

        public async Task<bool> Remove(int id)
        {
            object CommandExecutionResult = null;

            var connection = new SqlConnection(connectionString);

            try
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"DELETE Products WHERE {nameof(Product.Id)} = @{nameof(Product.Id)}";

                command.Parameters.AddWithValue($"@{nameof(Product.Id)}", id);

                await connection.OpenAsync();

                CommandExecutionResult = command.ExecuteNonQueryAsync();

                await command.DisposeAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await connection.DisposeAsync();
            }


            return CommandExecutionResult is null ? false : Convert.ToInt32(CommandExecutionResult) > 0;

        }

        public async Task<bool> Update(Product product)
        {
            Object commandExecutionResult = null;

            var Connection = new SqlConnection(connectionString);


            try
            {
                var command = Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                command.CommandText =
                $"UPDATE Products SET {nameof(product.Name)} = @{nameof(product.Name)},{nameof(product.QuantityPerUnit)} = @{nameof(product.QuantityPerUnit)}, {nameof(product.Description)} = @{nameof(product.Description)},{nameof(product.UnitPrice)} = @{nameof(product.UnitPrice)},{nameof(product.UnitsInStock)} = @{nameof(product.UnitsInStock)},{nameof(product.Reporderlevel)} = @{nameof(product.Reporderlevel)},{nameof(product.Discontinued)} = @{nameof(product.Discontinued)},{nameof(product.UnitsOnOrder)} = @{nameof(product.UnitsOnOrder)} WHERE {nameof(Product.Id)} = @{nameof(Product.Id)};";

                SetSqlParameters(command.Parameters, product);

                command.Parameters.AddWithValue($"@{nameof(Product.Id)}", product.Id);

                await Connection.OpenAsync();
                commandExecutionResult = await command.ExecuteNonQueryAsync();

                await command.DisposeAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await Connection.DisposeAsync();
            }

            return commandExecutionResult is null ? false : Convert.ToInt32(commandExecutionResult) > 0;
        }




        private void SetSqlParameters(SqlParameterCollection parameters, Product product)
        {
            parameters.AddWithValue($"@{nameof(product.Name)}", product.Name);
            parameters.AddWithValue($"@{nameof(product.QuantityPerUnit)}", product.QuantityPerUnit);
            parameters.AddWithValue($"@{nameof(product.Description)}", product.Description);
            parameters.AddWithValue($"@{nameof(product.UnitPrice)}", product.UnitPrice);
            parameters.AddWithValue($"@{nameof(product.UnitsInStock)}", product.UnitsInStock);
            parameters.AddWithValue($"@{nameof(product.Reporderlevel)}", product.Reporderlevel);
            parameters.AddWithValue($"@{nameof(product.Discontinued)}", product.Discontinued);
            parameters.AddWithValue($"@{nameof(product.UnitsOnOrder)}", product.UnitsOnOrder);
        }


        private Product GetProduct(SqlDataReader reader)
        {
            return new Product
            {
                Id = reader.GetInt32(reader.GetOrdinal(nameof(Product.Id))),
                Name = reader.GetString(nameof(Product.Name)),
                QuantityPerUnit = reader.GetString(nameof(Product.QuantityPerUnit)),
                Description = reader.GetString(nameof(Product.Description)),
                UnitPrice = reader.GetDecimal(nameof(Product.UnitPrice)),
                UnitsInStock = reader.GetInt32(nameof(Product.UnitsInStock)),
                UnitsOnOrder = reader.GetInt32(nameof(Product.UnitsOnOrder)),
                Reporderlevel = reader.GetInt32(nameof(Product.Reporderlevel)),
                Discontinued = reader.GetBoolean(nameof(Product.Discontinued))
            };
        }


    }
}
