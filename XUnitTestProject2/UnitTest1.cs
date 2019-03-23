using Microsoft.AspNetCore.Mvc;
using System;
using WebApplicationUnitTesting.Controllers;
using WebApplicationUnitTesting.Models;
using Xunit;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        HomeController controller;
        
        public UnitTest1()
        {
            controller = new HomeController();
        }



        [Trait("Home", "Index")]
        [Fact(DisplayName = "IndexTestMethod")]
        public void Test1()
        {
            //Act
            IActionResult result = controller.Index();

            //Assert
            Assert.NotNull(result);
        }



        [Trait("Home", "Contact")]
        [Fact(DisplayName = "ContactTestMethod")]
        public void Test2()
        {
            ViewResult result = (ViewResult)controller.Contact();
            string msg = (string)result.ViewData["Message"];
            Assert.Equal("Your contact page.", msg);

        }



        [Fact(DisplayName ="ExceptionTest")]
        public void ProductError()
        {
            Assert.Throws<NullReferenceException>(()=>
            {
                controller.ProductPage(1010);
            });
        }


        [Theory]
        [InlineData(101)]
        [InlineData(102)]
        [InlineData(103)]
        public void TestWithDifferentValues(int id)
        {
            ViewResult result = (ViewResult)controller.GetProduct(id);
            Assert.IsType<Product>(result.Model);
        }
    }
}
