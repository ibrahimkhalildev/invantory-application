using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Invantory_Application.Models
{
    [Serializable]
    public class EquipmentN
    {
        private object equipment;

        public int EquipmentId { set; get; }
        public string EquipmentName { set; get; }
        public int Quantity { set; get; }
        public int Stock { set; get; }
        public DateTime EntryDate { set; get; }
        public DateTime ReceivedDate { set; get; }
        public List<EquipmentN> ListEquipment()
        {
            List<EquipmentN> equipment = new List<EquipmentN>();
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOST_LstEquipment";

                //cmd.Parameters.Clear();
                //cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
                //cmd.Parameters.Add(new SqlParameter("@Password", Password));

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        EquipmentN objBaseequipment = new EquipmentN();
                        //EquipmentId	EquipmentName	Quantity	Stock	EntryDate	ReceiveDate 
                        objBaseequipment.EquipmentId = Convert.ToInt32(reader["EquipmentId"].ToString());
                        objBaseequipment.EquipmentName = Convert.ToString(reader["EquipmentName"].ToString());
                        objBaseequipment.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                        objBaseequipment.Stock = Convert.ToInt32(reader["Stock"].ToString());
                        //objBaseequipment.EntryDate = reader["EntryDate"].ToString("dd/MM/yyyy");
                        objBaseequipment.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                        objBaseequipment.ReceivedDate = Convert.ToDateTime(reader["ReceiveDate"]);

                        equipment.Add(objBaseequipment);
                    }
                }
                reader.Close();

                //DataTable dt = new DataTable();
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                //sqlDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Invalid note data recieved!  Correct the following issues and try again:"+ex.StackTrace);


            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return equipment;
        }

        public int SaveEquipment()
        {
            int ReturnCase = 0;
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOST_InsEquipment";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@Name", this.EquipmentName));
                cmd.Parameters.Add(new SqlParameter("@EcCount", this.Quantity));
                cmd.Parameters.Add(new SqlParameter("@ReceiveDate", this.ReceivedDate));

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                ReturnCase = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return ReturnCase;
        }
    }
}

