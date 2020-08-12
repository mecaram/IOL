using IOL.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosTenenciaSimulador
    {
        private BD _context;
        public ServiciosTenenciaSimulador()
        {
            _context = new BD();
        }
        public bool Register(TenenciaSimuladores tenencia)
        {
            try
            {
                _context.TenenciaSimuladores.AddOrUpdate(tenencia);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public List<TenenciaSimuladores> GetAll()
        {
            return _context.TenenciaSimuladores.ToList();
        }
        public TenenciaSimuladores GetById(int id)
        {
            return _context.TenenciaSimuladores.Where(x => x.IdSimulador == id).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var tenencia = _context.TenenciaSimuladores.Where(x => x.IdSimulador == id).SingleOrDefault();
            if (tenencia != null)
            {
                _context.TenenciaSimuladores.Remove(tenencia);
                _context.SaveChanges();
            }
        }
    }
}
