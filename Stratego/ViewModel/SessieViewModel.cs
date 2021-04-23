using Stratego.Extra;
using Stratego.Extra.Messages;
using Stratego.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Stratego.ViewModel
{
    class SessieViewModel : BaseViewModel
    {
        private PageNavigationService pageNavigationService = new PageNavigationService();
        public SessieViewModel()
        {
            pageNavigationService = new PageNavigationService();
            LeesSessies();
            RefreshBorden();
            LeesPersonen();
            LeesBorden();
            KoppelenCommands();
            Messenger.Default.Register<BordUpdatedMessage>(this, OnBordReceived, "BordReceived");
            Messenger.Default.Register<PersoonUpdatedMessage>(this, OnPersoonReceived, "PersoonReceived");
        }

        private void OnBordReceived(BordUpdatedMessage message)
        {
            //Borden.Add(bord);
            LeesBorden();
        }

        private void OnPersoonReceived(PersoonUpdatedMessage message)
        {
            LeesPersonen();
        }

        private void KoppelenCommands()
        {
            //WijzigenCommand = new BaseCommand(WijzigenSessie);
            VerwijderenCommand = new BaseCommand(VerwijderenSessie);
            ToevoegenCommand = new BaseCommand(ToevoegenSessie);
            WijzigenCommand = new BaseCommand(WijzigenSessie);
            ToevoegenPersonenCommand = new BaseCommand(ToevoegenPersonenAanSessie);
            ToevoegenPersoonCommand = new BaseCommand(ToevoegenPersoon);
            NavigateToAdminCommand = new BaseCommand(AdminPagina);
            NavigateToHomeCommand = new BaseCommand(HomePagina);
            NavigateToSetupCommand = new BaseCommand(SetupPagina);
            NavigateToLeaderBoardCommand = new BaseCommand(LeaderboardPagina);
            StartGameCommand = new BaseCommand(GamePagina);
        }


        public ICommand NavigateToAdminCommand { get; set; }

        public ICommand NavigateToHomeCommand { get; set; }

        public ICommand NavigateToLeaderBoardCommand { get; set; }
        public ICommand StartGameCommand { get; set; }
        public ICommand ToevoegenPersonenCommand { get; set; }
        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand NavigateToSetupCommand { get; set; }
        public ICommand ToevoegenPersoonCommand { get; set; }

        public void AdminPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("adminpage");
        }

        public void LeaderboardPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("leaderboardpage");
        }

        public void HomePagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("homepage");
            Messenger.Default.Send<SessiesUpdatedMessage>(new SessiesUpdatedMessage());
        }

        public void SetupPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("setuppage");

            
        }

        public void GamePagina()
        {
            if (CurrentSessie.team1_Speler == null || CurrentSessie.team1_Speler == " " || CurrentSessie.team1_Speler == "" || CurrentSessie.team2_Speler == null || CurrentSessie.team2_Speler == " " || CurrentSessie.team2_Speler == "")
            {
                MessageBox.Show("Vul alles in.");
            }
            else if (CurrentSessie.team1_Speler == CurrentSessie.team2_Speler)
            {
                MessageBox.Show("Je kan niet twee dezelfde spelers selecteren.");
            }
            else
            {
                ToevoegenSessie();

                PageNavigationService pageNavigationService = new PageNavigationService();
                pageNavigationService.Navigate("gamepage");
                Messenger.Default.Send<SessiesUpdatedMessage>(new SessiesUpdatedMessage());
            }
        }

        private ObservableCollection<Sessie> sessies;

        public ObservableCollection<Sessie> Sessies
        {
            get
            {
                return sessies;
            }

            set
            {
                sessies = value;
                NotifyPropertyChanged();
            }
        }


        private void LeesSessies()
        {
            //instantiëren dataservice
            SessieDataService sessieDs =
               new SessieDataService();

            Sessies = new ObservableCollection<Sessie>(sessieDs.GetSessies());
        }

        public void RefreshBorden()
        {
            BordDataService bordenDs = new BordDataService();

            Borden = new ObservableCollection<Bord>(bordenDs.GetBorden());
        }
        //private DateTime sessieMoment = new DateTime();


       

        private Sessie currentSessie = new Sessie();
        
        

        public Sessie CurrentSessie
        {
            get
            {
                return currentSessie;
            }

            set
            {
                currentSessie = value;

                NotifyPropertyChanged();
            }
        }

        private string currentPersoonNaam;

        public string CurrentPersoonNaam
        {
            get
            {
                return currentPersoonNaam;
            }
            set
            {
                currentPersoonNaam = value;
                NotifyPropertyChanged();
            }
        }

        private string persoonNaam;
       
        public string StringPersoon
        {
            get
            {
                return persoonNaam;
            }

            set
            {
                persoonNaam = value;
            }
        }

        private Bord selectedBord { get; set; }
        public Bord SelectedBord
        {
            get
            {
                return selectedBord;
            }

            set
            {
                selectedBord = value;
                NotifyPropertyChanged();
            }
        }

        public void ToevoegenSessie()
        {
            int aanmakerID = 0;
            //CurrentSessie.SessieMoment = DateTime.Now;

            CurrentSessie.bordID = SelectedBord.ID;
            CurrentSessie.BordKleur = SelectedBord.Kleur;
            

            foreach (var item in Personen)
            {
                if (item.Naam == CurrentSessie.team1_Speler)
                {
                    CurrentSessie.persoonID = aanmakerID;
                }
            }


            if (CurrentSessie.team1_Speler == CurrentSessie.team2_Speler)
            {
                MessageBox.Show("Je kan niet twee dezelfde spelers selecteren.");
            } else if (SelectedBord == null || CurrentSessie.team1_Speler == null || CurrentSessie.team2_Speler == null)
            {
                MessageBox.Show("Je moet alle velden invullen.");
            }
            else
            {


                SessieDataService sessieDs =
                    new SessieDataService();
                sessieDs.InsertSessie(CurrentSessie);
                Messenger.Default.Send<BordUpdatedMessage>(new BordUpdatedMessage());
                //Refresh
                LeesSessies();
            }
        }

        public void WijzigenSessie()
        {


            SessieDataService sessieDs =
                new SessieDataService();
            sessieDs.UpdateSessie(CurrentSessie);
            //Messenger.Default.Send<BordUpdatedMessage>(new BordUpdatedMessage());
            //Refresh
            LeesSessies();

        }

        public void VerwijderenSessie()
        {
            if (CurrentSessie != null)
            {
                SessieDataService sessieDs =
                new SessieDataService();
                sessieDs.DeleteSessie(CurrentSessie);
                Messenger.Default.Send<BordDeletionMessage>(new BordDeletionMessage());
                //Refresh
                LeesSessies();
            }

        }


        private Persoon nieuwePersoon = new Persoon();

        public Persoon NieuwePersoon
        {
            get
            {
                return nieuwePersoon;
            }

            set
            {
                nieuwePersoon = value;
                NotifyPropertyChanged();
            }
        }

        private Persoon nieuwePersoon2 = new Persoon();

        public Persoon NieuwePersoon2
        {
            get
            {
                return nieuwePersoon2;
            }

            set
            {
                nieuwePersoon2 = value;
                NotifyPropertyChanged();
            }
        }

        public void ToevoegenPersonenAanSessie()
        {
            PersoonDataService persoonDs =
               new PersoonDataService();
            persoonDs.ToevoegenPersoon(NieuwePersoon);

            persoonDs.ToevoegenPersoon(NieuwePersoon2);
            //Refresh
            LeesPersonen();
        }

        public void ToevoegenPersoon()
        {
            PersoonDataService persoonDs =
                new PersoonDataService();
            persoonDs.ToevoegenPersoon(NieuwePersoon);

            //Refresh
            LeesPersonen();

        }

        private ObservableCollection<Persoon> personen;
        public ObservableCollection<Persoon> Personen
        {
            get
            {
                return personen;
            }

            set
            {
                personen = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Bord> borden;
        public ObservableCollection<Bord> Borden
        {
            get
            {
                return borden;
            }

            set
            {

                borden = value;
                NotifyPropertyChanged();
            }
        }



        private void LeesBorden()
        {
            //instantiëren dataservice
            BordDataService bordDS =
                new BordDataService();

            Borden = new ObservableCollection<Bord>(bordDS.GetBorden());
        }



        private void LeesPersonen()
        {
            //instantiëren dataservice
            PersoonDataService contactDS =
               new PersoonDataService();

            Personen = new ObservableCollection<Persoon>(contactDS.GetPersonen());
            
        }



        private Persoon persoon1;
        public Persoon SelectedPersoon1
        {
            get
            {
                return persoon1;
            }

            set
            {
                persoon1 = value;
                

                NotifyPropertyChanged();
            }
        }

        private Persoon persoon2;
        public Persoon SelectedPersoon2
        {
            get
            {
                return persoon2;
            }

            set
            {
                persoon2 = value;
                NotifyPropertyChanged();
            }
        }

    }
}
