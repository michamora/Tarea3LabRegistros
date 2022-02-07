﻿using System;
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
using Tarea3LabRegistros.UI.Registro1;
using Tarea3LabRegistros.UI.Registro2;

namespace Tarea3LabRegistros
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
   private void RegistroCarrerasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rCarreras = new rCarreras();
            rCarreras.Show();
        }


        private void RegistroEstudiantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
             var rEstudiantes = new rEstudiantes();
            rEstudiantes.Show();
        }


    }
}