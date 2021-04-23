using Stratego.Model;
using Stratego.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stratego.Extra
{
    public class PageNavigationService
    {
        HomePage homePage = null;
        SetupPage setupPage = null;
        LeaderboardPage leaderboardPage = null;
        AdminPage adminPage = null;
        
        BoardsAdminPage boardsAdminPage = null;
        PlayersAdminPage playersAdminPage = null;
        SessionsAdminPage sessionsAdminPage = null;
        GamePage gamePage = null;
        public PageNavigationService()
        {

        }

        public void Navigate(string page)
        {
            switch (page)
            {
                case "homepage":
                    homePage = new HomePage();
                    ApplicationHelper.NavigationService.Navigate(homePage);
                    break;
                case "setuppage":
                    setupPage = new SetupPage();
                    ApplicationHelper.NavigationService.Navigate(setupPage);
                    break;
                case "gamepage":
                    gamePage = new GamePage();
                    ApplicationHelper.NavigationService.Navigate(gamePage);
                    break;
                case "leaderboardpage":
                    leaderboardPage = new LeaderboardPage();
                    ApplicationHelper.NavigationService.Navigate(leaderboardPage);
                    break;
                
                case "adminpage":
                    adminPage = new AdminPage();
                    ApplicationHelper.NavigationService.Navigate(adminPage);
                    break;
                
                case "boardsadminpage":
                    boardsAdminPage = new BoardsAdminPage();
                    ApplicationHelper.NavigationService.Navigate(boardsAdminPage);
                    break;
                case "playersadminpage":
                    playersAdminPage = new PlayersAdminPage();
                    ApplicationHelper.NavigationService.Navigate(playersAdminPage);
                    break;
                case "sessionsadminpage":
                    sessionsAdminPage = new SessionsAdminPage();
                    ApplicationHelper.NavigationService.Navigate(sessionsAdminPage);
                    break;

                default:
                    break;
            }
        }


    }
}
