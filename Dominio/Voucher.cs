using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Voucher
    {
        private string Codigo { get; set; }
        private Cliente Cliente { get; set; }
        private DateTime Fecha { get; set; }
        private Articulo Articulo { get; set; }
    }
}

