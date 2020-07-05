using RegistroPedidosDetalle.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroPedidosDetalle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            rSuplidores registro = new rSuplidores();
            registro.ShowDialog();
        }

        private void RegistrarProducto_Click(object sender, RoutedEventArgs e)
        {
            rProductos registro = new rProductos();
            registro.ShowDialog();
        }

        private void RegistrarOrden_Click(object sender, RoutedEventArgs e)
        {
            rOrdenes registro = new rOrdenes();
            registro.ShowDialog();
        }
    }
}
