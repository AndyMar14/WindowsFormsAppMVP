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
    public class InvoiceRepository : BaseRepository,IInvoiceRepository
    {
        public InvoiceRepository(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }

        public IEnumerable<InvoiceModel> GetAll()
        {
            var customerList = new List<InvoiceModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select i.CustomerId,i.TotalItbis,i.SubTotal,i.Total,c.CustName from Invoice i " +
                        "LEFT JOIN Customers c ON(c.id = i.CustomerId)" +
                        "order by i.Id desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var invoiceModel = new InvoiceModel();
                            invoiceModel.Id = (int)reader[0];
                            invoiceModel.TotalItbis = reader[1].ToString();
                            invoiceModel.SubTotal = reader[2].ToString();
                            invoiceModel.Total = reader[3].ToString();
                            invoiceModel.CustName = reader[4].ToString();
                            customerList.Add(invoiceModel);
                        }
                    }
                }
                return customerList;
            }
        }

        public IEnumerable<InvoiceModel> GetByValue(string searchValue)
        {
            var customerList = new List<InvoiceModel>();
            int CustomerId = int.TryParse(searchValue, out _) ? Convert.ToInt32(searchValue) : 0;
            string CustomerName = searchValue;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select i.CustomerId,i.TotalItbis,i.SubTotal,i.Total,c.CustName from Invoice i 
                                        LEFT JOIN Customers c ON(c.id = i.CustomerId)
                                        WHERE i.Id=@id or c.CustName like @name+'%'
                                        order by i.Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = CustomerId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = CustomerName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var invoiceModel = new InvoiceModel();
                        invoiceModel.Id = (int)reader[0];
                        invoiceModel.TotalItbis = reader[1].ToString();
                        invoiceModel.SubTotal = reader[2].ToString();
                        invoiceModel.Total = reader[3].ToString();
                        invoiceModel.CustName = reader[4].ToString();
                        customerList.Add(invoiceModel);
                    }
                }
            }
            return customerList;
        }

        public IEnumerable<InvoiceDetailModel> GetInvoiceDetail(string searchValue)
        {
            var customerList = new List<InvoiceDetailModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select i.Id,i.TotalItbis,i.SubTotal,i.Total,c.CustName,c.Adress,c.Status,ct.Description from Invoice i " +
                        "LEFT JOIN Customers c ON(c.id = i.CustomerId)" +
                        "LEFT JOIN CustomerTypes ct ON(ct.id = c.CustomerTypeID)" +
                        "WHERE i.Id=@id " +
                        "order by i.Id desc";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = searchValue;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var invoiceModel = new InvoiceDetailModel();
                            invoiceModel.Id = (int)reader[0];
                            invoiceModel.TotalItbis = reader[1].ToString();
                            invoiceModel.SubTotal = reader[2].ToString();
                            invoiceModel.Total = reader[3].ToString();
                            invoiceModel.CustName = reader[4].ToString();
                            invoiceModel.Adress = reader[5].ToString();
                            invoiceModel.Status = reader[6].ToString();
                            invoiceModel.CustomerType = reader[7].ToString();
                            customerList.Add(invoiceModel);
                        }
                    }
                }
                return customerList;
            }
        }
        public IEnumerable<InvoiceItemModel> GetInvoiceItems(string searchValue)
        {
            var customerList = new List<InvoiceItemModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select i.* from InvoiceDetail i " +
                        "WHERE i.CustomerId=@id " +
                        "order by i.Id desc";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = searchValue;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var invoiceModel = new InvoiceItemModel();
                            invoiceModel.Id = (int)reader[0];
                            invoiceModel.Qty = reader[2].ToString();
                            invoiceModel.Price = reader[3].ToString();
                            invoiceModel.TotalItbis = reader[4].ToString();
                            invoiceModel.SubTotal = reader[5].ToString();
                            invoiceModel.Total = reader[6].ToString();
                            customerList.Add(invoiceModel);
                        }
                    }
                }
                return customerList;
            }
        }
    }
}
