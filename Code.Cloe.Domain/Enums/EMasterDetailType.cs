using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Enums
{
    public enum EMasterDetailType
    {
        /// <summary>
        /// Orden de trabajo
        /// </summary>
        Order = 1,

        /// <summary>
        /// Gasto
        /// </summary>
        Bill = -1,

        /// <summary>
        /// Previsión de gastos
        /// </summary>
        ExpensiveForecast = -2
    }
}
