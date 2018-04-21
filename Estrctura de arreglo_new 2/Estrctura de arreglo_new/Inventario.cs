using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estrctura_de_arreglo_new
{
    class Inventario
    {
        bool _validar;
       public bool validar { get { return _validar; } }
        int _cantidad;
        int _posicion;
        string Datos = "";
        public int posicion { get { return _posicion; } set { _posicion = value; } }

        Carro[] lisCarro = new Carro[15];
        public int cantidad { get { return _cantidad; } }
        public Inventario()
        {
            _cantidad = 0;
            _posicion = 0;
            //lisCarro = null;
        }

        public void Agregar(Carro Carr)
        {

            if (_cantidad < 14)
            {
                Ordenado(Carr);
                _cantidad++;
                MessageBox.Show("Agregado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
            else if (_cantidad == 14)
            {
                //MessageBox.Show("Insuficiente", "Espacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Ordenado(Carr);
                MessageBox.Show("Agregado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Insuficiente", "Espacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           

        }
        public void Ordenado(Carro temp)
        {
            int a=0;
            while (a<=_cantidad) {
                if (lisCarro[a] != null) {

                    if (temp.placa.CompareTo(lisCarro[a].placa) < 0)
                    {
                        for (int l = _cantidad; l > a; l--)
                        {
                            lisCarro[l] = lisCarro[l - 1];
                           
                        }
                        lisCarro[a] = temp;
                        a = _cantidad;
                    }
                }
                else
                {
                    lisCarro[a] = temp;
                }
                a++;
            }
        }
        private void Mover()
        {
            for (int a = _cantidad; a > _posicion; a--)
            {
                lisCarro[a] = lisCarro[a - 1];
            }
        }
        public void Eliminar(string placa)
        {
            Buscar(placa);
            if (_validar)
            {
                if (lisCarro[_posicion] != null)
                {
                    Carro vacio = new Carro();
                    lisCarro[_posicion] = vacio;
                    MoverBorrar();
                    _cantidad--;
                    MessageBox.Show("Borrado con exito", "Exito", MessageBoxButtons.OK);

                }

               
            }
            else
            {
                MessageBox.Show("Carro no encontrado", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void MoverBorrar()
        {

            for (int a = _posicion; a < _cantidad; a++)
            {

                lisCarro[a] = lisCarro[a + 1];
            }
        }
        public void Lista()
        {
            Datos = "";
            for (int a = 0; a <= (_cantidad - 1); a++)
            {
                Datos += (a + 1) + "._\t" + lisCarro[a].ToString() + Environment.NewLine;
            }
        }
        public Carro Buscar(string placa)
        {


            _validar = false;
            int a = 0;
            while (_validar == false && a < _cantidad)
            {
                if (lisCarro[a] != null)
                {
                    if ((placa.CompareTo(lisCarro[a].placa) == 0))
                    {
                        _validar = true;
                        _posicion = a;

                        return lisCarro[a];
                    }
                    else if((placa.CompareTo(lisCarro[a].placa) < 0))
                    {
                        return null;
                    }

                }
                
                a++;
            }
            return null;
        }
        

   
        public override string ToString()
        {
            return Datos;
        }
    }

}

