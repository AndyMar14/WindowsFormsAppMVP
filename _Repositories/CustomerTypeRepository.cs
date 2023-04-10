using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppMVP.Models;

namespace WindowsFormsAppMVP._Repositories
{
    public class CustomerTypeRepository : BaseRepository,ICustomerTypeRepository
    {
        public CustomerTypeRepository(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }

        public void Add(CustomerTypeModel customerTypeModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into CustomerTypes values (@description)";
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = customerTypeModel.Description;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from CustomerTypes where Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(CustomerTypeModel customerTypeModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update CustomerTypes 
                                    set Description=@description
                                    where Id=@id";
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = customerTypeModel.Description;
                command.Parameters.Add("@id", SqlDbType.Int).Value = customerTypeModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<CustomerTypeModel> GetAll()
        {
            var customerList = new List<CustomerTypeModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select c.* from CustomerTypes c " +
                        "order by c.Id desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customerTypeModel = new CustomerTypeModel();
                            customerTypeModel.Id = (int)reader[0];
                            customerTypeModel.Description = reader[1].ToString();
                            customerList.Add(customerTypeModel);
                        }
                    }
                }
                return customerList;
            }
        }

        public IEnumerable<CustomerTypeModel> GetByValue(string searchValue)
        {
            var customerList = new List<CustomerTypeModel>();
            int CustomerId = int.TryParse(searchValue, out _) ? Convert.ToInt32(searchValue) : 0;
            string CustomerName = searchValue;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select c.* from CustomerTypes c 
                                        where c.Id = @id or c.Description like @description+'%' 
                                        order by c.Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = CustomerId;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = CustomerName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customerTypeModel = new CustomerTypeModel();
                        customerTypeModel.Id = (int)reader[0];
                        customerTypeModel.Description = reader[1].ToString();

                        customerList.Add(customerTypeModel);
                    }
                }
            }
            return customerList;
        }
    }
}
