using IOL.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Management;

namespace IOL.Servicios
{
    public class ServiciosRueda
    {
        private BD _context;
        public ServiciosRueda()
        {
            _context = new BD();
        }

        public bool Register(EntityFrameWork.Ruedas rueda)
        {
            try
            {
                _context.Ruedas.AddOrUpdate(rueda);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public void SetAbrirRueda(int idRueda)
        {
            var rueda = GetById(idRueda);
            if (rueda != null)
            {
                rueda.Estado = "Abierto";
                Register(rueda);
            }
        }

        public void SetCerrarRueda(int idRueda)
        {
            var rueda = GetById(idRueda);
            if (rueda != null)
            {
                rueda.Estado = "Finalizado";
                Register(rueda);
            }
        }

        public List<EntityFrameWork.Ruedas> GetAll()
        {
            return _context.Ruedas.ToList();
        }
        public EntityFrameWork.Ruedas GetById(int id)
        {
            return _context.Ruedas.Where(x => x.IdRueda == id).SingleOrDefault();
        }

        public EntityFrameWork.Ruedas GetLast()
        {
            return _context.Ruedas.LastOrDefault();
        }

        public EntityFrameWork.Ruedas GetByDate(DateTime fecha, int comitente)
        {
            return _context.Ruedas.Where(x => x.FechaRueda.Date == fecha.Date && x.Comitente == comitente).SingleOrDefault();
        }

        public string GetEstadoRueda(int id)
        {
            return _context.Ruedas.Where(x => x.IdRueda == id).SingleOrDefault().Estado;
        }

        public void Delete(int id)
        {
            var ruedas = _context.Ruedas.Where(x => x.IdRueda == id).SingleOrDefault();
            if (ruedas != null)
            {
                _context.Ruedas.Remove(ruedas);

                var ruedasDetalle = _context.RuedasDetalle.Where(x => x.IdRuedaActual == id).ToList();
                if (ruedasDetalle != null)
                    _context.RuedasDetalle.RemoveRange(ruedasDetalle);

                var ruedasDatosSimulador = _context.RuedasDatosSimulador.Where(x => x.IdRueda == id).ToList();
                if (ruedasDatosSimulador != null)
                    _context.RuedasDatosSimulador.RemoveRange(ruedasDatosSimulador);

                var ruedasDetalleSimulador = _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == id).ToList();
                if (ruedasDetalleSimulador != null)
                    _context.RuedasDetalleSimulador.RemoveRange(ruedasDetalleSimulador);

                _context.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            var ruedas = _context.Ruedas.ToList();
            if (ruedas != null)
            {
                _context.Ruedas.RemoveRange(ruedas);

                var ruedasDetalle = _context.RuedasDetalle.ToList();
                if (ruedasDetalle != null)
                    _context.RuedasDetalle.RemoveRange(ruedasDetalle);

                var ruedasDatosSimulador = _context.RuedasDatosSimulador.ToList();
                if (ruedasDatosSimulador != null)
                    _context.RuedasDatosSimulador.RemoveRange(ruedasDatosSimulador);

                var ruedasDetalleSimulador = _context.RuedasDetalleSimulador.ToList();
                if (ruedasDetalleSimulador != null)
                    _context.RuedasDetalleSimulador.RemoveRange(ruedasDetalleSimulador);

                _context.SaveChanges();
            }
        }
    }
}
