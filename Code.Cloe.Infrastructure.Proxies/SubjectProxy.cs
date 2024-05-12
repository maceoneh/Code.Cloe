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
        public Task<List<Phone>?> Phones 
        {
            get
            {

                if (this.Model.Phones == null)
                {
                    this.Model.Phones = new List<Phone>();

                    //-----
                    var subjectService = Create.ServiceBase<Phone>();
                }
                //-----
                return this.Model.Phones;
            }
        }
    }
}
