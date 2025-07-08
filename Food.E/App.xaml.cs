using Microsoft.Maui.Controls;

namespace Food.E
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
