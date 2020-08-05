using IOL.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosAccion
    {
        private BD _context;
        public ServiciosAccion()
        {
            _context = new BD();
        }

        public bool Register(Acciones accion)
        {
            try
            {
                _context.Acciones.AddOrUpdate(accion);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public List<Acciones> GetAll()
        {
            return _context.Acciones.ToList();
        }
        public Acciones GetById(string id)
        {
            var accion = _context.Acciones.Where(x => x.Simbolo == id).SingleOrDefault();

            return accion;
        }

        public void Delete(string id)
        {
            var accion = _context.Acciones.Where(x => x.Simbolo == id).SingleOrDefault();
            if (accion != null)
            {
                _context.Acciones.Remove(accion);
                _context.SaveChanges();
            }
        }
    }
}
