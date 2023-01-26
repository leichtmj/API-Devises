using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;
using Microsoft.AspNetCore.Http;

namespace WSConvertisseur.Controllers.Tests
{
    [TestClass()]
    public class DevisesControllerTests
    {
        public DevisesController devisesController;
        public Devise fakeD;

        [TestInitialize]
        public void InitialisationDesTests()
        {
            // Rajouter les initialisations exécutées avant chaque test
            devisesController = new DevisesController();
            fakeD = new Devise(-1, "Dollar", 1.0);

        }

        [TestMethod()]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {

            //Act
            var result = devisesController.GetById(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise"); // Test du type du contenu (valeur) du retour
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise?)result.Value, "Devises pas identiques"); //Test de la devise récupérée

        }

        [TestMethod()]
        public void GetById_IdPassed_Returns404Error()
        {


            //Act
            var result = devisesController.GetById(500);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Value, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Pas une Devise"); // Test du type du contenu (valeur) du retour
            Assert.AreEqual(((NotFoundResult)result.Result).StatusCode, StatusCodes.Status404NotFound, "Pas 404");
        }

        [TestMethod]
        public void GetAllTest()
        {


            //Act
            var result = devisesController.GetAll();
            var listR = result.ToList();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Devise>), "Type retour OK"); // Test du type du contenu (valeur) du retour
            CollectionAssert.AreEqual(listR, result.ToList());
        }

        [TestMethod]
        public void PostTest()
        {
            Devise d = new Devise(4, "Mora", 1.0);

            //Act
            var result = devisesController.Post(d);

            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Type retour OK"); // Test du type du contenu (valeur) du retour
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult), "Type retour OK"); // Test du type du contenu (valeur) du retour

            CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;
            Assert.AreEqual(routeResult.Value, d);
            Assert.AreEqual(routeResult.StatusCode, StatusCodes.Status201Created);
        }

        /*
        [TestMethod]
        public void PostTestChampRequired()
        {
            //Arrange
            DevisesController devisesController = new DevisesController();
            Devise d = new Devise(4, null, 1.0);

            //Act
            var result = devisesController.Post(d);

            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Type retour OK"); // Test du type du contenu (valeur) du retour
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult), "Type retour OK"); // Test du type du contenu (valeur) du retour

            CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;
            Assert.AreEqual(routeResult.Value, d);
            Assert.AreEqual(routeResult.StatusCode, StatusCodes.Status201Created);
        }*/


        [TestMethod]
        public void PutTestOK()
        {
            Devise d = new Devise(1, "Dollar", 1.0);

            //Act
            var result = devisesController.Put(1, d);
            var result2 = devisesController.Put(545, d);


            Assert.IsInstanceOfType(result, typeof(NoContentResult), "Type retour OK"); 
        }


        [TestMethod]
        public void PutTestErrorNotFound()
        {
            Devise d = new Devise(-1, "Dollar", 1.0);

            //Act
            var result2 = devisesController.Put(-1, d);


            Assert.IsInstanceOfType(result2, typeof(NotFoundResult), "Type retour OK"); // Test du type du contenu (valeur) du retour
        }

        [TestMethod]
        public void PutTestErrorBadRequest()
        {
            Devise d = new Devise(-1, "Dollar", 1.0);

            //Act
            var result2 = devisesController.Put(12, d);


            Assert.IsInstanceOfType(result2, typeof(BadRequestResult), "Type retour OK"); // Test du type du contenu (valeur) du retour
        }

        [TestMethod]
        public void Delete_NotOk_ReturnsNotFound()
        {
            //Act
            var result2 = devisesController.Delete(500);


            Assert.IsInstanceOfType(result2.Result, typeof(NotFoundResult), "Type retour OK"); // Test du type du contenu (valeur) du retour
        }

        [TestMethod]
        public void Delete_Ok_ReturnsRightItem()
        {

            //Act
            var result2 = devisesController.Delete(1);


            Assert.IsInstanceOfType(result2, typeof(ActionResult<Devise>), "Type retour OK"); // Test du type du contenu (valeur) du retour
        }



    }
}