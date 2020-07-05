using RegistroPedidosDetalle.BLL;
using RegistroPedidosDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroPedidosDetalle.UI.Registros
{
    /// <summary>
    /// Interaction logic for rSuplidores.xaml
    /// </summary>
    public partial class rSuplidores : Window
    {
        public rSuplidores()
        {
            InitializeComponent();
            idTextBox.Text = "0";
        }

        private void LimpiarCampos()
        {
            nombreTextBox.Text = string.Empty;
            idTextBox.Text = "0";
        }


        private Suplidores LlenaClase()
        {
            Suplidores suplidores = new Suplidores();

            suplidores.ClienteId = Convert.ToInt32(idTextBox.Text);
            suplidores.Nombre = nombreTextBox.Text;


            return suplidores;
        }

        private void LlenaCampo(Suplidores suplidores)
        {

            idTextBox.Text = Convert.ToString(suplidores.ClienteId);
            nombreTextBox.Text = suplidores.Nombre;


        }

        private bool VerificarExistencia()
        {
            Suplidores suplidores = SuplidorBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
            return (suplidores != null);
        }

        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                MessageBox.Show("Llenar Campo Nombre!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }



            return paso;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            Suplidores suplidores;
            bool paso = false;

            if (!ValidarCampos())
                return;

            suplidores = LlenaClase();

            if (Convert.ToInt32(idTextBox.Text) == 0)
                paso = SuplidorBLL.Guardar(suplidores);

            else
            {
                if (!VerificarExistencia())
                {
                    MessageBox.Show("Cliente No Existe!!");
                }

                paso = SuplidorBLL.Modificar(suplidores);
            }

            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al Guardar!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(idTextBox.Text, out id);

            if (SuplidorBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se Elimino!!");
            }
        }



        private void buscarButton1_Click(object sender, RoutedEventArgs e)
        {
            int id;

            Suplidores suplidores = new Suplidores();
            int.TryParse(idTextBox.Text, out id);


            suplidores = SuplidorBLL.Buscar(id);

            if (suplidores != null)
            {
                MessageBox.Show("Esncotrado!!");
                LlenaCampo(suplidores);
            }
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }
    }
}
