using EmployeeManagement;
using Microsoft.Data.SqlClient;
using RabbitMQConsumer.Models;
using System.Data;

namespace RabbitMQConsumer.Services
{
    public class ConsumerService
    {
        private SqlConnection _connection;
        public ConsumerService()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("SecureConnection");
            _connection = SQLConnectionManager.Instance.GetConnection(connectionString);
            _connection.Open();
        }

        public async Task BulkInsertFromJsonFileAsync(List<PersonCopy> data, string tableName)
        {

            var dataTable = ConvertToDataTable(data!);

            using (var sqlBulkCopy = new SqlBulkCopy(_connection))
            {
                // Map the columns in the DataTable to the destination table columns
                foreach (DataColumn column in dataTable.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }

                // Set the destination table name
                sqlBulkCopy.BulkCopyTimeout = 0;
                sqlBulkCopy.DestinationTableName = tableName;

                try
                {
                    // Perform the bulk insert
                    await sqlBulkCopy.WriteToServerAsync(dataTable);
                    //_connection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private DataTable ConvertToDataTable<T>(List<T> data)
        {
            var dataTable = new DataTable();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (var item in data)
            {
                var row = dataTable.NewRow();

                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item);
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
