using Code.Cloe.Infrastructure.Repository.Contexts;

namespace Code.Cloe.Infrastructure.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //----- Se obtiene la ruta donde guardar los datos de la aplicación
            var localDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            localDataFolder = Path.Combine(localDataFolder, "Code.Cloe");
            //----- Se comprueba que existe y si no se inicializa            
            if (!Directory.Exists(localDataFolder))
            {
                Directory.CreateDirectory(localDataFolder);
            }
            //----- Se guarda la ruta por si las clases Factory las necesitan para instanciar
            Factories.Services.Create.RepositoryFolder = localDataFolder;
            //----- Se genera la estructura de la base de datos
            var repository = new RepositoryContext(localDataFolder);
            repository.Migrate();
        }
    }
}
