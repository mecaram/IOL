using IOL.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


namespace IOL.Servicios
{
    public class ServiciosInformeFinal
    {
        private BD _context;
        public ServiciosInformeFinal()
        {
            _context = new BD();
        }

        public bool Register(EntityFrameWork.InformeFinal informeFinal)
        {
            try
            {
                _context.InformeFinal.AddOrUpdate(informeFinal);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public List<EntityFrameWork.InformeFinal> GetAll()
        {
            return _context.InformeFinal.ToList();
        }
        public EntityFrameWork.InformeFinal GetById(int id)
        {
            return _context.InformeFinal.Where(x => x.IdFormeFinal == id).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var informeFinal = _context.InformeFinal.Where(x => x.IdFormeFinal == id).SingleOrDefault();
            if (informeFinal != null)
            {
                _context.InformeFinal.Remove(informeFinal);
                _context.SaveChanges();
            }
        }

    }
}
