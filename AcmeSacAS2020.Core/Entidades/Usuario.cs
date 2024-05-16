using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSacAS2020.Core.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string nom_usuario { get; set; }
        public string ape_usuario { get; set; }

        public virtual ICollection<Rol> rol { get; set; }
    }
}
