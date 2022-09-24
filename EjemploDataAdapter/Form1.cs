using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploDataAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conexion = "Server=192.168.1.253;Database=Instituto X;User=Pepe;Password=123456";
            SqlConnection con = new SqlConnection(conexion);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM estudiante",con);

            //Desde acá es un trabajo local.
            //Crear un objeto del tipo tabla
            DataTable dt = new DataTable();
            da.Fill(dt);
            //¿Cómo iteramos sobre los registros de la tabla?
            foreach (DataRow fila in dt.Rows) {
                Console.WriteLine(fila["ci"] + ", " + fila[1] + " " + fila["apellido"]);
            }

            //Para trabajar con un conjunto de tablas usamos DataSet
            DataSet ds = new DataSet();
            da.Fill(ds, "estudiante");//A estas alturas, el DataSet podría contener multiples tablas

            foreach (DataRow fila in ds.Tables["estudiante"].Rows) {
                Console.WriteLine(fila["ci"] + ", " + fila[1] + " " + fila["apellido"]);
            }


            //También podemos obtener el resultado de la ejecución de un Stored Procedure
            SqlDataAdapter da2 = new SqlDataAdapter("obtenerMejoresEstudiantes", con);

            //Contamos con otras sobrecargas del constructor SqlDataAdapter
            SqlDataAdapter da3 = new SqlDataAdapter();
            SqlDataAdapter da4 = new SqlDataAdapter(new SqlCommand("SELECT * FROM telefono",con));
            SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM estudiante", "Server=192.168.1.253;Database=Instituto X;User=Pepe;Password=123456");

        }
    }
}
