using AcmeSacAS2020.Core.Entidades;
using AcmeSacAS2020.Infraestructura.ContextoDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSacAS2020.Infraestructura.Inicializador
{
    class AcmeSacAS2020_Inicializador: DropCreateDatabaseAlways<Contexto_AcmeSacAS2020_BD>
    {
        protected override void Seed(Contexto_AcmeSacAS2020_BD context)
        {
            context.usuarios.Add(new Usuario { nom_usuario = "Nombre Usuario" });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
