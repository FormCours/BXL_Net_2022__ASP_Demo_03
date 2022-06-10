using ASP_MVC_03_Modele.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using WEB_API_Heroes.Controllers;
using WEB_API_Heroes.Models;

namespace WEB_API_Heroes.Test
{
    [TestClass]
    public class HeroControllerTest
    { 

        [TestMethod]
        public void GetByName_Test()
        {
            //Arrange
            HeroesController ctl = new HeroesController(new Fakes.FakeHeroService());
           HeroDTO local= new HeroDTO() { IdHero = 1, Endurance = 456, IdRace = 1, Name = "MOI", Strength = 665 };
            //Act
            IActionResult reponse = ctl.GetByName("MOI");

            //Assert
            Assert.IsNotNull(reponse);
            Assert.AreEqual(typeof(OkObjectResult), reponse.GetType());

            //1 - transformer la réponse dans le bon objet
            // 200 ==> okobjectresult
            // 404 ==> NotfoundObjectResult
            OkObjectResult result = (reponse as OkObjectResult);
            //2- Récupérer le contenu de la réponse
            Object? data = result.Value;
            //3- récupérer la valeur dans le bon format
            HeroApiModel recu = (data as IEnumerable<HeroApiModel>).First();
            Assert.AreEqual(recu.Name, local.Name);
            Assert.AreEqual(recu.Endurance, local.Endurance);
            Assert.AreEqual(recu.Strength, local.Strength); 
            Assert.AreEqual(recu.IdHero, local.IdHero);

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