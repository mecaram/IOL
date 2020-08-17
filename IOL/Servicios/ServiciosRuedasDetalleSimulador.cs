using IOL.EntityFrameWork;
using System;
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
        public void RegisterActionsPrice(int IdRuedaActual, string simbolo, decimal ultimoprecio)
        {
            var action = _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == IdRuedaActual && x.Simbolo == simbolo && x.Estado == "Comprado").SingleOrDefault();
            if (action != null)
            {
                action.UltimoPrecio = ultimoprecio;
                action.FechaUltimoPrecio = DateTime.Now;
                _context.RuedasDetalleSimulador.AddOrUpdate(action);
                _context.SaveChanges();
            }
        }

        public void RegisterSale(int idRuedaDetalle, int idRuedaActual, double precioVenta, double importe)
        {
            var action = _context.RuedasDetalleSimulador.Where(x => x.IdRuedaDetalle == idRuedaDetalle).SingleOrDefault();
            if (action != null)
            {
                action.IdRuedaVenta = idRuedaActual;
                action.PrecioVenta = (decimal)precioVenta;
                action.UltimoPrecio = (decimal)precioVenta;
                action.ImporteVenta = (decimal)importe;
                action.FechaVenta = DateTime.Now;
                action.FechaUltimoPrecio = DateTime.Now;
                _context.RuedasDetalleSimulador.AddOrUpdate(action);
                _context.SaveChanges();
            }
        }

        public void UpdateVariations(int IdRuedaActual)
        {
            var regAction = _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == IdRuedaActual && x.Estado == "Comprado" && x.UltimoPrecio > 0).ToList();
            if (regAction != null)
            {
                foreach (RuedasDetalleSimulador actionPrice in regAction)
                {
                    actionPrice.Variacionenpesos = (actionPrice.UltimoPrecio - actionPrice.PrecioCompra) * actionPrice.Cantidad;
                    actionPrice.Variacionenporcentajes = ((actionPrice.PrecioVenta / actionPrice.PrecioCompra) - 1) * 100;
                    _context.RuedasDetalleSimulador.AddOrUpdate(actionPrice);
                }
                _context.SaveChanges();
            }

            regAction = _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == IdRuedaActual && x.Estado == "Comprado" && x.UltimoPrecio == 0).ToList();
            if (regAction != null)
            {
                foreach (RuedasDetalleSimulador actionPrice in regAction)
                {
                    actionPrice.Variacionenpesos = 0;
                    actionPrice.Variacionenporcentajes = 0;
                    _context.RuedasDetalleSimulador.AddOrUpdate(actionPrice);
                }
                _context.SaveChanges();
            }

            regAction = _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == IdRuedaActual && x.Estado == "Vendido").ToList();
            if (regAction != null)
            {
                foreach (RuedasDetalleSimulador actionPrice in regAction)
                {
                    actionPrice.Variacionenpesos = (actionPrice.PrecioVenta - actionPrice.PrecioCompra) * actionPrice.Cantidad;
                    actionPrice.Variacionenporcentajes = ((actionPrice.PrecioVenta / actionPrice.PrecioCompra) - 1) * 100;
                    _context.RuedasDetalleSimulador.AddOrUpdate(actionPrice);
                }
                _context.SaveChanges();
            }
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

        public RuedasDetalleSimulador GetLastPurchase(int IdRueda, int idSimulacion, string simbolo)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == IdRueda && x.IdSimulacion == idSimulacion && x.Estado == "Comprado" && x.Simbolo == simbolo).SingleOrDefault();
        }

        public int GetPurchasedAmount(int IdRueda, int idSimulacion)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdRuedaActual == IdRueda && x.IdSimulacion == idSimulacion && x.Estado == "Comprado").Count();
        }

        public decimal GetDailyVariationMoney(int idRueda, int idSimulacion, string simbolo)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdRuedaVenta == idRueda && x.IdSimulacion == idSimulacion && x.Simbolo == simbolo && x.Estado == "Vendido").Sum(x=> x.Variacionenpesos);
        }
        public decimal GetDailyVariationPercentage(int idRueda, int idSimulacion, string simbolo)
        {
            return _context.RuedasDetalleSimulador.Where(x => x.IdRuedaVenta == idRueda && x.IdSimulacion == idSimulacion && x.Simbolo == simbolo && x.Estado == "Vendido").Sum(x => x.Variacionenporcentajes);
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
