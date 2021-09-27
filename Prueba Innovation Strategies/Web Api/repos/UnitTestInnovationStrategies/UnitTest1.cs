using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaTecnicaInnovationStrategiesv2.Controllers;
using PruebaTecnicaInnovationStrategiesv2.Models.Interfaces;

namespace UnitTestInnovationStrategies
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AddConductor_OK()
        {
            PruebaTecnicaInnovationStrategiesv2.Models.Request.ConductorRequest model = new PruebaTecnicaInnovationStrategiesv2.Models.Request.ConductorRequest
            {
                DNI = "24200300",
                Nombre = "Alfonso",
                Apellido = "Carvajal",
                Puntos = 1500
            };

            var conductoresVehiculos = new Mock<IConductors>();
            var controller = new ConductorsController(conductoresVehiculos);
           // controller.AddConductor(model);
          
            //Tanto en la Linea 25 como en la 31
            //El Tipo de ApiController esta definido en un ensamblado al que no
            //se hace referencia  System.Web.Http

            //conductoresVehiculos.Setup(a=> a.AddConductor(model));
            //procConductorInsert(model.DNI, model.Nombre, model.Apellido, model.Puntos);
        }
    }
}
