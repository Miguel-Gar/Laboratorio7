using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laboratorio7
{
    public partial class Form1 : Form
    {
        List<Propiedades> casas = new List<Propiedades>();
        List<Propietarios> personas = new List<Propietarios>();
        List<Datos> dato = new List<Datos>();
        public Form1()
        {
            InitializeComponent();
        }
        private void GuardarPerosnas(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in personas)
            {
                writer.WriteLine(p.DPI);
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.Apellido);
            }
            writer.Close();
        }
        private void GuardarCasas(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in casas)
            {
                writer.WriteLine(p.No_casa);
                writer.WriteLine(p.DpiPropietario);
                writer.WriteLine(p.Cuota);
            }
            writer.Close();
        }
        private void GuardarDatos(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in dato)
            {
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.Apellido);
                writer.WriteLine(p.No_casa);
                writer.WriteLine(p.Cuota);
            }
            writer.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Datos er = new Datos();
            er.Nombre = textBox2.Text;
            er.Apellido = textBox3.Text;
            er.No_casa = Convert.ToInt32(textBox6.Text);
            er.Cuota = Convert.ToInt32(textBox4.Text);
            dato.Add(er);
            //GuardarCasas("Casas.txt");
            //GuardarPerosnas("Personas.txt");
            mostrar();
        }
        private void mostrar()
        {
            GuardarDatos("Datos.txt");
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = dato;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dato = dato.OrderByDescending(p => p.Cuota).ToList();
            mostrar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //boton de ordenar
            Datos mayor = dato.OrderByDescending(al => al.Cuota).First();
            int p = 0;
            if (p==-0)
            {
                //dato = dato.OrderByDescending(p => p.Cuota).ToList();
                textBox7.Text = dato[p].Nombre.ToString() + " -- " + dato[p].Apellido.ToString() + " -- " + dato[p].No_casa.ToString() + " -- " + dato[p].Cuota.ToString();
                mostrar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
