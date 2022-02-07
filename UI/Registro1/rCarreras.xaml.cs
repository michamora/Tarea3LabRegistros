using System.Windows;
using Tarea3LabRegistros.Entidades;
using Tarea3LabRegistros.BLL;

namespace Tarea3LabRegistros.UI.Registro1
{
    public partial class rCarreras : Window
    {
        private Carreras Carrera = new Carreras();

        public rCarreras()
        {
            InitializeComponent();

            this.DataContext = Carrera;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Carrera;
        }

        private void Limpiar()
        {
            this.Carrera = new Carreras();
            this.DataContext = Carrera;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(Carrera.Nombre))
            {
                esValido = false;
                NombreTextBox.Focus();
                MessageBox.Show("Debe indicar el nombre!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(Carrera.Nombre))
            {
                esValido = false;
                NombreTextBox.Focus();
                MessageBox.Show("Debe indicar el nombre!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = CarrerasBLL.Buscar(this.Carrera.CarreraId);

            if (encontrado != null)
            {
                this.Carrera = encontrado;
                Cargar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro la carrera!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            paso = CarrerasBLL.Guardar(Carrera);

            if (paso)
                MessageBox.Show("Carrera guardada con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarrerasBLL.Eliminar(Carrera.CarreraId))
            {
                Limpiar();
                MessageBox.Show("Carrera eliminada con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {

        }
         private void ValidarButton_Click(object sender, RoutedEventArgs e)
        {
            Validar();
            
        }
    }
}