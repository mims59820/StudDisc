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
        Personne p;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text !="" && textBoxMdp.Text !="")
            {

                Personne p = new Personne().Connexion(textBoxEmail.Text, textBoxMdp.Text);
                if (p != null)
                {
                    ActuWindow fenetre = new ActuWindow(p.Id);
                  
                    this.Close();
                    fenetre.Show();
                }
                else
                {
                    MessageBox.Show("Mot de passe et/ou email invalide", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }

            }
            else
            {
                MessageBox.Show("Veuillez remplir le mot de passe et l'émail", "Erreur saisie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

      
    }
}



