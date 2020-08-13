using IOL.EntityFrameWork;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosRuedasDetalleSimulador
    {
        private BD _context;
        public ServiciosRuedasDetalleSimulador()
        {
            _context = new BD();
        }
        public bool Register(RuedasDetalleSimulador ruedasDetalleSimulador)
        {
            try
            {
                _context.RuedasDetalleSimulador.AddOrUpdate(ruedasDetalleSimulador);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public void RegisterActionsYesterday(int IdRuedaActual)
        {
            var actions = _context.RuedasDetalleSimulador.Where(x => x.Estado == "Comprado" && x.IdRuedaActual != IdRuedaActual && IdRuedaActual == x.IdRuedaCompra).ToList();
            foreach (RuedasDetalleSimulador regAction in actions)
            {
                regAction.IdRuedaActual = IdRuedaActual;
                _context.RuedasDetalleSimulador.AddOrUpdate(regAction);
            }
            _context.SaveChanges();
        }
        public List<RuedasDetalleSimulador> GetAll()
        {
            return _context.RuedasDetalleSimulador.ToList();
        }
        public RuedasDetalleSimulador GetById(int idRuedaDetalle)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdRuedaDetalle == idRuedaDetalle).SingleOrDefault();
        }

        public List<RuedasDetalleSimulador> GetByIdSimulacion(int idRueda, int idSimulacion)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == idRueda && x.IdSimulacion == idSimulacion).ToList();
        }

        public void Delete(int id)
        {
            var ruedasDetalleSimulador = _context.RuedasDetalleSimulador.Where(x => x.IdRuedaDetalle == id).SingleOrDefault();
            if (ruedasDetalleSimulador != null)
            {
                _context.RuedasDetalleSimulador.Remove(ruedasDetalleSimulador);
                _context.SaveChanges();
            }
        }

    }
}
