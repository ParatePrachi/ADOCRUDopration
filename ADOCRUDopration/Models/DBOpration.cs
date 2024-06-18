using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;


namespace ADOCRUDopration.Models
{
    public class DBOpration
    {
        private SqlConnection connect()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
                conn.Open();
                    return conn;
            }
            catch(Exception ex)
            {
                  throw;
            }
        }
        public DataSet GetStateData()
        {
            var conn = connect();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("SPRegistration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommandType", "GetState");
                SqlDataAdapter da = new SqlDataAdapter();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetCityData(int StateId)
        {
            var conn = connect();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("SPRegistration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State", StateId);
                cmd.Parameters.AddWithValue("@CommandType", "GetCityBYId");
                SqlDataAdapter da = new SqlDataAdapter();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveReg(RegistrationModel model)
        {
            var conn = connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SPRegistration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@City", model.City);
                cmd.Parameters.AddWithValue("@State", model.State);
                cmd.Parameters.AddWithValue("@Pincode", model.Pincode);
                cmd.Parameters.AddWithValue("@EmailId", model.Email);
                cmd.Parameters.AddWithValue("@PassWord", model.PassWord);
                cmd.Parameters.AddWithValue("@Hobbies", model.Hobbies);
                cmd.Parameters.AddWithValue("@CommandType", "InsertUpdate");//SP command type name Insertupdate
                int i = cmd.ExecuteNonQuery();
                return i;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<RegistrationModel> RegData()
        {
            var conn = connect();
            List<RegistrationModel> Reglist = new List<RegistrationModel>();
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPRegistration", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CommandType", "SelectAll");
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        RegistrationModel reg = new RegistrationModel();
                        reg.Id = Convert.ToInt32(dr["Id"].ToString());
                        reg.Name = dr["Name"].ToString();
                        reg.Gender = dr["Gender"].ToString();
                        reg.MobileNo = dr["MobileNo"].ToString();
                        reg.Address = dr["Address"].ToString();
                        reg.CityName = dr["CityName"].ToString();
                        reg.StateName = dr["StateName"].ToString();
                        //reg.City = Convert.ToInt32(dr["City"].ToString());
                        //reg.State = Convert.ToInt32(dr["State"].ToString());
                        reg.Pincode = dr["Pincode"].ToString();
                        reg.Email = dr["EmailId"].ToString();
                        reg.PassWord = dr["PassWord"].ToString();
                        reg.Hobbies = dr["Hobbies"].ToString();
                        Reglist.Add(reg);
                    }

                    return Reglist;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public int DeleteReg(int Id)
        {
            var conn = connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SPRegistration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@CommandType", "Delete");
                int i = cmd.ExecuteNonQuery();
                return i;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet EditReg(int Id)
        {
            var conn = connect();
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("SPRegistration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@CommandType", "GetRegById");
                SqlDataAdapter da = new SqlDataAdapter();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}