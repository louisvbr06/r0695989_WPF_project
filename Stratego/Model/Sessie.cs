using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Stratego.Extra;

namespace Stratego.Model
{
    public class Sessie : BaseModel, IDataErrorInfo
    {
        private int id;        
        private int persoon_id;
        private int bord_id;
        private string team1_speler;
        private string team2_speler;
        private string bord_kleur;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string BordKleur
        {
            get
            {
                return bord_kleur;
            }
            set
            {
                bord_kleur = value;
                NotifyPropertyChanged();
            }
        }



        public string team1_Speler
        {
            get
            {
                return team1_speler;
            }
            set
            {
                team1_speler = value;
                NotifyPropertyChanged();
                //speler1naam.Naam = team1_Speler;
            }
        }

        

        public string team2_Speler
        {
            get
            {
                return team2_speler;
            }
            set
            {
                team2_speler = value;
                NotifyPropertyChanged();
                //speler2naam.Naam = team2_Speler;
            }
        }

        

        public int persoonID
        {
            get
            {
                return persoon_id;
            }
            set
            {
                persoon_id = value;
                NotifyPropertyChanged();
            }
        }

        public int bordID
        {
            get
            {
                return bord_id;
            }
            set
            {
                bord_id = value;
                NotifyPropertyChanged();
            }
        }




        public string Error

        {

            get

            {

                return string.Empty;

            }

        }

        public string this[string columnName]

        {

            get

            {
                string result = string.Empty;

                switch (columnName)

                {
                    case "team1_Speler": if (string.IsNullOrEmpty(team1_Speler)) result = "Naam moet ingevuld zijn!"; break;

                    case "team2_Speler": if (string.IsNullOrEmpty(team2_Speler)) result = "Naam moet ingevuld zijn!"; break;

                    case "BordKleur": if (string.IsNullOrEmpty(BordKleur)) result = "Bordkleur moet gekozen zijn!"; break;
                };

                return result;

            }

        }
    }
}
