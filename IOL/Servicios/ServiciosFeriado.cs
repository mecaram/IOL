using IOL.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosFeriado
    {
        private BD _context;
        public ServiciosFeriado()
        {
            _context = new BD();
        }
        public bool Register(EntityFrameWork.Feriados feriado)
        {
            try
            {
                _context.Feriados.AddOrUpdate(feriado);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public List<EntityFrameWork.Feriados> GetAll()
        {
            return _context.Feriados.ToList();
        }
        public EntityFrameWork.Feriados GetById(int id)
        {
            var feriado = _context.Feriados.Where(x => x.IdFeriado == id).SingleOrDefault();

            return feriado;
        }

        public void Delete(int id)
        {
            var feriado = _context.Feriados.Where(x => x.IdFeriado == id).SingleOrDefault();
            if (feriado != null)
            {
                _context.Feriados.Remove(feriado);
                _context.SaveChanges();
            }
        }
    }
}
