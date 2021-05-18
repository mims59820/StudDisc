using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudDisc.ViewModels
{
    class PersonneViewModel : ViewModelBase
    {

        private string password;

        public string Password { get => password; set => Set(ref password, value); }
        private Personne personne;

        public int Id { get => personne.Id; set { personne.Id = value; RaisePropertyChanged(); } }

        public string Nom { get => personne.Nom; set { personne.Nom = value; RaisePropertyChanged(); } }
        public string Prenom { get => personne.Prenom; set { personne.Prenom = value; } }
        public string Email { get => personne.Email; set { personne.Email = value; } }
        public string Mdp { get => personne.Mdp; set { personne.Mdp = value; RaisePropertyChanged(); } }
        public string Role { get => personne.Role.ToString(); set { personne.Role = TypeUtilisateur.Visiteur; RaisePropertyChanged(); } }
        public ICommand Connexion { get; set; }
        public ICommand AjoutCommand { get; set; }




        public PersonneViewModel()
        {
            personne = new Personne();
            /*Connexion = new RelayCommand(ActionConnexion);*/
            AjoutCommand = new RelayCommand(ActionAjoutCommand);
        }




       /* private void ActionConnexion()
        {
            bool ok = false;
            foreach (Personne p in personne.All())
            {
                if (p.Email == Email && p.Mdp == Mdp)
                {
                    ok = true;
                }
            }

            if (ok) MessageBox.Show("ok");
            else MessageBox.Show("Mot de passdsfdsfteste de moi et abdere et/ou adresse email invalide", "Erreur connexion", MessageBoxButton.OK, MessageBoxImage.Error);
        }*/

        private void ActionAjoutCommand()
        {
            if (Nom != null && Prenom != null && Email != null && Mdp != null)
            {
                MessageBox.Show("Tout les champs remplis");
            }
            else
            {
                MessageBox.Show("Remplir tout les chamsp");
            }

        }



    }
}
