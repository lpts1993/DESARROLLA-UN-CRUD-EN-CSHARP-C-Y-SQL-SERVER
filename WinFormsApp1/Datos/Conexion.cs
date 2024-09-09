using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Datos
{
    internal class Conexion
    {

        //
        SqlConnection cn;
        public Conexion() 
        {
            cn = new SqlConnection("Data Source=LAPTOP-8UITBRBH;Initial Catalog=empleado_db;Integrated Security=True");
        }


        //conectar
        public SqlConnection conectar()
        {
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception e)
            {
               return null;
            }
            
        }

        //desconectar
        public bool desconectar()
        {
            try
            {
                cn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }



    }
}
