using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Invantory_Application.Models
{
    public class CustomerList
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustAddress { get; set; }

        public List<EquipmentList> Equipment { get; set; }

        public CustomerList()
        {
            Equipment = new List<EquipmentList>();
        }
        public CustomerList Query_for_Equipment_List(int CustomerID)
        {
            CustomerList customerList = new CustomerList();
            DataTable dataTable = new DataTable();
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "dbo.spEquipmentListbyCustomerID";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                //SqlDataReader reader = cmd.ExecuteReader();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                //var Equipments = (from q in dataTable.AsEnumerable() select q.Field<string> ("EquipmentName")).Distinct();
                //foreach (var equipment in Equipments)
                //{
                //    EquipmentList equipmentList = new EquipmentList();
                //    equipmentList.EquipmentName = equipment;
                //    this.Equipment.Add(equipmentList);
                //}

                var Equipments = (from q in dataTable.AsEnumerable()
                                  select new
                                  {

                                      EquipmentName = q.Field<string>("EquipmentName"),
                                      Price = q.Field<decimal>("Price"),
                                      Quantity = q.Field<int>("Quantity"),
                                      EntryDate = q.Field<DateTime>("EntryDate")

                                  }).ToList();

                foreach (var equipment in Equipments)
                {
                    EquipmentList equipmentList = new EquipmentList();
                    equipmentList.EquipmentName = equipment.EquipmentName;
                    equipmentList.Price = equipment.Price;
                    equipmentList.Quantity = equipment.Quantity;
                    equipmentList.EntryDate = equipment.EntryDate;
                    this.Equipment.Add(equipmentList);
                }
                customerList.Equipment = this.Equipment;
                var customer = (from q in dataTable.AsEnumerable()
                                select new
                                {
                                    CustomerID = q.Field<int>("CustomerID"),
                                    CustomerName = q.Field<string>("CustomerName"),
                                    //CustomerMobile = q.Field<string>("CustomerMobile"),
                                    //CustAddress = q.Field<string>("CustAddress")
                                }).ToList();

                foreach (var cust in customer)
                {
                    //this.CustomerID = cust.CustomerID;
                    //this.CustomerName = cust.CustomerName;
                    customerList.CustomerID = cust.CustomerID;
                    customerList.CustomerName = cust.CustomerName;
                    //this.CustomerMobile = cust.CustomerMobile;
                    //this.CustAddress = cust.CustAddress;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Invalid note data recieved!  Correct the following issues and try again:" + ex.StackTrace);


            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return customerList;
        }




    }
}