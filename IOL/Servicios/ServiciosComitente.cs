using IOL.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosComitente
    {
        private BD _context;
        public ServiciosComitente()
        {
            _context = new BD();
        }

        public bool Register(Comitentes comitente)
        {
            try
            {
                _context.Comitentes.AddOrUpdate(comitente);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<Comitentes> GetAll()
        {
            return _context.Comitentes.ToList();
        }
        public List<Comitentes> GetByUser(string usuario)
        {
            return _context.Comitentes.Where(x=> x.Usuario.Contains(usuario)).ToList();
        }

        public List<Comitentes> GetByName(string apellido)
        {
            return _context.Comitentes.Where(x => x.Apellido.Contains(apellido)).ToList();
        }

        public Comitentes GetById(int id)
        {
            return _context.Comitentes.Where(x => x.Comitente == id).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var comitente = _context.Comitentes.Where(x => x.Comitente == id).SingleOrDefault();
            if (comitente != null)
            {
                _context.Comitentes.Remove(comitente);
                _context.SaveChanges();
            }
        }
    }
}
