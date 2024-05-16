using AcmeSacAS2020.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSacAS2020.Core.Repositorios
{
    public interface IReportes
    {
        IQueryable<oReporteUsuario> oReporteUsuariosLista();
    }
}
