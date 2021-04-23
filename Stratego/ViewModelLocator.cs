using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MemoryGame.ViewModels;
using Stratego.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stratego
{
    class ViewModelLocator
    {
        
        private static GameViewModel gameViewModel = new GameViewModel();
        private static PersoonViewModel persoonViewModel = new PersoonViewModel();
        private static SessieViewModel sessieViewModel = new SessieViewModel();
        private static BordViewModel bordViewModel = new BordViewModel();
        private static NavigationViewModel navigationViewModel = new NavigationViewModel();
        //private static MainViewModel mainViewModel = new MainViewModel();
        //private static MainViewModel mainViewModel = new MainViewModel();
        //private static MainViewModel mainViewModel = new MainViewModel();
        //private static MainViewModel mainViewModel = new MainViewModel();

      

        public static BordViewModel BordViewModel
        {
            get
            {
                return bordViewModel;
            }
        }

        public static GameViewModel GameViewModel
        {
            get
            {
                return gameViewModel;
            }
        }

        public static PersoonViewModel PersoonViewModel
        {
            get
            {
                return persoonViewModel;
            }
        }

        public static SessieViewModel SessieViewModel
        {
            get
            {
                return sessieViewModel;
            }
        }

        public static NavigationViewModel NavigationViewModel
        {
            get
            {
                return navigationViewModel;
            }
        }


    }
}
