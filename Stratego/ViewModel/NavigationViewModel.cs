using Stratego.Extra;
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
    class NavigationViewModel : BaseViewModel
    {

        private PageNavigationService pageNavigationService = new PageNavigationService();

        public NavigationViewModel() {
            pageNavigationService = new PageNavigationService();
            
            KoppelenCommands();
        }
       
        private void KoppelenCommands()
        {
            NavigateToHomeCommand = new BaseCommand(HomePagina);
            NavigateToLeaderBoardCommand = new BaseCommand(LeaderboardPagina);
            NavigateToNewGameCommand = new BaseCommand(NewGamePagina);
            NavigateToGameCommand = new BaseCommand(GamePagina);
            NavigateToPlayersCommand = new BaseCommand(PlayersPagina);
            NavigateToBoardsCommand = new BaseCommand(BoardsPagina);
            NavigateToSessionsCommand = new BaseCommand(SessionsPagina);
            NavigateToAdminCommand = new BaseCommand(AdminPagina);

        }

        public ICommand NavigateToHomeCommand { get; set; }
        public ICommand NavigateToLeaderBoardCommand { get; set; }
        public ICommand NavigateToNewGameCommand { get; set; }

        public ICommand NavigateToGameCommand { get; set; }
        public ICommand NavigateToAdminCommand { get; set; }

        public ICommand NavigateToPlayersCommand { get; set; }

        public ICommand NavigateToSessionsCommand { get; set; }

        public ICommand NavigateToBoardsCommand { get; set; }
        

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

        public void GamePagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("gamepage");
        }

        public void AdminPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("adminpage");
        }

        public void PlayersPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("playersadminpage");
        }

        public void SessionsPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("sessionsadminpage");
        }

        public void BoardsPagina()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("boardsadminpage");
        }

        
    }
}
