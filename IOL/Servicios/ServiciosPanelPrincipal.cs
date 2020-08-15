using IOL.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosPanelPrincipal
    {
        private BD _context;
        public ServiciosPanelPrincipal()
        {
            _context = new BD();
        }

        public bool Register(EntityFrameWork.PanelPrincipal panel)
        {
            try
            {
                _context.PanelPrincipal.AddOrUpdate(panel);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public int GetNextId(int idRueda)
        {
            return _context.PanelPrincipal.Where(x=> x.IdRueda == idRueda).Max(x=>x.IdPanelPrincipal) + 1;
        }
        public List<double> GetLastThreeBuyingTip(int IdRueda, string simbolo)
        {
            return _context.PanelPrincipal.Where(x => x.IdRueda == IdRueda && x.Simbolo == simbolo).Distinct().OrderByDescending(x=> x.IdPanel).Select(x => x.PuntaCompradoraP).Take(3).ToList();
        }
        public List<double> GetLastThreeSeelingTip(int IdRueda, string simbolo)
        {
            return _context.PanelPrincipal.Where(x => x.IdRueda == IdRueda && x.Simbolo == simbolo).Distinct().OrderByDescending(x => x.IdPanel).Select(x => x.PuntaVendedoraP).Take(3).ToList();
        }
    }
}
