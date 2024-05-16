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
    public class Reportes : IReportes
    {
        Contexto_AcmeSacAS2020_BD contexto;
        public IQueryable<oReporteUsuario> oReporteUsuariosLista()
        {
            contexto = new Contexto_AcmeSacAS2020_BD();
            return contexto.usuarios
                .Select(u => new oReporteUsuario() { Codigo = u.Id, Apellidos = u.ape_usuario + " " + u.nom_usuario })
                .AsQueryable<oReporteUsuario>();
        }
    }
}
