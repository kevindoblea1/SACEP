using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class ConectarTbCarreras
    {
        SACEPEntities db = new SACEPEntities();
        public void GuardarCarrera(string code, string name, int cantidadClases,
                                        int cantidadMaestros)
        {
            Carrera Nuevo = new Carrera()
            {
                codigo_carrera = code,
                nombre_carrera = name,
                cantidad_clases = cantidadClases,
                cantidad_maestros = cantidadMaestros,
            };
            db.Carreras.Add(Nuevo);
            db.SaveChanges();
        }
        public List<Carrera> GetCarrera()
        {
            var Consulta = from carrera in db.Carreras
                           select carrera;

            return Consulta.ToList();
        }
        public void EliminarCarrera(string code)
        {
            Carrera carre = (from carrera in db.Carreras
                             where carrera.codigo_carrera == code
                             select carrera).FirstOrDefault();
            db.Carreras.Remove(carre);
            db.SaveChanges();
        }
        public void ActualizarCarrera(string code, string name, int cantidadClases,
                                        int cantidadMaestros)
        {
            Carrera carre = (from c in db.Carreras
                             where c.codigo_carrera == code
                             select c).FirstOrDefault();
            carre.codigo_carrera = code;
            carre.nombre_carrera = name;
            carre.cantidad_maestros = cantidadMaestros;
            carre.cantidad_clases = cantidadClases;
            db.SaveChanges();
        }
        public List<Carrera> Encontrar(string code)
        {
            var Consulta = from carre in db.Carreras select carre;

            return Consulta.Where(e => e.codigo_carrera == code).ToList();

        }
    }
}
