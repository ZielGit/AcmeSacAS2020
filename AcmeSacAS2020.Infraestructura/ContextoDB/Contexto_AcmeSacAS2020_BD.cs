using AcmeSacAS2020.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSacAS2020.Infraestructura.ContextoDB
{
    public class Contexto_AcmeSacAS2020_BD :DbContext
    {
        public Contexto_AcmeSacAS2020_BD() : base("name=Contexto_AcmeSacAS2020_BD_Con") { }

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Rol> rols { get; set; }
        public DbSet<Modulo> modulos { get; set; }
    }
}
