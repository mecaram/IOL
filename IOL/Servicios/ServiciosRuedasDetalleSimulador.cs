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

        public List<RuedasDetalleSimulador> GetAll()
        {
            return _context.RuedasDetalleSimulador.ToList();
        }
        public RuedasDetalleSimulador GetById(int id)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdRuedaDetalle == id).SingleOrDefault();
        }

        public decimal GetActivosValorizados(int idSimulacion)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdSimulacion == idSimulacion && x.Estado == "Comprado").Sum(x => x.ImporteCompra);
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
