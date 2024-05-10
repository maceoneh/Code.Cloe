using Code.Cloe.Domain.Models;

namespace Code.Cloe.Infrastructure.UI;

public partial class NewSubjectPage : ContentPage
{
	public NewSubjectPage()
	{
		InitializeComponent();
        this.btSave.Clicked += BtSave_Clicked;
	}

    private void CheckEditors(params Editor[] entries)
    { 
        foreach (var editor in entries)
        {
            if (editor.Text.Equals(string.Empty))
            {
                throw new Exception("Algunos campos no fueron rellenados");
            }
        }
    }

    private async void BtSave_Clicked(object? sender, EventArgs e)
    {
        try
        {
            this.CheckEditors(this.eAddress, this.eLocation, this.eLocation, this.ePC);            
        }
        catch (Exception ex)
        {
            await this.DisplayAlert("ERROR", ex.Message, "Salir");
        }
        //-----
        var subjectService = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<Subject>();
        //-----            
        var newSubject = await subjectService.AddAsync(new Subject()
        {
            Name = this.eName.Text,
            Address = this.eAddress.Text,
            Location = this.eLocation.Text,
            PostalCode = this.ePC.Text
        });
        //-----
        await Navigation.PopAsync();
    }
}