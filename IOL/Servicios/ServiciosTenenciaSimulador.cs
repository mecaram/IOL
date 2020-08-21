using IOL.EntityFrameWork;
using System;
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
            return _context.TenenciaSimuladores.Where(x => x.IdSimulacion == id).SingleOrDefault();
        }
        public double GetDisponibleParaOperar(int idSimulacion)
        {
            return Convert.ToDouble(_context.TenenciaSimuladores.Where(x => x.IdSimulacion == idSimulacion).SingleOrDefault().DisponibleParaOperar);
        }

        public double GetActivosValorizados(int idSimulacion)
        {
            return Convert.ToDouble(_context.RuedasDetalleSimulador.Where(x => x.IdSimulacion == idSimulacion && x.Estado == "Comprado").Sum(x => x.ImporteCompra));
        }
        public double GetTotalTenencia(int idSimulacion)
        {
            return Convert.ToDouble(_context.TenenciaSimuladores.Where(x => x.IdSimulacion == idSimulacion ).SingleOrDefault().TotalTenencia);
        }

        public void SetActualizarTenenciaPorVenta(int idSimulacion, decimal importe)
        {
            var tenencia = GetById(idSimulacion);
            if (tenencia != null)
            {
                tenencia.DisponibleParaOperar = tenencia.DisponibleParaOperar + importe;
                tenencia.ActivosValorizados = tenencia.ActivosValorizados - importe;
                tenencia.TotalTenencia = tenencia.DisponibleParaOperar + tenencia.ActivosValorizados;
                tenencia.Fecha = DateTime.Now;
                Register(tenencia);
            }
        }

        public void SetActualizarTenenciaPorCompra(int idSimulacion, decimal importe)
        {
            var tenencia = GetById(idSimulacion);
            if (tenencia != null)
            {
                tenencia.DisponibleParaOperar = tenencia.DisponibleParaOperar - importe;
                tenencia.ActivosValorizados = tenencia.ActivosValorizados + importe;
                tenencia.TotalTenencia = tenencia.DisponibleParaOperar + tenencia.ActivosValorizados;
                tenencia.Fecha = DateTime.Now;
                Register(tenencia);
            }
        }

        public void Delete(int id)
        {
            var tenencia = _context.TenenciaSimuladores.Where(x => x.IdSimulacion == id).SingleOrDefault();
            if (tenencia != null)
            {
                _context.TenenciaSimuladores.Remove(tenencia);
                _context.SaveChanges();
            }
        }
    }
}
