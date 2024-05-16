using AcmeSacAS2020.Core.Entidades;
using AcmeSacAS2020.Core.Repositorios;
using AcmeSacAS2020.Infraestructura.ContextoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSacAS2020.Infraestructura.ReglasNegocio
{
    public class ModuloRN : IModulo
    {
        Contexto_AcmeSacAS2020_BD contexto;
        public IEnumerable<Modulo> ListaModulo()
        {
            contexto = new Contexto_AcmeSacAS2020_BD();
            return contexto.modulos.ToList();
        }
    }
}
