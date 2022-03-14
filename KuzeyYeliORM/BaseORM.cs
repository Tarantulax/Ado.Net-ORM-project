using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeliORM
{
    public class BaseORM<T> : IORM<T>
    {
        public DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = Tools.Baglanti;

            cmd.CommandText =string.Format("{0}Listele",typeof(T).Name);
            cmd.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        public bool Ekle(T entity)
        { 
            SqlCommand komut = new SqlCommand();
            komut.CommandText = string.Format("{0}Ekle", typeof(T).Name);
            komut.Connection = Tools.Baglanti;
            komut.CommandType = CommandType.StoredProcedure;

            PropertyInfo[] parametreler = typeof(T).GetProperties();

            //for (int i = 1; i < parametreler.Count(); i++)
            //{
            //    if (parametreler[i].GetValue(entity) == null)
            //        parametreler[i].SetValue(entity, "0"); 
            //    komut.Parameters.AddWithValue(parametreler[i].Name, parametreler[i].GetValue(entity));

            //}
            foreach (PropertyInfo item in parametreler)
            {
                komut.Parameters.AddWithValue("@"+item.Name, item.GetValue(entity));
            }

            return Tools.ExecuteNonQuery(komut);
          
        }

        public bool Guncelle(T entity)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = string.Format("{0}Update",typeof(T).Name);
            komut.Connection = Tools.Baglanti;
            komut.CommandType = CommandType.StoredProcedure;

           PropertyInfo[] parametreler=typeof(T).GetProperties();

            foreach (PropertyInfo item in parametreler)
            {
                komut.Parameters.AddWithValue("@" + item.Name, item.GetValue(entity));
            }

            return Tools.ExecuteNonQuery(komut);
        }
    
        public bool Sil(int id)
        {
           T entity=Activator.CreateInstance<T>();//Metot hangi tablo için çalışacaksa o bilgiyi almak için
            SqlCommand komut = new SqlCommand();
            komut.CommandText = string.Format("{0}Sil", typeof(T).Name);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Connection = Tools.Baglanti;

            //PropertyInfo[] parametreler = typeof(T).GetProperties();

            //komut.Parameters.AddWithValue(parametreler[0].Name, parametreler[0].GetValue(entity));

            PropertyInfo pid = typeof(T).GetProperty("tabloID");

            string parametre = "@" + pid.GetValue(entity);

            komut.Parameters.AddWithValue(parametre, id);

            return Tools.ExecuteNonQuery(komut);
        }
    }
}
