using System.Collections.Generic;
using IOL.EntityFrameWork;
using IOL.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestIOL
{
    [TestClass]
    public class DatosSimulador
    {
        [TestMethod]
        public void TestDatosSimulador()
        {
            List<IOL.EntityFrameWork.RuedasDatosSimulador> lstDatosSimulador = new List<RuedasDatosSimulador>();
            RuedasDatosSimulador datosSimulador = new RuedasDatosSimulador();

            int idSimulador = 1;
            datosSimulador.IdRueda = 0;
            datosSimulador.IdRuedaSimulador = 0;
            datosSimulador.IdSimulador = idSimulador;
            datosSimulador.InversionTotalSimulador = 100000m;
            datosSimulador.PorcCompra = 0.58m;
            datosSimulador.PorcVenta = 1.0m;
            lstDatosSimulador.Add(datosSimulador);
            Assert.IsNotNull(datosSimulador);
            Assert.IsNotNull(lstDatosSimulador);
        }
    }
}
