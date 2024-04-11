using LibraryManagementSystem.Config;
using LibraryManagementSystem.Pages;

namespace LibraryManagementSystem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (SystemEnv.IsAuthorized)
            {
                MainPage = new Welcome();
            }
            else
            {
                MainPage = new MainPage();
            }

            MainPage = new AppShell();
        }

    }
}
