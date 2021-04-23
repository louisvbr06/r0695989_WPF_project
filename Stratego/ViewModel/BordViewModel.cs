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
using System.Windows.Media;

namespace Stratego.ViewModel
{
    class BordViewModel: BaseViewModel
    {


        private PageNavigationService pageNavigationService = new PageNavigationService();
        public BordViewModel()
        {
            pageNavigationService = new PageNavigationService();
            LeesBorden();           
            KoppelenCommands();
            LeesSessies();
            Messenger.Default.Register<BordUpdatedMessage>(this, OnBordReceived, "BordReceived");
        }

        private void OnBordReceived(BordUpdatedMessage message)
        {
            //Borden.Add(bord);
            LeesBorden();
            LeesSessies();
        }

        private void KoppelenCommands()
        {
            NavigateToLeaderBoardCommand = new BaseCommand(LeaderboardPagina);
            NavigateToAdminCommand = new BaseCommand(AdminPagina);
            VerwijderenCommand = new BaseCommand(VerwijderenBord);
            ToevoegenCommand = new BaseCommand(ToevoegenBord);
            WijzigenCommand = new BaseCommand(WijzigenBord);
        }

        public ICommand NavigateToLeaderBoardCommand { get; set; }

        public ICommand NavigateToAdminCommand { get; set; }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

        public void LeaderboardPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("leaderboardpage");
        }

        public void AdminPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("adminpage");
        }

        private Bord currentBord = new Bord();
        public Bord CurrentBord
        {
            get
            {
                return currentBord;
            }

            set
            {
                currentBord = value;
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
            isReferencedOrNot = 0;
            Sessies = new ObservableCollection<Sessie>(sessieDs.GetSessies());
        }


        public void LeesBorden()
        {
            //instantiëren dataservice
            BordDataService bordDS =
                new BordDataService();

            Borden = new ObservableCollection<Bord>(bordDS.GetBorden());
        }

        public void ToevoegenBord()
        {
            BordDataService bordDS =
                new BordDataService();
            bordDS.ToevoegenBord(CurrentBord);
            Messenger.Default.Send<BordUpdatedMessage>(new BordUpdatedMessage());


            //Refresh
            LeesBorden();

        }

        

        private int isReferencedOrNot = 0;

        public int IsReferencedOrNot
        {
            get
            {
                return isReferencedOrNot;
            }

            set
            {
                isReferencedOrNot = value;
                NotifyPropertyChanged();
            }
        }

        //public void ReferentieControle(Bord ClickedBord)
        //{
        //    foreach (var item in Sessies)
        //    {
        //        if (item.bordID.Equals(ClickedBord.ID))
        //        {
        //        isReferencedOrNot ++;
        //        }
        //    }
            
              
            
        //}

        public void VerwijderenBord()
        {
            //ReferentieControle(CurrentBord);

            try
            {
                Messenger.Default.Send<Bord>(CurrentBord);
                BordDataService bordDS =
                    new BordDataService();
                bordDS.DeleteBord(CurrentBord);

                //Messenger.Default.Send<Bord>(CurrentBord);
                //Refresh
                LeesBorden();
            }
            catch (Exception sqlEx)
            {
                MessageBox.Show("Bord wordt in een sessie gerefereerd, kan niet gedelete worden.");
            }

            //if (isReferencedOrNot != 0)
            //{
                
            //} else
            //{

            //    Messenger.Default.Send<Bord>(CurrentBord);
            //    BordDataService bordDS =
            //        new BordDataService();
            //    bordDS.DeleteBord(CurrentBord);
                
            //    //Messenger.Default.Send<Bord>(CurrentBord);
            //    //Refresh
            //    LeesBorden();
            //}
          
        }

        public void WijzigenBord()
        {
            if (CurrentBord != null)
            {
                BordDataService bordDS =
                new BordDataService();
                bordDS.UpdateBord(CurrentBord);

                //Refresh
                LeesBorden();
            }

        }

    }
}
