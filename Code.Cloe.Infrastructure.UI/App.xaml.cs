using MAUIApplication = Microsoft.Maui.Controls.Application;
namespace Code.Cloe.Infrastructure.UI
{
    public partial class App : MAUIApplication
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
