using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeliORM
{
    public class Tools
    {
        private static SqlConnection baglanti;
            
            //baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);      

        public static SqlConnection Baglanti
        {
            get 
            { 
                if(baglanti==null) //baglanti her kullanıldığında yeniden new ile örneklenmesin (singleton pattern)
                {
                    baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
                }
                return baglanti; 
            }
            //set { baglanti = value; }
        }

        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                int sonuc = 0;
                if (komut.Connection.State == ConnectionState.Closed)  
                    komut.Connection.Open();
                sonuc = komut.ExecuteNonQuery();
                return sonuc > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (komut.Connection.State==ConnectionState.Open)
               komut.Connection.Close();
            }
       
       

      
        }

    }
}
