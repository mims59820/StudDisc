﻿using StudDisc.Models;
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
    /// Logique d'interaction pour ActuWindow.xaml
    /// </summary>
    public partial class ActuWindow : Window
    {
       

        public ActuWindow(int nbrId)
        {
            InitializeComponent();
            DataContext = new ThematiqueViewModel(nbrId);
           
        }

        private void GridViewColumn_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
