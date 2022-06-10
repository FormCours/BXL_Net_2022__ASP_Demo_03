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

        [TestMethod("Mon test pour les r�cup�rer tous")]
        [Description("Test permettant de v�rifier que je r�cup�re tous les h�ros")]
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