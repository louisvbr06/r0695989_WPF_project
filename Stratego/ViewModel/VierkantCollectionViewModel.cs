using MemoryGame.ViewModels;
using Stratego.Extra;
using Stratego.Extra.Messages;
using Stratego.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Stratego.ViewModel
{
    public class VierkantCollectionViewModel : BaseViewModel
    {
        //Collectie van fotos voor vierkanten
        public ObservableCollection<PionViewModel> GeheugenVierkanten { get; private set; }
        public PionViewModel[,] Map = new PionViewModel[10, 10];

        //Geselecteerde vierkanten
        private PionViewModel SelectedVierkant1;
        private PionViewModel SelectedVierkant2;
        private ObservableCollection<string> history = new ObservableCollection<string>();
        private ObservableCollection<string> red_graveyard = new ObservableCollection<string>();
        private ObservableCollection<string> blue_graveyard = new ObservableCollection<string>();
        private int movable_red_on_board = 33;
        private int movable_blue_on_board = 33;

        

        public VierkantCollectionViewModel()
        {
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

        private void LeesPersonen()
        {
            //instantiëren dataservice
            PersoonDataService contactDS =
               new PersoonDataService();

            Personen = new ObservableCollection<Persoon>(contactDS.GetPersonen());
        }
        
        //Vierkanten maken van fotos in de bestanden
        public void CreateVierkanten()
        {
            GeheugenVierkanten = new ObservableCollection<PionViewModel>();

            for (int i = 0; i < 100; i++)
            {
                if (i == 42 || i == 43 || i == 46 || i == 47 || i == 52 || i == 53 || i == 56 || i == 57) //obstacles
                {
                    var model = new Pion();
                    model.ID = i + 1;
                    model.FotoBron = Path.Combine(Environment.CurrentDirectory + "/images/13_Obstacle.png");
                    model.Karakter = "obstacle";
                    model.isMoveable = false;
                    var vierkant = new PionViewModel(model);
                    GeheugenVierkanten.Add(vierkant);

                }
                else
                {
                    var model = new Pion();
                    model.ID = i + 1;
                    model.FotoBron = Path.Combine(Environment.CurrentDirectory + "/images/00_Null_Grey.png");
                    model.Karakter = "grey";
                    model.isMoveable = false;
                    var vierkant = new PionViewModel(model);
                    GeheugenVierkanten.Add(vierkant);
                }
            }

            //Cooördinaten definiëren
            int x = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GeheugenVierkanten[x].X = i;
                    GeheugenVierkanten[x].Y = j;
                                       
                    x++;
                }
            }

            NotifyPropertyChanged();
        }
        bool isBeurtGedaan = false;
        //vierkant matchen aan karakter
        public void PlaceVierkant(PionViewModel vierkant, GameViewModel gm)
        {
            if (vierkant.Karakter == "grey" && gm.PlaatsenOpBord)
            {
                if (gm.SelectedKarakter == "Spy")
                    PutOnBoard("Spy", gm, vierkant);
                if (gm.SelectedKarakter == "Scout")
                    PutOnBoard("Scout", gm, vierkant);
                if (gm.SelectedKarakter == "Miner")
                    PutOnBoard("Miner", gm, vierkant);
                if (gm.SelectedKarakter == "Sergent")
                    PutOnBoard("Sergent", gm, vierkant);
                if (gm.SelectedKarakter == "Lieutenant")
                    PutOnBoard("Lieutenant", gm, vierkant);
                if (gm.SelectedKarakter == "Captain")
                    PutOnBoard("Captain", gm, vierkant);
                if (gm.SelectedKarakter == "Major")
                    PutOnBoard("Major", gm, vierkant);
                if (gm.SelectedKarakter == "Colonel")
                    PutOnBoard("Colonel", gm, vierkant);
                if (gm.SelectedKarakter == "General")
                    PutOnBoard("General", gm, vierkant);
                if (gm.SelectedKarakter == "Marshall")
                    PutOnBoard("Marshall", gm, vierkant);
                if (gm.SelectedKarakter == "Bomb")
                    PutOnBoard("Bomb", gm, vierkant);
                if (gm.SelectedKarakter == "Flag")
                    PutOnBoard("Flag", gm, vierkant);
                if (gm.PlayingTeam == "Red")
                    gm.SelectedKarakter = gm.ListView[0];
                else
                    gm.SelectedKarakter = gm.ListViewBlue[0];
                vierkant.Team = gm.PlayingTeam;
                gm.placed_sum++;
            }

        }
        public void VerplaatsVierkant(PionViewModel vierkant, GameViewModel gm)
        {
            if (gm.SpelGestart)
            {
                if (vierkant.isMoveable && SelectedVierkant1 == null && vierkant.Team == gm.PlayingTeam)
                {
                    isBeurtGedaan = false;
                    SelectedVierkant1 = vierkant;
                    ShowWhereCanGo(vierkant, gm.PlayingTeam);
                }
                else if (vierkant.Karakter != "obstacle" && SelectedVierkant1 != null)
                {
                    SelectedVierkant2 = vierkant;
                    if (SelectedVierkant1.id == SelectedVierkant2.id) //Deselecteren
                    {
                        SelectedVierkant2 = null;
                        SelectedVierkant1 = null;
                    }
                    else
                    {
                        #region ATTACK_RULES
                        if (SelectedVierkant2.Karakter == "Flag") //Checken of vlag 
                        {
                            DisableAll();
                            gm.UnhideAll("Blue"); gm.UnhideAll("Red");
                            gm.SpelGestart = false;
                            if (SelectedVierkant2.Team == "Red")
                            {
                                MessageBox.Show("Blue team won!");
                                IncreaseScore(gm.RecentsteSessie.team2_Speler);
                                
                            }
                                
                            else if (SelectedVierkant2.Team == "Blue")
                            {
                                MessageBox.Show("Red team won!");
                                IncreaseScore(gm.RecentsteSessie.team1_Speler);
                                
                            }
                                
                        }
                        if (SelectedVierkant2.Karakter == "grey")
                        {
                            RemoveSecond(gm.PlayingTeam);
                            isBeurtGedaan = true;
                        }
                        else if (SelectedVierkant1.Karakter == "Spy" && SelectedVierkant2.Karakter == "Marshall") //Spion regel
                        {
                            AddToGraveyard(SelectedVierkant2);
                            history.Add("Spy murdered Marshall");
                            RemoveSecond(gm.PlayingTeam);
                            isBeurtGedaan = true;

                        }
                        else if (SelectedVierkant1.Karakter == "Miner" && SelectedVierkant2.Karakter == "Bomb") //Mineur en bom regel
                        {
                            AddToGraveyard(SelectedVierkant2);
                            history.Add("Miner defused Bomb");
                            RemoveSecond(gm.PlayingTeam);
                            isBeurtGedaan = true;

                        }
                        else if (NameToNumber(SelectedVierkant1.Karakter) > NameToNumber(SelectedVierkant2.Karakter))
                        {
                            AddToGraveyard(SelectedVierkant2);
                            history.Add(SelectedVierkant1.Karakter + " defeated " + SelectedVierkant2.Karakter);
                            RemoveSecond(gm.PlayingTeam);
                            isBeurtGedaan = true;
                        }
                        else if (NameToNumber(SelectedVierkant1.Karakter) < NameToNumber(SelectedVierkant2.Karakter))
                        {
                            AddToGraveyard(SelectedVierkant1);
                            history.Add(SelectedVierkant2.Karakter + " defeated " + SelectedVierkant1.Karakter);
                            RemoveFirst();
                            isBeurtGedaan = true;

                        }
                        else if (NameToNumber(SelectedVierkant1.Karakter) == NameToNumber(SelectedVierkant2.Karakter))
                        {
                            movable_red_on_board--;
                            movable_blue_on_board--;
                            red_graveyard.Add(SelectedVierkant1.Karakter);
                            blue_graveyard.Add(SelectedVierkant2.Karakter);
                            history.Add(SelectedVierkant1.Karakter + " defeated " + SelectedVierkant2.Karakter);
                            RemoveBoth();
                            isBeurtGedaan = true;
                        }
                        if (movable_blue_on_board == 0 && movable_red_on_board == 0)
                        { MessageBox.Show("Tie! All movable soldies were killed"); gm.SpelGestart = false; gm.UnhideAll("Blue"); gm.UnhideAll("Red"); }
                        else if (movable_blue_on_board == 0)
                        { 
                            MessageBox.Show("Red team (" + gm.RecentsteSessie.team1_Speler + ") won! All blue soldiers were killed");
                            gm.SpelGestart = false;
                            gm.UnhideAll("Blue");
                            gm.UnhideAll("Red");
                            IncreaseScore(gm.RecentsteSessie.team1_Speler);
                            //Messenger.Default.Send<GameFinishedMessage>(new GameFinishedMessage());
                        }
                        else if (movable_red_on_board == 0)
                        { 
                            MessageBox.Show("Blue team (" + gm.RecentsteSessie.team2_Speler +  ") won! All red soldiers were killed");
                            gm.SpelGestart = false;
                            gm.UnhideAll("Blue");
                            gm.UnhideAll("Red");
                            IncreaseScore(gm.RecentsteSessie.team2_Speler);
                            //Messenger.Default.Send<GameFinishedMessage>(new GameFinishedMessage());

                        }
                        #endregion
                    }
                    gm.History = history;
                    gm.ListView = red_graveyard;
                    gm.ListViewBlue = blue_graveyard;
                    EnableAll();
                    RemoveBorderAll();
                }
                if (gm.PlayingTeam == "Red" && isBeurtGedaan && gm.SpelGestart)
                {
                    gm.HideAll("Red");
                    gm.UnhideAll("Blue");
                    gm.DisableAll("Red");
                    gm.EnableAll("Blue");
                    isBeurtGedaan = false;
                    gm.PlayingTeam = "Blue";
                    gm.Info = "It is " + gm.RecentsteSessie.team2_Speler + "'s turn";

                }
                else if (gm.PlayingTeam == "Blue" && isBeurtGedaan && gm.SpelGestart)
                {
                    gm.HideAll("Blue");
                    gm.UnhideAll("Red");
                    gm.DisableAll("Blue");
                    gm.EnableAll("Red");
                    isBeurtGedaan = false;
                    gm.PlayingTeam = "Red";
                    gm.Info = "It is " + gm.RecentsteSessie.team1_Speler + "'s turn";
                }
                else if (!gm.SpelGestart)
                { gm.UnhideAll("Blue"); gm.UnhideAll("Red"); }
            }
        }

        public void IncreaseScore(string persoon)
        {
            MessageBox.Show("Winner is " + persoon);
            foreach (var item in Personen)
            {
                if (item.Naam.Equals(persoon))
                {
                    PersoonDataService persoonDs = new PersoonDataService();

                    persoonDs.UpdateScore(item);
                }
            }

            Messenger.Default.Send<ScoreUpdatedMessage>(new ScoreUpdatedMessage());
        }

        private int NameToNumber(string Karakter)
        {
            switch (Karakter.ToString())
            {
                case "Flag":
                    return 0;
                case "Spy":
                    return 1;
                case "Scout":
                    return 2;
                case "Miner":
                    return 3;
                case "Sergent":
                    return 4;
                case "Lieutenant":
                    return 5;
                case "Captain":
                    return 6;
                case "Major":
                    return 7;
                case "Colonel":
                    return 8;
                case "General":
                    return 9;
                case "Marshall":
                    return 10;
                case "Bomb":
                    return 11;
                default:
                    return 0;
            }
        }
        private void AddToGraveyard(PionViewModel pion) //pionnen toevoegen aan graveyard
        {
            if (pion.Team == "Red")
            {
                red_graveyard.Add(pion.Karakter);
                if (pion.isMoveable)
                    movable_red_on_board--;
            }
            else if (pion.Team == "Blue")
            {
                blue_graveyard.Add(pion.Karakter);
                if (pion.isMoveable)
                    movable_blue_on_board--;
            }

        }
        private void RemoveSecond(string PlayingTeam)
        {
            SelectedVierkant2.Karakter = SelectedVierkant1.Karakter;
            SelectedVierkant2.VierkantFoto = SelectedVierkant1.VierkantFoto;
            SelectedVierkant2.isMoveable = true;
            SelectedVierkant1.isMoveable = false;
            SelectedVierkant1.VierkantFoto = Path.Combine(Environment.CurrentDirectory + "/images/00_Null_Grey.png");
            SelectedVierkant1.Karakter = "grey";
            SelectedVierkant2.Team = PlayingTeam;
            SelectedVierkant1.Team = null;
            SelectedVierkant2 = null;
            SelectedVierkant1 = null;
        }
        private void RemoveFirst()
        {
            SelectedVierkant1.isMoveable = false;
            SelectedVierkant1.VierkantFoto = Path.Combine(Environment.CurrentDirectory + "/images/00_Null_Grey.png");
            SelectedVierkant1.Karakter = "grey";
            SelectedVierkant1.Team = null;
            SelectedVierkant2 = null;
            SelectedVierkant1 = null;
        }
        private void RemoveBoth()
        {
            SelectedVierkant1.isMoveable = false;
            SelectedVierkant1.VierkantFoto = Path.Combine(Environment.CurrentDirectory + "/images/00_Null_Grey.png");
            SelectedVierkant1.Karakter = "grey";
            SelectedVierkant2.isMoveable = false;
            SelectedVierkant2.VierkantFoto = Path.Combine(Environment.CurrentDirectory + "/images/00_Null_Grey.png");
            SelectedVierkant2.Karakter = "grey";
            SelectedVierkant1.Team = null;
            SelectedVierkant2.Team = null;
            SelectedVierkant2 = null;
            SelectedVierkant1 = null;
        }
        public void ShowWhereCanGo(PionViewModel vierkant, string playingTeam)
        {
            if (vierkant.Team == playingTeam)
            {
                RemoveBorderAll();
                DisableAll();
                vierkant.isSelectable = true;
                vierkant.BorderBrush = new SolidColorBrush(Colors.Purple);
                if (vierkant.Karakter == "Scout")
                {
                    #region SCOUT_RULES
                    //scout
                    int count = 0;
                    LoadMapArray();
                    for (int i = vierkant.X; i < 9; i++) //onder verkenner
                    {
                        count++;
                        if (Map[vierkant.X + count, vierkant.Y].Karakter == "grey")
                        {
                            Map[vierkant.X + count, vierkant.Y].isSelectable = true;
                            Map[vierkant.X + count, vierkant.Y].BorderBrush = new SolidColorBrush(Colors.Purple);
                        }
                        else if (Map[vierkant.X + count, vierkant.Y].Team == playingTeam || Map[vierkant.X + count, vierkant.Y].Karakter == "obstacle")
                            break;
                        else if (Map[vierkant.X + count, vierkant.Y].Team != playingTeam && Map[vierkant.X + count, vierkant.Y].Karakter != "obstacle")
                        {
                            Map[vierkant.X + count, vierkant.Y].isSelectable = true;
                            Map[vierkant.X + count, vierkant.Y].BorderBrush = new SolidColorBrush(Colors.Purple);
                            break;
                        }

                    }
                    count = 0;
                    for (int i = vierkant.X; i > 0; i--) //boven verkenner
                    {
                        count++;
                        if ((vierkant.X - count) >= 0)
                        {
                            if (Map[vierkant.X - count, vierkant.Y].Karakter == "grey")
                            {
                                Map[vierkant.X - count, vierkant.Y].isSelectable = true;
                                Map[vierkant.X - count, vierkant.Y].BorderBrush = new SolidColorBrush(Colors.Purple);
                            }
                            else if (Map[vierkant.X - count, vierkant.Y].Team == playingTeam || Map[vierkant.X - count, vierkant.Y].Karakter == "obstacle")
                                break;
                            else if (Map[vierkant.X - count, vierkant.Y].Team != playingTeam && Map[vierkant.X - count, vierkant.Y].Karakter != "obstacle")
                            {
                                Map[vierkant.X - count, vierkant.Y].isSelectable = true;
                                Map[vierkant.X - count, vierkant.Y].BorderBrush = new SolidColorBrush(Colors.Purple);
                                break;
                            }
                        }
                    }
                    count = 0;
                    for (int i = vierkant.Y; i > 0; i--) //linkerkant
                    {
                        count++;
                        if ((vierkant.Y - count) >= 0)
                        {
                            if (Map[vierkant.X, vierkant.Y - count].Karakter == "grey")
                            {
                                Map[vierkant.X, vierkant.Y - count].isSelectable = true;
                                Map[vierkant.X, vierkant.Y - count].BorderBrush = new SolidColorBrush(Colors.Purple);
                            }
                            else if (Map[vierkant.X, vierkant.Y - count].Team == playingTeam || Map[vierkant.X, vierkant.Y - count].Karakter == "obstacle")
                                break;
                            else if (Map[vierkant.X, vierkant.Y - count].Team != playingTeam && Map[vierkant.X, vierkant.Y - count].Karakter != "obstacle")
                            {
                                Map[vierkant.X, vierkant.Y - count].isSelectable = true;
                                Map[vierkant.X, vierkant.Y - count].BorderBrush = new SolidColorBrush(Colors.Purple);
                                break;
                            }
                        }
                    }
                    count = 0;
                    for (int i = vierkant.Y; i < 9; i++) //rechterkant
                    {
                        count++;

                        if (Map[vierkant.X, vierkant.Y + count].Karakter == "grey")
                        {
                            Map[vierkant.X, vierkant.Y + count].isSelectable = true;
                            Map[vierkant.X, vierkant.Y + count].BorderBrush = new SolidColorBrush(Colors.Purple);
                        }
                        else if (Map[vierkant.X, vierkant.Y + count].Team == playingTeam || Map[vierkant.X, vierkant.Y + count].Karakter == "obstacle")
                            break;
                        else if (Map[vierkant.X, vierkant.Y + count].Team != playingTeam && Map[vierkant.X, vierkant.Y + count].Karakter != "obstacle")
                        {
                            Map[vierkant.X, vierkant.Y + count].isSelectable = true;
                            Map[vierkant.X, vierkant.Y + count].BorderBrush = new SolidColorBrush(Colors.Purple);
                            break;
                        }

                    }
                    count = 0;
                    #endregion
                }
                else
                {
                    #region OTHER_RULES
                    foreach (PionViewModel p in GeheugenVierkanten)
                    {
                        if (vierkant.X - 1 == p.X && vierkant.Y == p.Y && p.Team != vierkant.Team && p.Karakter != "obstacle")
                        {
                            p.isSelectable = true;
                            p.BorderBrush = new SolidColorBrush(Colors.Purple);
                        }
                        else if (vierkant.X + 1 == p.X && vierkant.Y == p.Y && p.Team != vierkant.Team && p.Karakter != "obstacle")
                        {
                            p.isSelectable = true;
                            p.BorderBrush = new SolidColorBrush(Colors.Purple);
                        }
                        else if (vierkant.X == p.X && vierkant.Y + 1 == p.Y && p.Team != vierkant.Team && p.Karakter != "obstacle")
                        {
                            p.isSelectable = true;
                            p.BorderBrush = new SolidColorBrush(Colors.Purple);
                        }
                        else if (vierkant.X == p.X && vierkant.Y - 1 == p.Y && p.Team != vierkant.Team && p.Karakter != "obstacle")
                        {
                            p.isSelectable = true;
                            p.BorderBrush = new SolidColorBrush(Colors.Purple);
                        }
                    }
                    #endregion
                }
            }
        }
        public void DisableAll()
        {
            foreach (PionViewModel pion in GeheugenVierkanten)
                pion.isSelectable = false;
        }
        public void EnableAll()
        {
            foreach (PionViewModel pion in GeheugenVierkanten)
                pion.isSelectable = true;
        }
        public void RemoveBorderAll()
        {
            foreach (PionViewModel pion in GeheugenVierkanten)
                pion.BorderBrush = null;
        }
        public void LoadMapArray()
        {
            int x = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Map[i, j] = GeheugenVierkanten[x];
                    x++;
                }
            }
        }
        /*  public void DisableAll(string team)
          {
              if (team == "Blue")

                  foreach (PionViewModel p in GeheugenVierkanten)
                      if (p.Team == "Blue")
                          p.isSelectable = false;

              if (team == "Red")

                  foreach (PionViewModel p in GeheugenVierkanten)
                      if (p.Team == "Red")
                          p.isSelectable = false;
          }
          public void EnableAll(string team)
          {
              if (team == "Blue")

                  foreach (PionViewModel p in GeheugenVierkanten)
                      if (p.Team == "Blue")
                          p.isSelectable = true;

              if (team == "Red")

                  foreach (PionViewModel p in GeheugenVierkanten)
                      if (p.Team == "Red")
                          p.isSelectable = true;

              OnPropertyChanged("GeheugenVierkanten");
          }*/
        public void PutOnBoard(string Karakter, GameViewModel gm, PionViewModel vierkant)
        {
            if (gm.PlayingTeam == "Red")
                gm.ListView.Remove(Karakter);
            else if (gm.PlayingTeam == "Blue")
                gm.ListViewBlue.Remove(Karakter);

            string[] imageNames = {
                    "01_Spy_",
                    "02_Scout_",
                    "03_Miner_",
                    "04_Sergent_",
                    "05_Lieutenant_",
                    "06_Captain_",
                    "07_Major_",
                    "08_Colonel_",
                    "09_General_",
                    "10_Marshall_",
                    "11_Bomb_",
                    "12_Flag_"
                };
            string image = string.Empty;
            if (Karakter == "Spy")
                image = imageNames[0];
            else if (Karakter == "Scout")
                image = imageNames[1];
            else if (Karakter == "Miner")
                image = imageNames[2];
            else if (Karakter == "Sergent")
                image = imageNames[3];
            else if (Karakter == "Lieutenant")
                image = imageNames[4];
            else if (Karakter == "Captain")
                image = imageNames[5];
            else if (Karakter == "Major")
                image = imageNames[6];
            else if (Karakter == "Colonel")
                image = imageNames[7];
            else if (Karakter == "General")
                image = imageNames[8];
            else if (Karakter == "Marshall")
                image = imageNames[9];
            else if (Karakter == "Bomb")
                image = imageNames[10];
            else if (Karakter == "Flag")
                image = imageNames[11];

            vierkant.VierkantFoto = Path.Combine(Environment.CurrentDirectory + "/images/" + image + gm.PlayingTeam + ".png");
            vierkant.Karakter = Karakter;
            if (Karakter != "Bomb" && Karakter != "Flag")
                vierkant.isMoveable = true;
            else
                vierkant.isMoveable = false;
        }
    }
}
