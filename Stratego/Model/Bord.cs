using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Stratego.Model
{
    public class Bord:BaseModel, IDataErrorInfo
    {
        private int id;
        private string kleur;
        private string hexcode;

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

        public string Kleur
        {
            get
            {
                return kleur;
            }
            set
            {
                kleur = value;
                NotifyPropertyChanged();
            }
        }

        public string HexCode
        {
            get
            {
                return hexcode;
            }
            set
            {
                hexcode = value;
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

                    case "Kleur": if (string.IsNullOrEmpty(Kleur)) result = "Kleurnaam moet ingevuld zijn!"; break;

                    case "HexCode": if (HexCode == null) result = "Kleur moet gekozen zijn!."; break;

                };

                return result;

            }

        }

    }
}
