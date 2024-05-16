using Code.Cloe.Domain.Models;
using ContactOLD = Code.Cloe.Domain.Models.ContactOLD;

namespace Code.Cloe.Infrastructure.UI;

public partial class NewSubjectPage : ContentPage
{
    private SubjectOLD Subject { get; set; } = new SubjectOLD() { Contacts = new List<ContactOLD>() };
    
	public NewSubjectPage()
	{
		InitializeComponent();
        this.btSave.Clicked += BtSave_Clicked;
        this.btAddContact.Clicked += BtAddContact_Clicked;        
	}

    private async void BtAddContact_Clicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new ContactPage(this.Subject));
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
            this.CheckEditors(this.eAddress, this.eLocation, this.eLocation, this.ePC, this.eProvince);            
        }
        catch (Exception ex)
        {
            await this.DisplayAlert("ERROR", ex.Message, "Salir");
        }
        //-----
        var subjectService = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<SubjectOLD>();
        //-----
        this.Subject.Name = this.eName.Text;
        this.Subject.Address = this.eAddress.Text;
        this.Subject.PostalCode = this.ePC.Text;
        this.Subject.Province = this.eProvince.Text;
        this.Subject.Location = this.eLocation.Text;
        var newSubject = await subjectService.AddAsync(this.Subject);
        //-----
        await Navigation.PopAsync();
    }
}