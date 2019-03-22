using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebApplicationUnitTesting.Controllers;
using WebApplicationUnitTesting.Models;

namespace UnitTestProjectMS
{
    [TestClass]
    public class UnitTest1
    {
        static HomeController controller;
        [ClassInitialize]
        public static void ClassInit (TestContext context)
        {

            //Arrange Globally
            controller = new HomeController();

            context.WriteLine("Home controller Instance Created");
        }

        [TestMethod]
        public void TestForIndexAction()
        {
            //Arrange
            //HomeController controller = new HomeController();


            //Act
            IActionResult result = controller.Index();
            ViewResult view = (ViewResult)result;


            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof(ViewResult));
        }


        [TestMethod]
        [TestCategory("HomeTests")]
        public void TestForContact()
        {

            //Act

            IActionResult results = controller.Contact();
            ViewResult view = (ViewResult)results;
            string teststring = "Your contact page.";
            string data = (string)view.ViewData["Message"];

            //Assert
            Assert.AreEqual(teststring, data);

        }


        [TestMethod]
        [TestCategory("HomeTests")]
        public void TestForAllProducts()
        {
            //Arrange

            //Act
            ViewResult result = (ViewResult)controller.GetProducts();


            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(List<Product>));



        }

        [TestMethod]
        [TestCategory("GetProductTests")]
        public void GetProductIfTest()
        {
            //Arrange

            //Act
            ViewResult result =(ViewResult) controller.GetProduct(101);

            //Assert
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Product));
            Product product = (Product)result.Model;
            Assert.AreEqual(product.title,"Pen");

        }

        [TestMethod]
        [TestCategory("GetProductTests")]

        public void GetProductElseTest()
        {
            //Arrange

            //Act
            
            ViewResult result= (ViewResult)controller.GetProduct(11);

            //Assert

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewName, typeof(string));
            Assert.AreEqual("Index",result.ViewName);

        }

        [TestMethod]
        [TestCategory("GetProductTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void ProductPageTest()
        {
            //Arrange

            //Act
            ViewResult result = controller.ProductPage(11);

        }

        [TestMethod]
        [DataRow(101)]
        [DataRow(102)]
        [DataRow(103)]
        public void IndividualProductTest(int id)
        {
            ViewResult result = (ViewResult)controller.GetProduct(id);
            Assert.IsInstanceOfType(result.Model, typeof(Product));
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {

        }
    }
}
