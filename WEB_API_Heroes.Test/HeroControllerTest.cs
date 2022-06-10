using ASP_MVC_03_Modele.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using WEB_API_Heroes.Controllers;

namespace WEB_API_Heroes.Test
{
    [TestClass]
    public class HeroControllerTest
    { 

        [TestMethod]
        public void Get_Test()
        {
        }

        [TestMethod("Mon test pour les récupérer tous")]
        [Description("Test permettant de vérifier que je récupère tous les héros")]
        public void GetAll_Test()
        {
            //Arrange
            HeroesController ctl = new HeroesController(new Fakes.FakeHeroService());
            //Act
            IActionResult reponse = ctl.Get();

            //Assert
            Assert.IsNotNull(reponse);
            Assert.AreEqual(typeof(OkObjectResult), reponse.GetType());
         
        }


        [TestMethod]
        public void Post_Test()
        {
        }

        [TestMethod]
        public void Put_Test()
        {
        }
    }
}