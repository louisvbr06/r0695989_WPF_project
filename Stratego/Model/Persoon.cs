using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Model
{
    public class Persoon : BaseModel, IDataErrorInfo
    {
        private int id;
        private string naam;
        private int score;
        private ICollection<Sessie> sessies;
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

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                naam = value;
                NotifyPropertyChanged();
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<Sessie> Sessies
        {
            get { return sessies; }
            set
            {
                sessies = value;
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

                    case "Naam": if (string.IsNullOrEmpty(Naam)) result = "Naam moet ingevuld zijn!"; break;

                    case "Score": if (Score <= 0) result = "moet een positief getal zijn."; break;

                };

                return result;

            }

        }

    }
}
