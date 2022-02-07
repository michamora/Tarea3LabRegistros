using System.Windows;
using Tarea3LabRegistros.Entidades;
using Tarea3LabRegistros.BLL;

namespace Tarea3LabRegistros.UI.Registro2
{
    public partial class rEstudiantes : Window
    {
        private Estudiantes Estudiante = new Estudiantes();

        public rEstudiantes()
        {
            InitializeComponent();

            this.DataContext = Estudiante;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Estudiante;
        }

        private void Limpiar()
        {
            this.Estudiante = new Estudiantes();
            this.DataContext = Estudiante;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(Estudiante.Nombres))
            {
                esValido = false;
                NombresTextBox.Focus();
                MessageBox.Show("Debe indicar los nombres!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           else if (string.IsNullOrWhiteSpace(Estudiante.Email))
            {
                esValido = false;
                EmailTextBox.Focus();
                MessageBox.Show("Debe indicar el Email!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = EstudiantesBLL.Buscar(this.Estudiante.EstudianteId);

            if (encontrado != null)
            {
                this.Estudiante = encontrado;
                Cargar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el estudiante!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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

            paso = EstudiantesBLL.Guardar(Estudiante);

            if (paso)
                MessageBox.Show("Estudiante guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar el Estudiante", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(Estudiante.EstudianteId))
            {
                Limpiar();
                MessageBox.Show("Estudiante eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar el Estudiante", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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