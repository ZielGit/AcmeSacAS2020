using AcmeSacAS2020.Core.Entidades;
using AcmeSacAS2020.Core.Repositorios;
using AcmeSacAS2020.Infraestructura.ContextoDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSacAS2020.Infraestructura.ReglasNegocio
{
    public class UsuarioRN : IUsuario
    {
        Contexto_AcmeSacAS2020_BD contexto;
        public void Agregar(Usuario usuario)
        {
            contexto = new Contexto_AcmeSacAS2020_BD();
            contexto.usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public Usuario Buscar(int Id)
        {
            contexto = new Contexto_AcmeSacAS2020_BD();
            var resultado = contexto.usuarios.Find(Id);
            return resultado;
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            contexto = new Contexto_AcmeSacAS2020_BD();
            return contexto.usuarios.ToList();
        }

        public IEnumerable<oUsuario> ListarUsuarioCampos()
        {
            contexto = new Contexto_AcmeSacAS2020_BD();
            return contexto.usuarios.Select(u => new oUsuario() { Codigo = u.Id, Apellidos = u.ape_usuario + " " + u.nom_usuario })
                .ToList();
        }

        public void Modificar(Usuario usuario)
        {
            //contexto = new Contexto_AcmeSacAS2020_BD();
            contexto.Entry(usuario).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
