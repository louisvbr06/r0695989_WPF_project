using Stratego.Extra;
using Stratego.Extra.Messages;
using Stratego.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stratego.ViewModel
{
    public class PersoonViewModel: BaseViewModel
    {

        private PageNavigationService pageNavigationService = new PageNavigationService();
        public PersoonViewModel()
        {
            pageNavigationService = new PageNavigationService();
            LeesPersonen();            
            KoppelenCommands();
            Messenger.Default.Register<ScoreUpdatedMessage>(this, OnScoreReceived, "BordReceived");
        }

        private void OnScoreReceived(ScoreUpdatedMessage message)
        {
            //Borden.Add(bord);
            LeesPersonen();
        }

        private void KoppelenCommands()
        {
            NavigateToHomeCommand = new BaseCommand(HomePagina);
            NavigateToLeaderBoardCommand = new BaseCommand(LeaderboardPagina);
            NavigateToNewGameCommand = new BaseCommand(NewGamePagina);
            NavigateToAdminCommand = new BaseCommand(AdminPagina);
            VerwijderenCommand = new BaseCommand(VerwijderenPersoon);
            ToevoegenCommand = new BaseCommand(ToevoegenPersoon);
            WijzigenCommand = new BaseCommand(WijzigenPersoon);
        }

        public ICommand NavigateToHomeCommand { get; set; }
        public ICommand NavigateToLeaderBoardCommand { get; set; }
        public ICommand NavigateToNewGameCommand { get; set; }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand NavigateToAdminCommand { get; set; }

        public void HomePagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("homepage");
        }
        public void LeaderboardPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("leaderboardpage");
        }

        public void NewGamePagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("setuppage");
        }

        public void AdminPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("adminpage");
        }

        private Persoon currentPersoon = new Persoon();
        public Persoon CurrentPersoon
        {
            get
            {
                return currentPersoon;
            }

            set
            {
                currentPersoon = value;
                NotifyPropertyChanged();
            }
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

        private void LeesPersonen()
        {
            //instantiëren dataservice
            PersoonDataService contactDS =
               new PersoonDataService();

            Personen = new ObservableCollection<Persoon>(contactDS.GetPersonen());
        }

        public void ToevoegenPersoon()
        {
            PersoonDataService persoonDS =
                new PersoonDataService();
            persoonDS.ToevoegenPersoon(CurrentPersoon);

            Messenger.Default.Send<PersoonUpdatedMessage>(new PersoonUpdatedMessage());

            //Refresh
            LeesPersonen();

        }

       
        public void VerwijderenPersoon()
        {
            if (CurrentPersoon != null)
            {
                PersoonDataService persoonDs =
                    new PersoonDataService();
                persoonDs.DeletePersoon(CurrentPersoon);

                //Refresh
                LeesPersonen();
            }

        }

        public void WijzigenPersoon()
        {
            if (CurrentPersoon != null)
            {
                PersoonDataService persoonDS =
                new PersoonDataService();
                persoonDS.UpdatePersoon(CurrentPersoon);

                

                //Refresh
                LeesPersonen();
            }

        }

       

        //public ICommand VerwijderenCommand { get; set; }
        //public ICommand WijzigenCommand { get; set; }
        //public ICommand ToevoegenCommand { get; set; }

        //private void LeesPersonen()
        //{
        //    //instantiëren dataservice
        //    PersoonDataService contactDS =
        //       new PersoonDataService();

        //    Personen = new ObservableCollection<Persoon>(contactDS.GetPersonen());
        //}

       

        //public void ToevoegenPersoon()
        //{
        //    PersoonDataService contactDS =
        //        new PersoonDataService();
        //    contactDS.InsertPersoon(CurrentPersoon);

        //    //Refresh
        //    LeesPersonen();

        //}


        //public void VerwijderenPersoon()
        //{
        //    if (CurrentPersoon != null)
        //    {
        //        PersoonDataService contactDS =
        //            new PersoonDataService();
        //        contactDS.DeletePersoon(CurrentPersoon);

        //        //Refresh
        //        LeesPersonen();
        //    }

        //}
    }
}
