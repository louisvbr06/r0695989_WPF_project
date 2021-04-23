using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Model
{
    public class Pion: BaseModel
    {
        private int id;
        private string fotobron_save;
        private string fotobron;
        private string karakter;
        private string team;
        private bool _isMoveable;

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
        public string FotoBron
        {
            get
            {
                return fotobron;
            }
            set
            {
                fotobron = value;
                NotifyPropertyChanged();
            }
        } //current
        public string FotoBron_Save
        {
            get
            {
                return fotobron_save;
            }
            set
            {
                fotobron_save = value;
                NotifyPropertyChanged();
            }

        } //waarde hier opslaan bij het verstoppen van karakters
        public string Karakter
        {
            get
            {
                return karakter;
            }
            set
            {
                karakter = value;
                NotifyPropertyChanged();
            }

        }
        public string Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value;
                NotifyPropertyChanged();
            }
        } //Red / Blue
        public bool isMoveable
        {
            get
            {
                return _isMoveable;
            }
            set
            {
                _isMoveable = value;
                NotifyPropertyChanged();
            }
        }
    }
}
