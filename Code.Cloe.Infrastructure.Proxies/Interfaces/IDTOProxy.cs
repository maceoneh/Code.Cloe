using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Proxies.Interfaces
{
    public interface IDTOProxy<TDto>
    {
        /// <summary>
        /// Devuelve el modelo de origen
        /// </summary>
        TDto DTO { get; }

        /// <summary>
        /// Indica si la información adicional se ha cargado
        /// </summary>
        bool DataLoaded { get; }

        /// <summary>
        /// Carga toda la información adicional
        /// </summary>
        void LoadData();

        /// <summary>
        /// Carga toda la información adicional
        /// </summary>
        Task LoadDataAsync();

        /// <summary>
        /// Restaura la información adicional para forzar ser releida
        /// </summary>
        void Initialize();
    }
}
