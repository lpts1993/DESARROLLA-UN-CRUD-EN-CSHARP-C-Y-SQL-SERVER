using System.Data;
using WinFormsApp1.Datos;
using WinFormsApp1.modelo;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //boton guardar
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("debe ingresar un documento valido");
            }
            else if (textBox2.Text.Trim().Length < 2)
            {
                MessageBox.Show("debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Apellidos = textBox3.Text.Trim().ToUpper();
                    em.Nombres = textBox2.Text.Trim().ToUpper();
                    em.Direccion = textBox5.Text.Trim().ToUpper();
                    em.Documento = textBox1.Text.Trim().ToUpper();
                    em.Edad = Convert.ToInt32(textBox4.Text.Trim());
                    em.Apellidos = textBox3.Text.Trim().ToUpper();
                    em.Fecha_nacimiento = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;

                    if (EmpleadoCAD.guardar(em))
                    {
                        llenartabla();
                        limpiarcampos();
                        MessageBox.Show("Datos guardados");
                    }
                    else
                    {
                        MessageBox.Show("Empleado ya existe");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        //limpiar campos
          private void limpiarcampos() 
            {
                textBox3.Clear();
                textBox2.Clear();
                textBox5.Clear();
                textBox1.Clear();
            textBox4.Clear();
                dateTimePicker1.ResetText();
            }
        //la tabla 
        private void llenartabla() 
            {
                 DataTable dato= EmpleadoCAD.lISTAR();
            if (dato == null)
            {
                MessageBox.Show("No se accedio a la informacion");
            }
            else
            { 
            dataGridView1.DataSource = dato.DefaultView;
            }

            
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenartabla();
        }


       bool consultado = false ;
        private void button2_Click(object sender, EventArgs e)
        {
            //consultar
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("debe ingresar un documento valido");
                
            }
            else 
            {
                Empleado em = EmpleadoCAD.consultar(textBox1.Text.Trim());
                if (em == null)
                {
                    MessageBox.Show("No exite el empleado con documento"+textBox1.Text);
                    limpiarcampos();
                    consultado = false  ;
                }
                else
                {
                    textBox3.Text =em.Apellidos;
                    textBox2.Text = em.Nombres;
                    textBox5.Text = em.Direccion;
                    textBox4.Text = em.Edad.ToString();
                    
                    dateTimePicker1.Text = em.Fecha_nacimiento;
                    consultado = true;

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //boton editar
            if (consultado == false)
            {
                MessageBox.Show("debe consultar el empleado");
            }

            else if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("debe ingresar un documento valido");
            }

            else if (textBox2.Text.Trim().Length < 2)
            {
                MessageBox.Show("debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Apellidos = textBox3.Text.Trim().ToUpper();
                    em.Nombres = textBox2.Text.Trim().ToUpper();
                    em.Direccion = textBox5.Text.Trim().ToUpper();
                    em.Documento = textBox1.Text.Trim().ToUpper();
                    em.Edad = Convert.ToInt32(textBox4.Text.Trim());
                    em.Apellidos = textBox3.Text.Trim().ToUpper();
                    em.Fecha_nacimiento = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;

                    if (EmpleadoCAD.actualizar(em))
                    {
                        llenartabla();
                        limpiarcampos();
                        MessageBox.Show("Datos actualizado correctamente");
                        consultado=false;
                    }
                    else
                    {
                        MessageBox.Show("No se logro actualizar ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //boton eliminar
            if (consultado == false)
            {
                MessageBox.Show("debe consultar el empleado");
            }

            else if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("debe ingresar un documento valido");
            }

            else if (DialogResult.Yes == MessageBox.Show(null,"desea eliminar el registro","Confirmacion", MessageBoxButtons.YesNo))
            {
                try
                {
                    
                    if (EmpleadoCAD.eliminar(textBox1.Text.Trim()))
                    {
                        llenartabla();
                        limpiarcampos();
                        MessageBox.Show("Datos eliminado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se elimino ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}