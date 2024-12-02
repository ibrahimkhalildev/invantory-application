using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Equipment
{
    public class BaseEquipment
    {
        public int EquipmentId { set; get; }
        public string EquipmentName { set; get; }
        public int Quantity { set; get; }
        public int Stock { set; get; }
        public DateTime EntryDate { set; get; }

        public List<BaseEquipment> ListEquipment()
        {
            List<BaseEquipment> equipment = new List<BaseEquipment>();
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
                        BaseEquipment objBaseequipment = new BaseEquipment();

                        objBaseequipment.EquipmentId = Convert.ToInt32(reader["EquipmentId"].ToString());
                        objBaseequipment.EquipmentName = Convert.ToString(reader["EquipmentName"].ToString());
                        objBaseequipment.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                        objBaseequipment.Stock = Convert.ToInt32(reader["Stock"].ToString());
                        //objBaseequipment.EntryDate = reader["EntryDate"].ToString("dd/MM/yyyy");
                        objBaseequipment.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                        //objBaseequipment.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                        
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

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return equipment;
        }
    }
}