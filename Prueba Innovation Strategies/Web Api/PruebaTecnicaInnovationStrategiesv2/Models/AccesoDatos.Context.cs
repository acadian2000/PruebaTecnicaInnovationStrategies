//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaTecnicaInnovationStrategiesv2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InnovationStrategiesDGTEntities : DbContext
    {
        public InnovationStrategiesDGTEntities()
            : base("name=InnovationStrategiesDGTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Conductor> Conductors { get; set; }
        public virtual DbSet<Infraccione> Infracciones { get; set; }
        public virtual DbSet<Vehiculo> Vehiculoes { get; set; }
        public virtual DbSet<RegistroInfraccionesVehiculare> RegistroInfraccionesVehiculares { get; set; }
    
        public virtual ObjectResult<procConductorSelectTOP_Result> procConductorSelectTOP(Nullable<int> numeroRegistros)
        {
            var numeroRegistrosParameter = numeroRegistros.HasValue ?
                new ObjectParameter("NumeroRegistros", numeroRegistros) :
                new ObjectParameter("NumeroRegistros", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procConductorSelectTOP_Result>("procConductorSelectTOP", numeroRegistrosParameter);
        }
    
        public virtual ObjectResult<procConductorSelectxDNI_Result> procConductorSelectxDNI(string dNI)
        {
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procConductorSelectxDNI_Result>("procConductorSelectxDNI", dNIParameter);
        }
    
        public virtual int procConductorUpdatePtosDescontados(string dNI, Nullable<int> puntos)
        {
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            var puntosParameter = puntos.HasValue ?
                new ObjectParameter("Puntos", puntos) :
                new ObjectParameter("Puntos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("procConductorUpdatePtosDescontados", dNIParameter, puntosParameter);
        }
    
        public virtual ObjectResult<procInfraccionesSelect_Result> procInfraccionesSelect()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procInfraccionesSelect_Result>("procInfraccionesSelect");
        }
    
        public virtual ObjectResult<procInfraccionesSelectxFiltrado_Result> procInfraccionesSelectxFiltrado(string identificador, string descripcion, Nullable<int> puntosaDesconta)
        {
            var identificadorParameter = identificador != null ?
                new ObjectParameter("Identificador", identificador) :
                new ObjectParameter("Identificador", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var puntosaDescontaParameter = puntosaDesconta.HasValue ?
                new ObjectParameter("PuntosaDesconta", puntosaDesconta) :
                new ObjectParameter("PuntosaDesconta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procInfraccionesSelectxFiltrado_Result>("procInfraccionesSelectxFiltrado", identificadorParameter, descripcionParameter, puntosaDescontaParameter);
        }
    
        public virtual ObjectResult<procTOPInfraccionesHabituales_Result> procTOPInfraccionesHabituales(Nullable<int> tOPInfraccionesHabitualesl)
        {
            var tOPInfraccionesHabitualeslParameter = tOPInfraccionesHabitualesl.HasValue ?
                new ObjectParameter("TOPInfraccionesHabitualesl", tOPInfraccionesHabitualesl) :
                new ObjectParameter("TOPInfraccionesHabitualesl", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procTOPInfraccionesHabituales_Result>("procTOPInfraccionesHabituales", tOPInfraccionesHabitualeslParameter);
        }
    
        public virtual ObjectResult<procVehiculoSelect_Result> procVehiculoSelect()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procVehiculoSelect_Result>("procVehiculoSelect");
        }
    
        public virtual ObjectResult<procVehiculoSelectFiltrado_Result> procVehiculoSelectFiltrado(string matricula, string marca, string modelo, string dNIConductorHabitual)
        {
            var matriculaParameter = matricula != null ?
                new ObjectParameter("Matricula", matricula) :
                new ObjectParameter("Matricula", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var dNIConductorHabitualParameter = dNIConductorHabitual != null ?
                new ObjectParameter("DNIConductorHabitual", dNIConductorHabitual) :
                new ObjectParameter("DNIConductorHabitual", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procVehiculoSelectFiltrado_Result>("procVehiculoSelectFiltrado", matriculaParameter, marcaParameter, modeloParameter, dNIConductorHabitualParameter);
        }
    
        public virtual ObjectResult<string> procVehiculoInsert(string matricula, string marca, string modelo, string dNIConductorHabitual)
        {
            var matriculaParameter = matricula != null ?
                new ObjectParameter("Matricula", matricula) :
                new ObjectParameter("Matricula", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var dNIConductorHabitualParameter = dNIConductorHabitual != null ?
                new ObjectParameter("DNIConductorHabitual", dNIConductorHabitual) :
                new ObjectParameter("DNIConductorHabitual", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procVehiculoInsert", matriculaParameter, marcaParameter, modeloParameter, dNIConductorHabitualParameter);
        }
    
        public virtual ObjectResult<string> procVehiculoUpdate(string matricula, string marca, string modelo, string dNIConductorHabitual)
        {
            var matriculaParameter = matricula != null ?
                new ObjectParameter("Matricula", matricula) :
                new ObjectParameter("Matricula", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var dNIConductorHabitualParameter = dNIConductorHabitual != null ?
                new ObjectParameter("DNIConductorHabitual", dNIConductorHabitual) :
                new ObjectParameter("DNIConductorHabitual", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procVehiculoUpdate", matriculaParameter, marcaParameter, modeloParameter, dNIConductorHabitualParameter);
        }
    
        public virtual ObjectResult<string> procInfraccionesInsert(string identificador, string descripcion, Nullable<int> puntosaDesconta)
        {
            var identificadorParameter = identificador != null ?
                new ObjectParameter("Identificador", identificador) :
                new ObjectParameter("Identificador", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var puntosaDescontaParameter = puntosaDesconta.HasValue ?
                new ObjectParameter("PuntosaDesconta", puntosaDesconta) :
                new ObjectParameter("PuntosaDesconta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procInfraccionesInsert", identificadorParameter, descripcionParameter, puntosaDescontaParameter);
        }
    
        public virtual ObjectResult<string> procInfraccionesUpdate(string identificador, string descripcion, Nullable<int> puntosaDesconta)
        {
            var identificadorParameter = identificador != null ?
                new ObjectParameter("Identificador", identificador) :
                new ObjectParameter("Identificador", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var puntosaDescontaParameter = puntosaDesconta.HasValue ?
                new ObjectParameter("PuntosaDesconta", puntosaDesconta) :
                new ObjectParameter("PuntosaDesconta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procInfraccionesUpdate", identificadorParameter, descripcionParameter, puntosaDescontaParameter);
        }
    
        public virtual ObjectResult<string> procInfraccionesVehicularesInsert(string hora, string fecha, string conductor, string vehiculo, string identificadorInfraccion, Nullable<int> puntosConductorAntesInfraccion, Nullable<int> puntosaDescontar, Nullable<int> puntosConductorDespuesInfraccion)
        {
            var horaParameter = hora != null ?
                new ObjectParameter("Hora", hora) :
                new ObjectParameter("Hora", typeof(string));
    
            var fechaParameter = fecha != null ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(string));
    
            var conductorParameter = conductor != null ?
                new ObjectParameter("Conductor", conductor) :
                new ObjectParameter("Conductor", typeof(string));
    
            var vehiculoParameter = vehiculo != null ?
                new ObjectParameter("Vehiculo", vehiculo) :
                new ObjectParameter("Vehiculo", typeof(string));
    
            var identificadorInfraccionParameter = identificadorInfraccion != null ?
                new ObjectParameter("IdentificadorInfraccion", identificadorInfraccion) :
                new ObjectParameter("IdentificadorInfraccion", typeof(string));
    
            var puntosConductorAntesInfraccionParameter = puntosConductorAntesInfraccion.HasValue ?
                new ObjectParameter("PuntosConductorAntesInfraccion", puntosConductorAntesInfraccion) :
                new ObjectParameter("PuntosConductorAntesInfraccion", typeof(int));
    
            var puntosaDescontarParameter = puntosaDescontar.HasValue ?
                new ObjectParameter("PuntosaDescontar", puntosaDescontar) :
                new ObjectParameter("PuntosaDescontar", typeof(int));
    
            var puntosConductorDespuesInfraccionParameter = puntosConductorDespuesInfraccion.HasValue ?
                new ObjectParameter("PuntosConductorDespuesInfraccion", puntosConductorDespuesInfraccion) :
                new ObjectParameter("PuntosConductorDespuesInfraccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procInfraccionesVehicularesInsert", horaParameter, fechaParameter, conductorParameter, vehiculoParameter, identificadorInfraccionParameter, puntosConductorAntesInfraccionParameter, puntosaDescontarParameter, puntosConductorDespuesInfraccionParameter);
        }
    
        public virtual ObjectResult<string> procInfraccionesVehicularesUpdate(string hora, string fecha, string conductor, string vehiculo, string identificadorInfraccion, Nullable<int> puntosConductorAntesInfraccion, Nullable<int> puntosaDescontar, Nullable<int> puntosConductorDespuesInfraccion)
        {
            var horaParameter = hora != null ?
                new ObjectParameter("Hora", hora) :
                new ObjectParameter("Hora", typeof(string));
    
            var fechaParameter = fecha != null ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(string));
    
            var conductorParameter = conductor != null ?
                new ObjectParameter("Conductor", conductor) :
                new ObjectParameter("Conductor", typeof(string));
    
            var vehiculoParameter = vehiculo != null ?
                new ObjectParameter("Vehiculo", vehiculo) :
                new ObjectParameter("Vehiculo", typeof(string));
    
            var identificadorInfraccionParameter = identificadorInfraccion != null ?
                new ObjectParameter("IdentificadorInfraccion", identificadorInfraccion) :
                new ObjectParameter("IdentificadorInfraccion", typeof(string));
    
            var puntosConductorAntesInfraccionParameter = puntosConductorAntesInfraccion.HasValue ?
                new ObjectParameter("PuntosConductorAntesInfraccion", puntosConductorAntesInfraccion) :
                new ObjectParameter("PuntosConductorAntesInfraccion", typeof(int));
    
            var puntosaDescontarParameter = puntosaDescontar.HasValue ?
                new ObjectParameter("PuntosaDescontar", puntosaDescontar) :
                new ObjectParameter("PuntosaDescontar", typeof(int));
    
            var puntosConductorDespuesInfraccionParameter = puntosConductorDespuesInfraccion.HasValue ?
                new ObjectParameter("PuntosConductorDespuesInfraccion", puntosConductorDespuesInfraccion) :
                new ObjectParameter("PuntosConductorDespuesInfraccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procInfraccionesVehicularesUpdate", horaParameter, fechaParameter, conductorParameter, vehiculoParameter, identificadorInfraccionParameter, puntosConductorAntesInfraccionParameter, puntosaDescontarParameter, puntosConductorDespuesInfraccionParameter);
        }
    
        public virtual ObjectResult<procHistorialInfraccionesConductor_Result1> procHistorialInfraccionesConductor(string dNIConductorHabitual, string nombre, string apellido)
        {
            var dNIConductorHabitualParameter = dNIConductorHabitual != null ?
                new ObjectParameter("DNIConductorHabitual", dNIConductorHabitual) :
                new ObjectParameter("DNIConductorHabitual", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procHistorialInfraccionesConductor_Result1>("procHistorialInfraccionesConductor", dNIConductorHabitualParameter, nombreParameter, apellidoParameter);
        }
    
        public virtual ObjectResult<string> procConductorInsert(string dNI, string nombre, string apellido, Nullable<int> puntos)
        {
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var puntosParameter = puntos.HasValue ?
                new ObjectParameter("Puntos", puntos) :
                new ObjectParameter("Puntos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procConductorInsert", dNIParameter, nombreParameter, apellidoParameter, puntosParameter);
        }
    
        public virtual ObjectResult<string> procConductorUpdate(string dNI, string nombre, string apellido, Nullable<int> puntos)
        {
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var puntosParameter = puntos.HasValue ?
                new ObjectParameter("Puntos", puntos) :
                new ObjectParameter("Puntos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("procConductorUpdate", dNIParameter, nombreParameter, apellidoParameter, puntosParameter);
        }
    }
}
