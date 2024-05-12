// See https://aka.ms/new-console-template for more information
using Code.Cloe.Application.Services;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Proxies;
using Code.Cloe.Infrastructure.Repository;
using Code.Cloe.Infrastructure.Repository.Contexts;
using System.Runtime.CompilerServices;

Subject ReadSubject()
{
    var subject = new Subject();
    Console.WriteLine("Nombre: ");
    subject.Name = Console.ReadLine();
    Console.WriteLine("Dirección: ");
    subject.Address = Console.ReadLine();
    Console.WriteLine("Código postal: ");
    subject.PostalCode = Console.ReadLine();
    Console.WriteLine("Población: ");
    subject.Location = Console.ReadLine();
    //Se cargan los telefonos
    subject.Phones = new List<Phone>();
    var exit = false;
    do
    {
        Console.WriteLine("¿Desea agregar un teléfono de contacto?[S/N]");
        if (Console.ReadLine() == "S")
        {
            var phone = new Phone();
            Console.WriteLine("Contacto: ");
            phone.NameContact = Console.ReadLine();
            Console.WriteLine("Numero: ");
            phone.PhoneNumber = Console.ReadLine();
            subject.Phones.Add(phone);
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
Subject? EditSubject(SubjectProxy entry)
{
    Console.WriteLine("Se va a modificar el siguiente registro (INTRO mantiene la información):");
    Console.WriteLine(entry.ToString());
    var subject = entry.Model;
    Console.WriteLine("Nombre: ");
    var inputText = Console.ReadLine();
    subject.Name = string.IsNullOrWhiteSpace(inputText) ? subject.Name : inputText;
    Console.WriteLine("Dirección: ");
    inputText = Console.ReadLine();
    subject.Address = string.IsNullOrWhiteSpace(inputText) ? subject.Address : inputText;
    Console.WriteLine("Código postal: ");
    inputText = Console.ReadLine();
    subject.PostalCode = string.IsNullOrWhiteSpace(inputText) ? subject.PostalCode : inputText; ;
    Console.WriteLine("Población: ");
    inputText = Console.ReadLine();
    subject.Location = string.IsNullOrWhiteSpace(inputText) ? subject.Location : inputText;
    //Se cargan los telefonos
    var exit = false;
    do
    {
        if (subject.Phones == null)
        { 
            subject.Phones = new List<Phone>();
        }
        Console.WriteLine("¿Desea agregar un teléfono de contacto?[S/N]");
        if (Console.ReadLine() == "S")
        {
            var phone = new Phone();
            Console.WriteLine("Contacto: ");
            phone.NameContact = Console.ReadLine();
            Console.WriteLine("Numero: ");
            phone.PhoneNumber = Console.ReadLine();
            subject.Phones.Add(phone);
        }
        else
        {
            exit = true;
        }
    }
    while (!exit);
    //-----
    Console.WriteLine(subject.ToString());
    Console.WriteLine("¿Desea guardar la información acutal?[S/N]");
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
    Console.WriteLine("MENU");
    Console.WriteLine("****************");
    Console.WriteLine("1. Crear sujeto");
    Console.WriteLine("2. Lista sujetos");
    Console.WriteLine("3. Modifica sujetos");
    Console.WriteLine("");
    Console.WriteLine("0. Salir");
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
    var ss = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<Subject>();
    //-----
    var entry = await ss.AddAsync(ReadSubject());
}
//-----
async Task EditSubjects()
{
    var list = await ListSubjects();
    Console.WriteLine("Indique la fila del elemento que desea editar: ");
    var fila = Console.ReadLine();
    if (fila != null)
    {
        var entry = EditSubject(list[int.Parse(fila) - 1]);
        if (entry != null)
        {
            var subjectService = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<Subject>();
            subjectService.Edit(entry);
        }
    }
}
//-----
async Task<List<SubjectProxy>> ListSubjects()
{
    var ss = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<Subject>();
    //-----
    var list = await ss.ListAsync();
    var proxylist = new List<SubjectProxy>();
    foreach (var item in list)
    { 
        proxylist.Add(new SubjectProxy(item));
    }
    //-----
    foreach (var item in proxylist)
    {
        Console.WriteLine(item);
    }
    //-----
    return proxylist;
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
Code.Cloe.Infrastructure.Factories.Services.Create.RepositoryFolder = localDataFolder;
//-----
var sc = new RepositoryContext(localDataFolder);
sc.Migrate();
//-----
var opt = -1;
do
{
    opt = Menu();
    switch (opt)
    {
        case 1:
            await CreateSubject(); break;
        case 2:
            await ListSubjects(); break;
        case 3:
            await EditSubjects(); break;
    }
}
while (opt != 0);
Console.WriteLine("Adios!!!");