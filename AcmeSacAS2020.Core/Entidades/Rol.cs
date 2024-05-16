using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSacAS2020.Core.Entidades
{
    public class Rol
    {
        public int Id { get; set; }
        public string nom_rol { get; set; }
        public string UsuarioId { get; set; }

        public virtual Usuario UsuarioRol { get; set; }

    }
}
