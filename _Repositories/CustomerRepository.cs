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
    public class CustomerRepository : BaseRepository,ICustomerRepository
    {

        public CustomerRepository(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }
        public void Add(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Customers values (@name,@adress,@status,@type)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customerModel.CustName;
                command.Parameters.Add("@adress", SqlDbType.NVarChar).Value = customerModel.Adress;
                command.Parameters.Add("@status", SqlDbType.NVarChar).Value = customerModel.Status;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = customerModel.CustomerType;
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
                command.CommandText = "delete from Customers where Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Customers 
                                    set CustName=@name,Adress = @adress, Status = @status,CustomerTypeId = @type
                                    where Id=@id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customerModel.CustName;
                command.Parameters.Add("@adress", SqlDbType.NVarChar).Value = customerModel.Adress;
                command.Parameters.Add("@status", SqlDbType.NVarChar).Value = customerModel.Status;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = customerModel.CustomerType;
                command.Parameters.Add("@id", SqlDbType.Int).Value = customerModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            var customerList = new List<CustomerModel>();
            using (var connection  = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select c.Id,c.CustName,c.Adress,c.Status,ct.Description from Customers c " +
                        "LEFT JOIN CustomerTypes ct ON(ct.id = c.CustomerTypeID)" +
                        "order by c.Id desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customerModel = new CustomerModel();
                            customerModel.Id = (int)reader[0];
                            customerModel.CustName = reader[1].ToString();
                            customerModel.Adress = reader[2].ToString();
                            if (reader[3].ToString() == "True")
                            {
                                customerModel.Status = "Activo";
                            }
                            else
                            {
                                customerModel.Status = "Inactivo";
                            }
                            customerModel.CustomerType = reader[4].ToString();
                            customerList.Add(customerModel);
                        }
                    }
                }
                return customerList;
            }
        }

        public IEnumerable<CustomerModel> GetByValue(string searchValue)
        {
            var customerList = new List<CustomerModel>();
            int CustomerId = int.TryParse(searchValue, out _) ? Convert.ToInt32(searchValue) : 0;
            string CustomerName = searchValue;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select c.Id,c.CustName,c.Adress,c.Status,ct.Description,ct.Id as typeId from Customers c 
                                        LEFT JOIN CustomerTypes ct ON(ct.id = c.CustomerTypeID)
                                        where c.Id=@id or c.CustName like @name+'%' 
                                        order by c.Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = CustomerId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = CustomerName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customerModel = new CustomerModel();
                        customerModel.Id = (int)reader[0];
                        customerModel.CustName = reader[1].ToString();
                        customerModel.Adress = reader[2].ToString();
                        if (reader[3].ToString() == "True")
                        {
                            customerModel.Status = "Activo";
                        }
                        else
                        {
                            customerModel.Status = "Inactivo";
                        }
                        customerModel.CustomerType = reader[4].ToString();
                        customerModel.CustomerTypeId = reader[5].ToString();

                        customerList.Add(customerModel);
                    }
                }
            }
            return customerList;
        }
        public IEnumerable<CustomerTypeModel> GetAllTypes()
        {
            var customerTypeList = new List<CustomerTypeModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select * from CustomerTypes ";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customerTypeModel = new CustomerTypeModel();
                            customerTypeModel.Id = (int)reader[0];
                            customerTypeModel.Description = reader[1].ToString();

                            customerTypeList.Add(customerTypeModel);
                        }
                    }
                }
                return customerTypeList;
            }
        }
    }
}
