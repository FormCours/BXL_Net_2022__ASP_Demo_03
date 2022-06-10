using ASP_MVC_03_Modele.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using WEB_API_Heroes.Controllers;
using WEB_API_Heroes.Models;

namespace WEB_API_Heroes.Test
{
    [TestClass]
    public class HeroControllerTest
    {

        #region Cas par défaut
        [TestMethod]
        public void GetByName_Test()
        {
            //Arrange
            HeroesController ctl = new HeroesController(new Fakes.FakeHeroService());
            HeroDTO local = new HeroDTO() { IdHero = 1, Endurance = 456, IdRace = 1, Name = "MOI", Strength = 665 };
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
            HeroApiModel recu = (data as IEnumerable<HeroApiModel>).FirstOrDefault();
            Assert.IsNotNull(recu);
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
            //Arrange
            HeroesController ctl = new HeroesController(new Fakes.FakeHeroService());
            HeroApiModel toInsert = new HeroApiModel()
            {
                Endurance = 1323,
                IdHero = 2,
                Name = "Zorba",
                Strength = 562
            };
            //Act
            IActionResult result = ctl.AddHero(toInsert);
            //Assert
            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        [TestMethod]
        public void Put_Test()
        {
            //Arrange
            HeroesController ctl = new HeroesController(new Fakes.FakeHeroService());
            HeroApiModel toUpdate = new HeroApiModel()
            {
                Endurance = 1323,
                IdHero = 1,
                Name = "Zorba Le grec",
                Strength = 562
            };
            //Act
            IActionResult result = ctl.ModifyHero(1, toUpdate);
            //Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        #endregion

        #region cas limites
        [TestMethod]
        public void PostFailed_Test()
        {
            //Arrange
            HeroesController ctl = new HeroesController(new Fakes.FakeHeroService());
            HeroApiModel toInsert = new HeroApiModel()
            {
                Endurance = 1323,
                IdHero = 1,
                Name = "Zorba",
                Strength = 562
            };
            //Act
            IActionResult result = ctl.AddHero(toInsert);
            //Assert
        
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        public void PutFailed_Test()
        {
            //Arrange
            HeroesController ctl = new HeroesController(new Fakes.FakeHeroService());
            HeroApiModel toUpdate = new HeroApiModel()
            {
                Endurance = 1323,
                IdHero = 2,
                Name = "Zorba Le grec",
                Strength = 562
            };
            //Act
            IActionResult result = ctl.ModifyHero(2, toUpdate);
            //Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion
    }
}