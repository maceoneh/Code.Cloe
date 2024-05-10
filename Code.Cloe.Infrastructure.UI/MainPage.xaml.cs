namespace Code.Cloe.Infrastructure.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.btAddSubject.Clicked += BtAddSubject_Clicked;
            this.btSubject.Clicked += BtSubject_Clicked;
        }

        private async void BtSubject_Clicked(object? sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new SubjectPage());
        }

        private async void BtAddSubject_Clicked(object? sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new NewSubjectPage());
        }
    }

}
