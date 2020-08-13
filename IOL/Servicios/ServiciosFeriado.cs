using IOL.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IOL.Servicios
{
    public class ServiciosFeriado
    {
        private BD _context;
        public ServiciosFeriado()
        {
            _context = new BD();
        }
        public bool Register(EntityFrameWork.Feriados feriado)
        {
            try
            {
                _context.Feriados.AddOrUpdate(feriado);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public List<EntityFrameWork.Feriados> GetAll()
        {
            return _context.Feriados.ToList();
        }
        public EntityFrameWork.Feriados GetById(int id)
        {
            return _context.Feriados.Where(x => x.IdFeriado == id).SingleOrDefault();
        }

        public List<EntityFrameWork.Feriados> GetByReason(string motivo)
        {
            return _context.Feriados.Where(x => x.Motivo.Contains(motivo)).OrderBy(x => x.Motivo).ToList();
        }
        public EntityFrameWork.Feriados GetByDate(DateTime fecha)
        {
            return _context.Feriados.Where(x => x.Fecha == fecha).OrderBy(x => x.Fecha).SingleOrDefault();
        }

        public List<EntityFrameWork.Feriados> GetByMonth(DateTime fecha)
        {
            return _context.Feriados.Where(x => x.Fecha.Year == fecha.Year && x.Fecha.Month == fecha.Month).OrderBy(x => x.Fecha).ToList();
        }

        public void Delete(int id)
        {
            var feriado = _context.Feriados.Where(x => x.IdFeriado == id).SingleOrDefault();
            if (feriado != null)
            {
                _context.Feriados.Remove(feriado);
                _context.SaveChanges();
            }
        }
    }
}
