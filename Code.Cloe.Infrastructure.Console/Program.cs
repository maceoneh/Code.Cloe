// See https://aka.ms/new-console-template for more information
using Code.Cloe.Application.Services;
using Code.Cloe.Application.Services.Subjects;
using Code.Cloe.Application.Services.Subjects.DTO;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Factories.Services;
using Code.Cloe.Infrastructure.Proxies;
using Code.Cloe.Infrastructure.Proxies.Services.Subjects;
using Code.Cloe.Infrastructure.Repository;
using Code.Cloe.Infrastructure.Repository.Contexts;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Runtime.CompilerServices;

SubjectDTO ReadSubject()
{
    var subject = new SubjectDTO();
    Console.Write("Nombre: ");
    subject.Name = Console.ReadLine();
    Console.Write("Dirección: ");
    subject.Address = Console.ReadLine();
    Console.Write("Código postal: ");
    subject.PostalCode = Console.ReadLine();
    Console.Write("Población: ");
    subject.Location = Console.ReadLine();
    //Se cargan los telefonos
    subject.Contacts = new List<ContactDTO>();
    var exit = false;
    do
    {
        Console.Write("¿Desea agregar un teléfono de contacto?[S/N] ");
        if (Console.ReadLine() == "S")
        {
            var phone = new ContactDTO();
            Console.Write("Contacto: ");
            phone.Name = Console.ReadLine();
            Console.Write("Numero: ");
            phone.PhoneNumber = Console.ReadLine();
            subject.Contacts.Add(phone);
        }
        else
        {
            exit = true;
        }
    }
    while (!exit);
    return subject;
}
//-----
SubjectDTO? EditSubject(SubjectDTOProxy entry)
{
    Console.WriteLine("Se va a modificar el siguiente registro (INTRO mantiene la información):");
    Console.WriteLine(entry.ToString());
    var subject = entry.DTO;
    Console.Write("Nombre: ");
    var inputText = Console.ReadLine();
    subject.Name = string.IsNullOrWhiteSpace(inputText) ? subject.Name : inputText;
    Console.Write("Dirección: ");
    inputText = Console.ReadLine();
    subject.Address = string.IsNullOrWhiteSpace(inputText) ? subject.Address : inputText;
    Console.Write("Código postal: ");
    inputText = Console.ReadLine();
    subject.PostalCode = string.IsNullOrWhiteSpace(inputText) ? subject.PostalCode : inputText; ;
    Console.Write("Población: ");
    inputText = Console.ReadLine();
    subject.Location = string.IsNullOrWhiteSpace(inputText) ? subject.Location : inputText;
    //Se cargan los telefonos
    var exit = false;
    do
    {
        if (subject.Contacts == null)
        {
            subject.Contacts = new List<ContactDTO>();
        }
        //-----
        Console.WriteLine("Vias de contacto: ");
        foreach (var item in subject.Contacts)
        {
            Console.WriteLine(item);
        }
        //-----
        Console.Write("¿Desea agregar un teléfono de contacto?[S/N] ");
        if (Console.ReadLine() == "S")
        {
            var phone = new ContactDTO();
            Console.Write("Contacto: ");
            phone.Name = Console.ReadLine();
            Console.Write("Numero: ");
            phone.PhoneNumber = Console.ReadLine();
            subject.Contacts.Add(phone);
        }
        //-----
        Console.Write("¿Desea modificar un teléfono de contacto?[S/N] ");
        if (Console.ReadLine() == "S")
        {
            Console.Write("Indique el número de fila a modificar: ");
            var row = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(row))
            {
                var contact = subject.Contacts[int.Parse(row) - 1];
                Console.Write("Nombre: ");
                inputText = Console.ReadLine();
                contact.Name = string.IsNullOrWhiteSpace(inputText)?contact.Name : inputText;
                Console.Write("Teléfono: ");
                inputText = Console.ReadLine();
                contact.PhoneNumber = string.IsNullOrWhiteSpace(inputText) ? contact.PhoneNumber : inputText;
            }
        }
        //-----
        Console.Write("¿Desea seguir modificando las vias de contacto? ");
        if (Console.ReadLine() != "S")
        {
            exit = true;
        }
    }
    while (!exit);
    //-----
    Console.WriteLine(subject.ToString());
    Console.Write("¿Desea guardar la información acutal?[S/N] ");
    if (!String.Equals(Console.ReadLine(), "S"))
    {
        subject = null;
    }
    //-----
    return subject;
}
//-----
int Menu()
{
    Console.WriteLine("****************");
    Console.WriteLine("MENU");
    Console.WriteLine("****************");
    Console.WriteLine("1. Crear sujeto");
    Console.WriteLine("2. Modifica sujeto");
    Console.WriteLine("3. Eliminar sujeto");
    Console.WriteLine("4. Lista sujetos");
    Console.WriteLine("");
    Console.WriteLine("0. Salir");
    Console.WriteLine("");
    Console.Write("Seleccione una opción: ");
    var option = Console.ReadLine();
    try
    {
        if (option != null)
        {
            return int.Parse(option);
        }
        else
        {
            throw new Exception();
        }
    }
    catch
    {
        Console.WriteLine("");
        Console.WriteLine("ERROR!!!!!!!");
        Console.WriteLine("");
        return -1;
    }
}
//-----
async Task CreateSubject()
{
    var subjectService = new CreateSubjectService(Code.Cloe.Infrastructure.Repository.Factory.Repository.Create<Subject>());
    //-----
    var entry = await subjectService.AddAsync(ReadSubject());
}
//-----
async Task EditSubjects()
{
    var list = await ListSubjects();
    Console.Write("Indique la fila del elemento que desea editar: ");
    var fila = Console.ReadLine();
    if (fila != null)
    {
        var entry = EditSubject(list[int.Parse(fila) - 1]);
        if (entry != null)
        {
            var subjectService = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<SubjectOLD>();
            //subjectService.Edit(entry);
        }
    }
}
//-----
async Task<List<SubjectDTOProxy>> ListSubjects()
{
    var subjectService = new ListSubjectService(Code.Cloe.Infrastructure.Repository.Factory.Repository.Create<Subject>());
    //-----
    var list = await subjectService.ListAsync();
    var proxylist = new List<SubjectDTOProxy>();
    foreach (var item in list)
    {
        proxylist.Add(new SubjectDTOProxy(item));
    }
    //-----
    var rowCount = 0;
    foreach (var item in proxylist)
    {
        rowCount++;
        Console.WriteLine(rowCount.ToString() + " - " + item.ToString());
    }
    //-----
    return proxylist;
}
//-----
async Task DeleteSubjects()
{
    var list = await ListSubjects();
    Console.Write("Indique la fila del registro a eliminar: ");
    var row = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(row))
    { 
        var entry = list[int.Parse(row) - 1];
        var subjectService = new DeleteSubjectService(Code.Cloe.Infrastructure.Repository.Factory.Repository.Create<Subject>());
        await subjectService.DeleteAsync(entry.DTO);
    }
}
//----- Se obtiene la ruta donde guardar los datos de la aplicación
var localDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
localDataFolder = Path.Combine(localDataFolder, "Code.Cloe");
//----- Se comprueba que existe y si no se inicializa            
if (!Directory.Exists(localDataFolder))
{
    Directory.CreateDirectory(localDataFolder);
}
//----- Se guarda la ruta por si las clases Factory las necesitan para instanciar
Code.Cloe.Infrastructure.Repository.Factory.Context.RepositoryFolder = localDataFolder;
//-----
var sc = Code.Cloe.Infrastructure.Repository.Factory.Context.GetMigrate();
await sc.MigrateAsync();
//-----
var opt = -1;
do
{
    opt = Menu();
    switch (opt)
    {
        case 1:
            await CreateSubject(); break;
        case 4:
            await ListSubjects(); break;
        case 2:
            await EditSubjects(); break;
        case 3:
            await DeleteSubjects(); break;
    }
}
while (opt != 0);
Console.WriteLine("Adios!!!");