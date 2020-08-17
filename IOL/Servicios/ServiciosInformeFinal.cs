using ClosedXML;
using IOL.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


namespace IOL.Servicios
{
    public class ServiciosInformeFinal
    {
        private readonly ServiciosAccion _serviceAcciones = new ServiciosAccion();
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

        public void SetBestDailyVariation(int idRueda)
        {
            var acciones = _serviceAcciones.GetAll();
            foreach (EntityFrameWork.Acciones regAcciones in acciones)
            {
                var ruedas = _context.InformeFinal.Where(x => x.IdRueda == idRueda && x.Simbolo == regAcciones.Simbolo).OrderByDescending(x => x.VariacionDiaria).FirstOrDefault();
                if (ruedas != null)
                {
                    ruedas.MejorVariacionDiaria = true;
                    _context.InformeFinal.AddOrUpdate(ruedas);
                    _context.SaveChanges();
                }
            }
        }

        public void SetBestweeklyVariation()
        {
            var acciones = _serviceAcciones.GetAll();
            foreach (EntityFrameWork.Acciones regAcciones in acciones)
            {
                var ruedas = _context.InformeFinal.Where(x => x.Simbolo == regAcciones.Simbolo).OrderByDescending(x => x.VariacionDiaria).FirstOrDefault();
                if (ruedas != null)
                {
                    ruedas.MejorVariacionSemanal = true;
                    _context.InformeFinal.AddOrUpdate(ruedas);
                    _context.SaveChanges();
                }
            }
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
