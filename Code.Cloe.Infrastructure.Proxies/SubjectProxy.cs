using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Factories.Services;
using System.ComponentModel.DataAnnotations;

namespace Code.Cloe.Infrastructure.Proxies
{
    public class SubjectProxy
    {
        private Subject Model { get; }

        public SubjectProxy(Subject model)
        {
            this.Model = model;
        }

        public Guid ID => this.Model.ID;

        /// <summary>
        /// Nombre
        /// </summary>
        public string? Name => this.Model.Name;

        /// <summary>
        /// Dirección
        /// </summary>
        public string? Address => this.Model.Address;

        /// <summary>
        /// Código postal
        /// </summary>        
        public string? PostalCode => this.Model.PostalCode;

        /// <summary>
        /// Población
        /// </summary>
        public string? Location => this.Model.Location;

        /// <summary>
        /// Provincia
        /// </summary>
        public string? Province => this.Model.Province;

        /// <summary>
        /// Listado de teléfonos asociados al sujeto
        /// </summary>
        public Task<List<Phone>?> PhonesAsync 
        {
            get
            {
                return Task.Factory.StartNew<List<Phone>?>(() => 
                {
                    if (this.Model.Phones == null)
                    {
                        this.Model.Phones = new List<Phone>();
                        //-----
                        var phoneService = Create.ServiceBase<Phone>();
                        var phones = phoneService.Where(p => p.SubjectID == this.ID);
                        foreach (var item in phones)
                        { 
                            this.Model.Phones.Add(item);
                        }
                    }
                    return this.Model.Phones;
                });                
            }
        }

        public List<Phone>? Phones
        {
            get
            {
                if (this.Model.Phones == null)
                {
                    this.Model.Phones = new List<Phone>();
                    //-----
                    var phoneService = Create.ServiceBase<Phone>();
                    var phones = phoneService.Where(p => p.SubjectID == this.ID);
                    foreach (var item in phones)
                    {
                        this.Model.Phones.Add(item);
                    }
                }
                return this.Model.Phones;
            }
        }

        public override string ToString()
        {
            var text = "Nombre: " + this.Name + " Dirección: " + this.Address + " Población: " + this.Location + " Provincia: " + this.Province + " CP: " + this.PostalCode + " ";
            if (this.Phones != null)
            {
                foreach (var phone in this.Phones)
                {
                    text += phone.ToString() + " ";
                }
            }
            return text.TrimEnd();
        }
    }
}
