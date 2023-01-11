using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class ConectarDbSolicitudes
    {
        SACEPEntities db = new SACEPEntities();
        public string  UltimoID()
        {
            var LastRegister = db.Solicitudes
            .OrderByDescending(x => x.fecha)
            .First().codigo_solicitud;
            return LastRegister.ToString();
        }
        public void GuardarUsuario(string code, string pass, string id,
                                        string name, string genero,
                                        string correo, string tel, string rol)
        {
            Usuario Nuevo = new Usuario()
            {
                //seteamos los valores enviados por el metodo con sus contrapartes de de la base de datos
                codigo_usuario = code,
                password = pass,
                identidad = id,
                nombre_usuario = name,
                genero = genero,
                correo_usuario = correo,
                telefono = tel,
                rol = rol,
            };
            //mandamos los registros a la db
            db.Usuarios.Add(Nuevo);
            db.SaveChanges();
        }
        public List<Usuario> GetUsuario()
        {
            //declaramos una variable y le mandamos todo lo que tiene la ntiedad empleado
            var Consulta = from user in db.Usuarios
                           select user;

            return Consulta.ToList();
        }
        public void EliminarUsuario(string code)
        {
            Usuario user = (from usuario in db.Usuarios
                            where usuario.codigo_usuario == code
                            select usuario).FirstOrDefault();
            db.Usuarios.Remove(user);
            db.SaveChanges();
        }
        public void ActualizarUsuario(string code, string pass, string id,
                                        string name, string genero,
                                        string correo, string tel, string rol)
        {
            Usuario user = (from e in db.Usuarios
                            where e.codigo_usuario == code
                            select e).FirstOrDefault();
            user.codigo_usuario = code;
            user.password = pass;
            user.identidad = id;
            user.nombre_usuario = name;
            user.genero = genero;
            user.correo_usuario = correo;
            user.telefono = tel;
            user.rol = rol;
            db.SaveChanges();
        }
        public List<Usuario> Encontrar(string code)
        {
            var Consulta = from user in db.Usuarios select user;

            return Consulta.Where(e => e.codigo_usuario == code).ToList();

        }
        public string ObtenerRol(string code)
        {
            Usuario user = (from e in db.Usuarios
                            where e.codigo_usuario == code
                            select e).FirstOrDefault();
            return user.rol;
        }
        public string ObtenerNombre(string code)
        {
            Usuario user = (from e in db.Usuarios
                            where e.codigo_usuario == code
                            select e).FirstOrDefault();
            return user.nombre_usuario;
        }
    }
}