using StudDisc.Models;
using StudDisc.ViewModels;
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

namespace StudDisc.Views
{
    /// <summary>
    /// Logique d'interaction pour IndexWindow.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow()
        {
            InitializeComponent();
            DataContext = new PersonneViewModel();
        }

       
    }
}
