﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudDisc.ViewModels
{
    class ThematiqueViewModel : ViewModelBase
    {
        private Personne personne;
        private Thematique thematique;
        private string listboxselected;
        private List<string> listeChoix;
        private ObservableCollection<Thematique> listechoixThematique;
        private List<Publication> listeChoixPublications;
        private Thematique thematiqueSelectionne;
        private string contenu;


        public ThematiqueViewModel(int IdUtilisateur)
        {
            AllThematiques = new ObservableCollection<Thematique>(Thematique.All());
            MesThematiques = new ObservableCollection<Thematique>(Thematique.MyAll(IdUtilisateur));
            MesIntervention = new ObservableCollection<Thematique>(Thematique.MyAllIntervention(IdUtilisateur));
            Personne = Personne.GetOne(IdUtilisateur);
            ListechoixThematique = AllThematiques;
            AjoutTitre = new RelayCommand(ActionValidCommand);
            AjoutContenu = new RelayCommand(ActionAjoutContenu);
            ListeChoix = new List<string>();
            ListeChoix.Add("Toutes les thématiques");
            ListeChoix.Add("Mes interventions");
            ListeChoix.Add("Mes Thématiques créées");
            Listboxselected = "Toutes les thématiques";
        }


        public ICommand AjoutTitre { get; set; }
        public ICommand AjoutContenu { get; set; }
        public string Contenu
        {
            get => contenu; set
            {
                contenu = value;
                RaisePropertyChanged("Contenu");
            }
        }



        public ObservableCollection<Thematique> AllThematiques { get; set; }
        public ObservableCollection<Thematique> MesThematiques { get; set; }
        public ObservableCollection<Thematique> MesIntervention { get; set; }
        public ObservableCollection<Thematique> ListechoixThematique { get => listechoixThematique; set => listechoixThematique = value; }
        public List<Publication> ListeChoixPublications { get => listeChoixPublications; set => listeChoixPublications = value; }



        public string Titre { get; set; }

        public Thematique Thematique
        {
            get => thematique;
            set
            {
                thematique = value;
                if (thematique != null)
                {

                }
                RaisePropertyChanged("Thematique");
            }
        }

     




        public int IdThematique
        {
            get => thematique.Id;
            set
            {
                thematique.Id = value;
                RaisePropertyChanged();
            }
        }


        public string TitreThematique
        {
            get => thematique.Titre;
            set
            {
                thematique.Titre = value;
                RaisePropertyChanged();
            }
        }


        public DateTime DateThematique
        {
            get => thematique.Date;
            set
            {
                thematique.Date = value;
                RaisePropertyChanged();
            }
        }

        public int IdUtilisateurThematique
        {
            get => thematique.IdUtilisateur;
            set
            {
                thematique.IdUtilisateur = value;
                RaisePropertyChanged();
            }
        }

        public List<string> ListeChoix
        {
            get => listeChoix; set
            {
                listeChoix = value;

            }
        }

        public string Listboxselected
        {
            get
            {

                return listboxselected;
            }
            set
            {
                listboxselected = value;
                if (listboxselected == ListeChoix[0])
                {
                    ListechoixThematique = AllThematiques;

                }
                else if (listboxselected == ListeChoix[1])
                {
                    ListechoixThematique = MesIntervention;

                }
                else if (listboxselected == ListeChoix[2])
                {
                    ListechoixThematique = MesThematiques;

                }
                thematiqueSelectionne = null;
                ListeChoixPublications = null;
                RaisePropertyChanged("ListeChoixPublications");
                RaisePropertyChanged("ThematiqueSelectionne");
                RaisePropertyChanged("ListechoixThematique");
                RaisePropertyChanged("Listboxselected");

            }
        }

        public Thematique ThematiqueSelectionne
        {
            get => thematiqueSelectionne;
            set
            {
                thematiqueSelectionne = value;
                ListeChoixPublications = Publication.AllByTheme(ThematiqueSelectionne.Id);
                RaisePropertyChanged("ListeChoixPublications");
                RaisePropertyChanged("ThematiqueSelectionne");
                /*thematiqueSelectionne = null;*/

            }
        }

        public Personne Personne
        {
            get => personne; 
            set
            {
                personne = value;
                RaisePropertyChanged("Personne");
            }
        }

        private void ActionValidCommand()
        {

            if (Titre != "")
            {
                if (Thematique.GetOneByTitre(Titre) > 0)
                {
                    MessageBox.Show("Une thématique existe déja avec ce Titre", "Erreur titre", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    Thematique t = new Thematique(Titre, DateTime.Now, Personne.Id);
                    int idthematique = t.Add();

                    if (idthematique > 0)
                    {
                        t.Id = idthematique;
                        PersonneThematique pt = new PersonneThematique(Personne.Id, idthematique);
                        if (pt.add())
                        {
                            MessageBox.Show("Thematique Ajouté", "Ajout Thématique", MessageBoxButton.OK, MessageBoxImage.Information);
                            Titre = "";
                            AllThematiques.Add(t);
                            MesThematiques.Add(t);
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ajout thématique échoué", "Erreur Ajout", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            else
            {
                MessageBox.Show("Veuillez saisir un titre", "Erreur titre", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            Titre = "";
            RaisePropertyChanged("Titre");

        }


        private void ActionAjoutContenu()
        {
            if (ThematiqueSelectionne != null && Contenu != null)
            {
                Publication publication = new Publication(ThematiqueSelectionne.Id, Personne.Id, Contenu, DateTime.Now);
                if (publication.Add() > 0)
                {
                    MessageBox.Show("Publication ajouté","Ajout publication",MessageBoxButton.OK,MessageBoxImage.Information);
                    Contenu = null;
                    ListeChoixPublications = Publication.AllByTheme(ThematiqueSelectionne.Id);
                    RaisePropertyChanged("ListeChoixPublications");
                    RaisePropertyChanged("ListeChoixPublications");
                    RaisePropertyChanged("Contenu");
                }
            }
            else if (ThematiqueSelectionne == null)
            {
                MessageBox.Show("Veuillez selectionner une thématique", "Erreur Selection Thématique",MessageBoxButton.OK,MessageBoxImage.Information);
            }else if(Contenu != null)
            {
                MessageBox.Show("Votre saisi est vide");
            }
        }







    }
}
