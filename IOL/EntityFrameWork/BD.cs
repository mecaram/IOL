namespace IOL.EntityFrameWork
{
    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class BD : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'BD' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'IOL.EntityFrameWork.BD' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'BD'  en el archivo de configuración de la aplicación.
        public BD()
            : base("name=BD")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<Comitentes> Comitentes { get; set; }
        public virtual DbSet<Feriados> Feriados { get; set; }
        public virtual DbSet<InformeFinal> InformeFinal { get; set; }
        public virtual DbSet<PanelPrincipal> PanelPrincipal { get; set; }
        public virtual DbSet<Ruedas> Ruedas { get; set; }
        public virtual DbSet<RuedasDatosSimulador> RuedasDatosSimulador { get; set; }
        public virtual DbSet<RuedasDetalle> RuedasDetalle { get; set; }
        public virtual DbSet<RuedasDetalleSimulador> RuedasDetalleSimulador { get; set; }
        public virtual DbSet<TenenciaComitentes> TenenciaComitentes { get; set; }
        public virtual DbSet<TenenciaSimuladores> TenenciaSimuladores { get; set; }
    }
    public class Acciones
    {
        public string Simbolo { get; set; }
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public string Mercado { get; set; }
        public string Tipo { get; set; }
        public string Plazo { get; set; }
        public string Moneda { get; set; }
        public virtual InformeFinal informeFinal { get; set; }
        public virtual PanelPrincipal panelPrincipal { get; set; }
        public virtual RuedasDetalle ruedasDetalle { get; set; }
        public virtual RuedasDetalleSimulador ruedasDetalleSimulador { get; set; }
    }
    public class Comitentes
    {
        public int Comitente { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Usuario { get; set; }
        public string CorreoPrincipal { get; set; }
        public string CorreoAlternativo { get; set; }
        public string TelefonoCelular { get; set; }
        public virtual TenenciaComitentes tenenciaComitentes { get; set; }
        public virtual TenenciaSimuladores tenenciaSimuladores { get; set; }
        public virtual Ruedas ruedas { get; set; }
    }
    public class Feriados
    {
        public int IdFeriado { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public virtual Ruedas ruedas { get; set; }
    }
    public class InformeFinal
    {
        public int IdFormeFinal { get; set; }
        public int IdRueda { get; set; }
        public string Simbolo { get; set; }
        public int Simulador { get; set; }
        public decimal VariacionDiaria { get; set; }
        public bool MejorVariacionDiaria { get; set; }
        public bool MejorVariacionSemanal { get; set; }
        public virtual ICollection<Acciones> acciones { get; set; }
        public virtual ICollection<Ruedas> ruedas { get; set; }

    }
    public class PanelPrincipal
    {
        public int IdPanelPrincipal { get; set; }
        public int IdRueda { get; set; }
        public int IdPanel { get; set; }
        public string Simbolo { get; set; }
        public double UltimoPrecio { get; set; }
        public double VariacionPorcentual { get; set; }
        public double Apertura { get; set; }
        public double Maximo { get; set; }
        public double Minimo { get; set; }
        public double UltimoCierre { get; set; }
        public double Volumen { get; set; }
        public double CantidadDeOperaciones { get; set; }
        public string Fecha { get; set; }
        public string TipoOpcion { get; set; }
        public double PrecioEjercicio { get; set; }
        public string FechaVencimiento { get; set; }
        public string Mercado { get; set; }
        public string Moneda { get; set; }
        public double PuntaCompradoraP { get; set; }
        public double PuntaVendedoraP { get; set; }
        public double PuntaCompradoraC { get; set; }
        public double PuntaVendedoraC { get; set; }
        public virtual ICollection<Acciones> acciones { get; set; }
        public virtual ICollection<Ruedas> ruedas { get; set; }
        public virtual RuedasDetalle ruedasDetalle { get; set; }
        public virtual RuedasDetalleSimulador ruedasDetalleSimulador { get; set; }
    }
    public class Ruedas
    {
        public int IdRueda { get; set; }
        public int Comitente { get; set; }
        public DateTime FechaRueda { get; set; }
        public int DiaRueda { get; set; }
        public decimal SaldoARetirar { get; set; }
        public int CantAcciones { get; set; }
        public decimal PorcComisionIOL { get; set; }
        public bool Operar { get; set; }
        public decimal PorcCompra { get; set; }
        public decimal PorcVenta { get; set; }
        public decimal PorcPuntaCompradora { get; set; }
        public decimal PorcPuntaVendedora { get; set; }
        public int ComprarHasta { get; set; }
        public int AccesosIOL { get; set; }
        public string Estado { get; set; }
        public virtual InformeFinal informeFinal { get; set; }
        public virtual PanelPrincipal panelPrincipal { get; set; }
        public virtual ICollection<Comitentes> comitentes { get; set; }
        public virtual RuedasDetalle ruedasDetalle { get; set; }
        public virtual RuedasDetalleSimulador ruedasDetalleSimulador { get; set; }
        public virtual RuedasDatosSimulador ruedasDatosSimulador { get; set; }
        public virtual Feriados feriados { get; set; }
    }
    public class RuedasDatosSimulador
    {
        public int IdRuedaSimulador { get; set; }
        public int IdRueda { get; set; }
        public int IdSimulador { get; set; }
        public decimal InversionTotalSimulador { get; set; }
        public decimal PorcCompra { get; set; }
        public decimal PorcVenta { get; set; }
        public virtual ICollection<Ruedas> ruedas { get; set; }
    }
    public class RuedasDetalle
    {
        public int IdRuedaDetalle { get; set; }
        public int IdRuedaActual { get; set; }
        public int IdRuedaCompra { get; set; }
        public int IdRuedaVenta { get; set; }
        public int IdPanel { get; set; }
        public string Operacion { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string Simbolo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal UltimoPrecio { get; set; }
        public DateTime FechaUltimoPrecio { get; set; }
        public decimal Variacionenpesos { get; set; }
        public decimal Variacionenporcentajes { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<Acciones> acciones { get; set; }
        public virtual ICollection<Ruedas> ruedas { get; set; }
        public virtual ICollection<PanelPrincipal> panelPrincipal { get; set; }
    }
    public class RuedasDetalleSimulador
    {
        public int IdRuedaDetalle { get; set; }
        public int IdRuedaActual { get; set; }
        public int IdRuedaCompra { get; set; }
        public int IdRuedaVenta { get; set; }
        public int IdSimulacion { get; set; }
        public int IdPanel { get; set; }
        public string Simbolo { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal ImporteCompra { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal ImporteVenta { get; set; }
        public decimal PorcComisionIOL { get; set; }
        public decimal ImporteComisionIOL { get; set; }
        public decimal UltimoPrecio { get; set; }
        public DateTime FechaUltimoPrecio { get; set; }
        public decimal Variacionenpesos { get; set; }
        public decimal Variacionenporcentajes { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<Acciones> acciones { get; set; }
        public virtual ICollection<Ruedas> ruedas { get; set; }
        public virtual ICollection<PanelPrincipal> panelPrincipal { get; set; }
    }
    public class TenenciaComitentes
    {
        public int Comitente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal DisponibleParaOperar { get; set; }
        public decimal ActivosValorizados { get; set; }
        public decimal BonificacionPorComisiones { get; set; }
        public decimal TotalTenencia { get; set; }
        public virtual ICollection<Comitentes> comitentes { get; set; }
    }
    public class TenenciaSimuladores
    {
        public int IdSimulador { get; set; }
        public int Comitente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal DisponibleParaOperar { get; set; }
        public decimal ActivosValorizados { get; set; }
        public decimal BonificacionPorComisiones { get; set; }
        public decimal TotalTenencia { get; set; }
        public virtual ICollection<Comitentes> comitentes { get; set; }
    }
}