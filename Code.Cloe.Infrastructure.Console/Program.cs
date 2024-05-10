// See https://aka.ms/new-console-template for more information
using Code.Cloe.Application.Services;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository;
using Code.Cloe.Infrastructure.Repository.Contexts;

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
    return subject;
}

int Menu()
{
    Console.WriteLine("MENU");
    Console.WriteLine("****************");
    Console.WriteLine("1. Crear cliente");
    Console.WriteLine("2. Lista clientes");
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

async Task CreateSubject()
{
    var ss = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<Subject>();
    //-----
    var entry = await ss.AddAsync(ReadSubject());
}

async Task ListSubjects()
{
    var ss = Code.Cloe.Infrastructure.Factories.Services.Create.ServiceBase<Subject>();
    //-----
    var list = await ss.ListAsync();
    //-----
    foreach (var item in list)
    {
        Console.WriteLine(item);
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
Code.Cloe.Infrastructure.Factories.Services.Create.RepositoryFolder = localDataFolder;
//-----
var sc = new RepositoryContext();
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
    }
}
while (opt != 0);
Console.WriteLine("Adios!!!");