using Code.Cloe.Domain.Models;
using System.Collections.ObjectModel;

namespace Code.Cloe.Infrastructure.UI;

public partial class SubjectPage : ContentPage
{
    private ObservableCollection<Subject> Subjects = new ObservableCollection<Subject>();

    public SubjectPage()
	{
		InitializeComponent();
		this.lvSubjects.ItemsSource = Subjects;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		//----- Se lanza un hilo para cargar el ListView
		//----- Las operaciones del ObservableCollection se deben hacer en el MainThread para que funcione
		Task.Factory.StartNew(async () => {
			MainThread.BeginInvokeOnMainThread(() => {
                this.Subjects.Clear();
            });
			var subject_service = Factories.Services.Create.ServiceBase<Subject>();
			foreach (var item in await subject_service.ListAsync())
			{
				MainThread.BeginInvokeOnMainThread(() => {
                    this.Subjects.Add(item);
                });                
			}            
        });
    }
}