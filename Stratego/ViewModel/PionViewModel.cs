using Stratego.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Stratego.ViewModel
{
   
        public class PionViewModel : BaseViewModel
        {
            //Model
            private Pion pion;
           
            public int id { get; set; }
            private bool isselectable = true;
            private bool ismoveable = true;
            private int _x;
            private int _y;
            
            public int X
            {
                get
                {
                    return _x;
                }
                set
                {
                    _x = value;
                    NotifyPropertyChanged();
                }

            }
            public int Y
            {
                get
                {
                    return _y;
                }
                set
                {
                    _y = value;
                    NotifyPropertyChanged();
                }

            }
            public bool isSelectable
            {
                get
                {
                    return isselectable;
                }
                set
                {
                    isselectable = value;
                    NotifyPropertyChanged();
                }

            }
            public bool isMoveable
            {
                get
                {
                    return ismoveable;
                }
                set
                {
                    ismoveable = value;
                    NotifyPropertyChanged();
                }

            }
            //Foto om te tonen
            public string VierkantFoto
            {
                get
                {

                    return pion.FotoBron;
                }
                set
                {
                    pion.FotoBron = value;
                    NotifyPropertyChanged();
                }

            }
        //Images opslaan wanneer we de anderen willen 'hiden'
        public string VierkantFoto_Save
            {
                get
                {

                    return pion.FotoBron_Save;
                }
                set
                {
                    pion.FotoBron_Save = value;
                    NotifyPropertyChanged();
                }

            }
            public string Karakter
            {
                get
                {

                    return pion.Karakter;
                }
                set
                {
                    pion.Karakter = value;
                NotifyPropertyChanged();
                }

            }
            public string Team
            {
                get
                {

                    return pion.Team;
                }
                set
                {
                    pion.Team = value;
                NotifyPropertyChanged();
                }

            }
            private Brush _borderBrush;
            public Brush BorderBrush
            {
                get
                {
                    return _borderBrush;
                }
                set
                {
                    _borderBrush = value;
                NotifyPropertyChanged();
                }
            }
            public PionViewModel(Pion model)
            {
                pion = model;
                id = model.ID;
                Karakter = model.Karakter;
                Team = model.Team;
                isMoveable = model.isMoveable;
            }

        
    }
}
