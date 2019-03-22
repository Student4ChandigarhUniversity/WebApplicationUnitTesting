using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationUnitTesting.Controllers;
using WebApplicationUnitTesting.Models;

namespace UnitTestProjectMS
{
    [TestClass]
     public class ProductTests
    {
        [TestMethod]
        public void IndexTestMethod()
        {
            //Arange
            Mock<IProductStore> productstoremock = new Mock<IProductStore>();
            IProductStore mockedclassobj = productstoremock.Object;
            productstoremock.Setup(c => c.FindProduct(It.IsAny<int>())).Returns(true);

            ProductController controller = new ProductController(mockedclassobj);
            ViewResult result = (ViewResult)controller.Index();
            Assert.IsTrue((bool)result.Model);
        }

        
    }
}
