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
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(CustomerModel customerModel)
        {
            throw new NotImplementedException();
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
                            if (reader[3].ToString() == "1")
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
                command.CommandText = @"Select c.Id,c.CustName,c.Adress,c.Status,ct.Description from Customers c 
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
                        if (reader[3].ToString() == "1")
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
}
