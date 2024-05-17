using Code.Cloe.Application.Services.Subjects.DTO;
using Code.Cloe.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.ObjectModel;

namespace Code.Cloe.Infrastructure.UI;

public partial class ContactPage : ContentPage
{
	private ObservableCollection<ContactDTO> Contacts = new ObservableCollection<ContactDTO>();
	private SubjectDTO Subject { get; }
	public ContactPage(SubjectDTO subject)
	{
		InitializeComponent();
        this.btAddContact.Clicked += BtAddContact_Clicked;
		this.Subject = subject;		
	}

    private void BtAddContact_Clicked(object? sender, EventArgs e)
    {
        //this.Contacts.Add(new Contact { 
        //    NameContact = this.bContact.NameContact,
        //    PhoneNumber = this.bContact.PhoneNumber,
        //    ID = this.bContact.ID,
        //    SubjectID = this.bContact.SubjectID
        //});
        //this.bContact.NameContact = "";
        //this.bContact.PhoneNumber = "";        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		this.Contacts.Clear();
        if (this.Subject.Contacts == null)
        {
            this.Subject.Contacts = new List<ContactDTO>();
        }
        foreach (var item in this.Subject.Contacts)
		{ 
			this.Contacts.Add(item);
		}
    }
}