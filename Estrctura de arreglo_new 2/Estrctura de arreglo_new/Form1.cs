using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estrctura_de_arreglo_new
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Inventario inventario = new Inventario();
        Carro carronew;
       
        private void btnAgregar_Click(object sender, EventArgs e)
        { carronew=new Carro();
           // txtPosicion.Value = inventario.cantidad + 2;
            if (inventario.cantidad<15) {
                leer();

                inventario.Buscar(carronew.placa);
                if (inventario.validar) {
                    MessageBox.Show("Placas iguales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    inventario.Agregar(carronew);
                }
            }
            else
            {
                MessageBox.Show("LLeno", "Espacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            inventario.Lista();
          txtList.Text= inventario.ToString();
    //        txtPosicion.Value = inventario.cantidad + 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
            Carro tem;
            tem = inventario.Buscar(placa);
            if (tem != null)
            {
                

                txtList.Text = tem.ToString();
            }
            else
            {
                MessageBox.Show("Carro no encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void Borrar()
        {
            txtModelo.Clear();
            txtFecha.Clear();
            txtPlaca.Clear();
            txtTelefono.Clear();

        }
        private void leer()
        {
           
            carronew.modelo = txtModelo.Text;
            carronew.fecha = txtFecha.Text;
            carronew.placa = txtPlaca.Text;
            carronew.telefono = txtTelefono.Text;
          
        }
    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
           /// inventario.posicion = Convert.ToInt16(txtPosicion.Value) - 1;

            inventario.Eliminar(placa);
        }
    }
}
