using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.modelo;

namespace WinFormsApp1.Datos
{
    internal class EmpleadoCAD
    {

        //GUARDAR DATOS
        public static bool guardar(Empleado e) 
        {
            try 
            {
                Conexion cn = new Conexion();
                string sql = "INSERT INTO [dbo].[tb_empleados] VALUES('" + e.Documento + "','" + e.Nombres+ "','" + e.Apellidos  +"'," +e.Edad +",'" + e.Direccion + "','" + e.Fecha_nacimiento + "')";
                SqlCommand cmd = new SqlCommand(sql,cn.conectar());
                int cantidad  =cmd.ExecuteNonQuery();
               
                if (cantidad==1)
                {
                    cn.desconectar();
                    return true;
                }
                else return false;

                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }


        //LISTAR DATOS
        public static DataTable lISTAR()
        {
            try
            {
                Conexion cn = new Conexion();
                string sql = "select * from [dbo].[tb_empleados]";
                SqlCommand cmd = new SqlCommand(sql, cn.conectar());
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                DataTable dt = new DataTable();
                dt.Load(dr);
                cn.desconectar();
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //consultar DATOS
        public static Empleado consultar(string Documento)
        {
            try
            {
                Conexion cn = new Conexion();
                string sql = "select * from [dbo].[tb_empleados] where documento = '" + Documento + "';";   
                SqlCommand cmd = new SqlCommand(sql, cn.conectar());
                SqlDataReader dr = cmd.ExecuteReader();
                
                Empleado em1 = new Empleado();

                if (dr.Read())
                {
                    em1.Documento = dr["documento"].ToString();

                    em1.Nombres = dr["nombres"].ToString();
                    em1.Apellidos = dr["apellidos"].ToString();
                    em1.Edad = Convert.ToInt32(dr["edad"].ToString());
                    em1.Direccion = dr["direccion"].ToString();
                    em1.Fecha_nacimiento = dr["fecha_nacimiento"].ToString();
                    
                    return  em1;    
                }
                else 
                {
                    cn.desconectar();
                    return null;
                }


             

            }
            catch (Exception ex)
            {
                return null;
            }
        }



        //actulizar DATOS
        public static bool actualizar(Empleado e)
        {
            try
            {
                Conexion cn = new Conexion();
                string sql = "UPDATE [dbo].[tb_empleados] SET [documento] ='" + e.Documento + "',[nombres] = '" + e.Nombres + "', [apellidos] = '" + e.Apellidos + "',[edad] =" + e.Edad + ",[direccion] = '" + e.Direccion + "' ,[fecha_nacimiento] = '" + e.Fecha_nacimiento + "' where documento= '" + e.Documento + "'" ;
                SqlCommand cmd = new SqlCommand(sql, cn.conectar());
                int cantidad = cmd.ExecuteNonQuery();

                if (cantidad == 1)
                {

                    return true;
                }
                else { 
                cn.desconectar();
                return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //eliminar DATOS
        public static bool eliminar(string documento)
        {
            try
            {
                Conexion cn = new Conexion();
                string sql = "delete from [dbo].[tb_empleados] where documento= '" + documento + "'";
                SqlCommand cmd = new SqlCommand(sql, cn.conectar());
                int cantidad = cmd.ExecuteNonQuery();

                if (cantidad == 1)
                {

                    return true;
                }
                else
                {
                    cn.desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }











    }
}
