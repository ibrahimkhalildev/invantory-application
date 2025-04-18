﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Invantory_Application.Models
{
    public class Member
    {
        public int id { get; set; }
        public string Name { get; set; } // {"Name" : "Test Name"}
        public string Age { get; set; }
        public string ServiceType { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DashBoardPageURL { get; set; }


        //public bool ValidateMember(string UserName, string Password)
        public void ValidateMember(string UserName, string Password)
        {
            //bool status = false;
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOst_LstMember";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        //status = true;
                        this.id = Convert.ToInt32(reader["id"].ToString());
                        this.Name = Convert.ToString(reader["name"].ToString());
                        this.Age = Convert.ToString(reader["Age"].ToString());
                        this.ServiceType = Convert.ToString(reader["ServiceType"].ToString());
                        this.Password = Convert.ToString(reader["Password"].ToString());
                        this.Role = Convert.ToString(reader["Role"].ToString());
                        this.DashBoardPageURL = Convert.ToString(reader["DashBoardPageURL"].ToString());
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
            //return status;
        }
    }
}