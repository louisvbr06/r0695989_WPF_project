using Stratego.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Stratego.ViewModel;
using Stratego;
using Stratego.Extra;
using Stratego.Extra.Messages;

namespace MemoryGame.ViewModels
{

    public class GameViewModel : BaseViewModel
    {
        //Collection van Vierkanten waarmee we spelen
        public VierkantCollectionViewModel Vierkanten { get; private set; }


        public string PlayingTeam = "Red";
        private ObservableCollection<string> _listView;
        private ObservableCollection<string> _listViewBlue;
        private ObservableCollection<string> _history;
        private string _selectedKarakter;
        private string _info;
        private string _viewInfo;
        public bool SpelGestart = false;
        private bool _isStartEnabled;
        private Brush hexBrush;
        public bool PlaatsenOpBord = true;
        public int placed_sum = 0;
        private Brush _color;

        private PageNavigationService pageNavigationService = new PageNavigationService();

        public ICommand StartGameCommand { get; private set; }
        public bool isStartEnabled
        {
            get { return _isStartEnabled; }
            set
            {
                _isStartEnabled = value;
                NotifyPropertyChanged();
            }
        }


        public GameViewModel()
        {
            pageNavigationService = new PageNavigationService();
            NavigateToHomeCommand = new BaseCommand(HomePagina);
            SetupGame();
            ListView = FillListView();
            _color = new SolidColorBrush(Colors.IndianRed);
            EnableRedSide();
            StartGameCommand = new DelegateCommand(o => StartGame());
            isStartEnabled = true;
            //Messenger.Default.Register<GameFinishedMessage>(this, OnMessageReceived, "GameFinished");
            Messenger.Default.Register<SessiesUpdatedMessage>(this, OnSessieUpdateReceived, "SessieUpdated");
            LeesSessieGegevens();
        }


        //private void OnMessageReceived(GameFinishedMessage message)
        //{
        //    PageNavigationService pageNavigationService = new PageNavigationService();
        //    pageNavigationService.Navigate("homepage");
        //    SetupGame();
        //    ListView = FillListView();
        //    _color = new SolidColorBrush(Colors.IndianRed);
        //    EnableRedSide();
        //    StartGameCommand = new DelegateCommand(o => StartGame());
        //    isStartEnabled = true;
        //    LeesSessieGegevens();
        //}

        private void OnSessieUpdateReceived(SessiesUpdatedMessage message)
        {
            
        }


        public ICommand NavigateToHomeCommand { get; set;  }

        public void HomePagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("homepage");
        }

        private void LeesSessieGegevens()
        {
            SessieDataService sessieDs =
               new SessieDataService();

            Sessies = new ObservableCollection<Sessie>(sessieDs.GetSessies());
            //Pionnen = new ObservableCollection<Pion>(pionDs.GetPionnen());

            BordDataService bordDs =
               new BordDataService();
           
            Borden = new ObservableCollection<Bord>(bordDs.GetBorden());

            RecentsteSessie = Sessies.LastOrDefault();



            foreach (Bord bord in Borden)
            {
                if (bord.ID == RecentsteSessie.bordID)
                {
                    hexBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(bord.HexCode));
                }
            }
        }

        


        public Brush BordKleur
        {
            get
            {
                return hexBrush;
            }
            set
            {
                hexBrush = value;
                NotifyPropertyChanged();
            }
        }
     
        public Sessie recentsteSessie;

        public Sessie RecentsteSessie
        {
            get
            {
                return recentsteSessie;
            }
            set
            {
                recentsteSessie = value;
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


        public Brush Background
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<string> ListView
        {
            get
            {
                return _listView;
            }
            set
            {
                _listView = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<string> ListViewBlue
        {
            get
            {
                return _listViewBlue;
            }
            set
            {
                _listViewBlue = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<string> History
        {
            get
            {
                return _history;
            }
            set
            {
                _history = value;
                NotifyPropertyChanged();
            }
        }
        public string SelectedKarakter
        {
            get
            {
                return _selectedKarakter;
            }
            set
            {
                _selectedKarakter = value;
                NotifyPropertyChanged();
            }
        }
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                NotifyPropertyChanged();
            }
        }
        public string ViewInfo
        {
            get
            {
                return _viewInfo;
            }
            set
            {
                _viewInfo = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<string> FillListView()
        {
            ObservableCollection<string> karaktersList = new ObservableCollection<string>();
            karaktersList.Add("Spy");
            for (int c = 0; c < 8; c++)
                karaktersList.Add("Scout");
            for (int c = 0; c < 5; c++)
                karaktersList.Add("Miner");
            for (int c = 0; c < 4; c++)
                karaktersList.Add("Sergent");
            for (int c = 0; c < 4; c++)
                karaktersList.Add("Lieutenant");
            for (int c = 0; c < 4; c++)
                karaktersList.Add("Captain");
            for (int c = 0; c < 3; c++)
                karaktersList.Add("Major");
            for (int c = 0; c < 2; c++)
                karaktersList.Add("Colonel");
            karaktersList.Add("General");
            karaktersList.Add("Marshall");
            for (int c = 0; c < 6; c++)
                karaktersList.Add("Bomb");
            karaktersList.Add("Flag");
            karaktersList.Add("");
            return karaktersList;
        } 

        //game essentials initialiseren
        private void SetupGame()
        {
            Vierkanten = new VierkantCollectionViewModel();
            Vierkanten.CreateVierkanten();
            
            Info = "Place red characters on board before start";
            NotifyPropertyChanged();
        }
        bool isFilled = false;
        
        //Wordt op vierkant geklikt
        public void ClickedVierkant(object slide)
        {
            if (PlaatsenOpBord && !SpelGestart) //Tijdens je de pionnen bent aan het plaatsen
            {
                var selected = slide as PionViewModel;
                var gameviewmodel = this as GameViewModel;
                Vierkanten.PlaceVierkant(selected, gameviewmodel);
                if (_listView.Count <= 1 && placed_sum <= 80)
                {
                    if (!isFilled)
                    { ListViewBlue = FillListView(); isFilled = true; }
                    PlayingTeam = "Blue";
                    Background = new SolidColorBrush(Colors.Cyan);
                    EnableBlueSide();
                    Info = "Place blue characters on board before start";

                    
                }
            }
            else if (!PlaatsenOpBord && SpelGestart) //Wanneer je de pionnen NIET bent aan het plaatsen
            {
                var selected = slide as PionViewModel;
                var gameviewmodel = this as GameViewModel;
                Vierkanten.VerplaatsVierkant(selected, gameviewmodel);
            }


        }
        public void EnableRedSide()
        {
            if (placed_sum < 40)
            {
                for (int j = 0; j < 60; j++)
                    Vierkanten.GeheugenVierkanten[j].isSelectable = false;
                for (int j = 60; j < 100; j++)
                    Vierkanten.GeheugenVierkanten[j].BorderBrush = new SolidColorBrush(Colors.Red);
            }

        }
        public void EnableBlueSide()
        {
            if (placed_sum >= 40)
            {
                for (int j = 0; j < 60; j++)
                {
                    Vierkanten.GeheugenVierkanten[j].isSelectable = true;
                    Vierkanten.GeheugenVierkanten[j].BorderBrush = new SolidColorBrush(Colors.Blue);
                }
                for (int j = 40; j < 100; j++)
                {
                    Vierkanten.GeheugenVierkanten[j].isSelectable = false;
                    Vierkanten.GeheugenVierkanten[j].BorderBrush = null;
                }

            }

        }
        public void StartGame()
        {
            if (placed_sum > 80) //veranderingen als alle pionnen geplaatst zijn
            {
                PlaatsenOpBord = false;
                //Setup fase stoppen

                for (int j = 0; j < 100; j++)
                    Vierkanten.GeheugenVierkanten[j].isSelectable = true;
                //alle pionnen klikbaar maken

                
                Info = "Game started - it is red's turn";                
                PlayingTeam = "Red";
                SpelGestart = true;
                isStartEnabled = false;
                HideAll("Blue");
            }
        }
        public void HideAll(string team)
        {
            if (team == "Blue")
            {
                foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                    if (p.Team == "Blue")
                    {
                        //Huidige image wordt opgeslagen in een non binded string

                        p.VierkantFoto_Save = p.VierkantFoto;
                        p.VierkantFoto = Path.Combine(Environment.CurrentDirectory + "/images/00_Null_Blue.png");
                    }
            }
            if (team == "Red")
            {
                foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                    if (p.Team == "Red")
                    {
                        p.VierkantFoto_Save = p.VierkantFoto;
                        p.VierkantFoto = Path.Combine(Environment.CurrentDirectory + "/images/00_Null_Red.png");
                    }
            }
        }
        public void UnhideAll(string team)
        {
            {
                if (team == "Blue")
                {
                    foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                        if (p.Team == "Blue")
                        {
                            //Image wordt opgehaald van de opgeslagen image

                            p.VierkantFoto = p.VierkantFoto_Save;
                            
                        }
                }
                if (team == "Red")
                {
                    foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                        if (p.Team == "Red")
                        {
                            p.VierkantFoto = p.VierkantFoto_Save;
                            
                        }
                }
            }
        }

        public void DisableAll(string team)
        {
            if (team == "Blue")

                foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                    if (p.Team == "Blue")
                        p.isSelectable = false;

            if (team == "Red")

                foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                    if (p.Team == "Red")
                        p.isSelectable = false;
        }
        public void EnableAll(string team)
        {
            if (team == "Blue")

                foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                    if (p.Team == "Blue")
                        p.isSelectable = true;

            if (team == "Red")

                foreach (PionViewModel p in Vierkanten.GeheugenVierkanten)
                    if (p.Team == "Red")
                        p.isSelectable = true;
        }
    }
}
