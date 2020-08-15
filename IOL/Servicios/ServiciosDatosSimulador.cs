using IOL.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosDatosSimulador
    {
        private BD _context;
        public ServiciosDatosSimulador()
        {
            _context = new BD();
        }

        public bool Register(RuedasDatosSimulador ruedaDatosSimulador)
        {
            try
            {
                _context.RuedasDatosSimulador.AddOrUpdate(ruedaDatosSimulador);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public List<RuedasDatosSimulador> GetAll()
        {
            return _context.RuedasDatosSimulador.ToList();
        }
        public RuedasDatosSimulador GetByIdRueda(int idRueda)
        {
            return _context.RuedasDatosSimulador.Where(x => x.IdRueda == idRueda).SingleOrDefault();
        }

        public RuedasDatosSimulador GetByIdSimulador(int idRueda, int idSimulador)
        {
            return _context.RuedasDatosSimulador.Where(x => x.IdRueda == idRueda && x.IdSimulador == idSimulador).SingleOrDefault();
        }

        public double GetPorcCompraSimulador(int idRueda, int idSimulador)
        {
            return Convert.ToDouble(_context.RuedasDatosSimulador.Where(x => x.IdRueda == idRueda && x.IdSimulador == idSimulador).SingleOrDefault().PorcCompra);
        }

        public double GetPorcVentaSimulador(int idRueda, int idSimulador)
        {
            return Convert.ToDouble(_context.RuedasDatosSimulador.Where(x => x.IdRueda == idRueda && x.IdSimulador == idSimulador).SingleOrDefault().PorcVenta);
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
