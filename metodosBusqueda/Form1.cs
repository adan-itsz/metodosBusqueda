using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace metodosBusqueda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("","");
        }
        int cantidadElementos;
        int conta = 0;
        int[] array;
        int numBuscar;


        private void btnElementos_Click(object sender, EventArgs e)
        {
            try
            {
                cantidadElementos = Convert.ToInt32(txtCantidad.Text);
                array = new int[cantidadElementos];
                for (int i = 0; i < array.Length - 1; i++)
                {
                    dataGridView1.Rows.Add();
                }
                txtCantidad.Clear();
                txtAgregar.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Llenar correctamente");
            }
        }

        private void button1_Click(object sender, EventArgs e)// agregar numero
        {
            try
            {
                if (conta < array.Length)
                {
                    if (conta == 0)
                    {
                        dataGridView1[0, conta].Value = txtAgregar.Text;
                        array[conta] = Convert.ToInt32(txtAgregar.Text);
                        MessageBox.Show("agregado correctamente");
                        txtAgregar.Clear();
                        txtAgregar.Focus();
                        conta++;
                    }
                    else
                    {
                        if (Convert.ToInt32(txtAgregar.Text) > array[conta - 1])
                        {
                            array[conta] = Convert.ToInt32(txtAgregar.Text);
                            dataGridView1[0, conta].Value = txtAgregar.Text;
                            MessageBox.Show("agregado correctamente");
                            txtAgregar.Clear();
                            txtAgregar.Focus();
                            conta++;
                        }
                        else
                        {
                            MessageBox.Show("debe colocar un numero mayor al anterior");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("el arreglo se llenó");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Llenar correctamente");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSecuencial.Text= Convert.ToString (busquedaSecuencial());
            txtBinaria.Text= Convert.ToString (busquedaBinaria());

        }
        public int busquedaSecuencial()
        {
            int i = 0;
           numBuscar= Convert.ToInt32 (txtBuscar.Text);
            for ( ; i < array.Length; i++)
            {
                if (array[i] == numBuscar)
                {
                    i++;
                    MessageBox.Show("el numero" + numBuscar + " " + " si se encuentra");
                    return i;
                }
                else
                {
                    
                }
                
            }
            MessageBox.Show(" no se encontro el numero");
            return i;
        }
        public int busquedaBinaria()
        {
            numBuscar= Convert.ToInt32 (txtBuscar.Text);
            int inicio=0;
            int fin = array.Length -1;
            int centro;
            int contador=0;
            while (inicio <= fin)
            {
                centro = (inicio + fin) / 2;
                if (numBuscar == array[centro])
                {
                    contador++;
                    MessageBox.Show("el numero" + numBuscar + " " + " si se encuentra");
                    return contador;
 
                }
                else
                {
                    if (numBuscar > array[centro])
                    {
                        inicio = centro + 1;
                    }
                    else
                    {
                        fin = centro - 1;
                    }
                }
                contador++;
            }
           
            MessageBox.Show(" no se encontro el numero");
            return contador;
        }
    }
}
