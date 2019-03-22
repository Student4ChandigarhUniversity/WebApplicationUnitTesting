﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationUnitTesting.Models;

namespace WebApplicationUnitTesting.Controllers
{
    public class ProductController : Controller
    {
        IProductStore productStore;
        public ProductController(IProductStore productStore)
        {
            this.productStore = productStore;
        }



    
        public IActionResult Index()
        {
            bool result = productStore.FindProduct(101);

            return View(result);
        }

        public ViewResult ProductPage()
        {
            List<Product> products = productStore.GetAllProducts();
            return View(products);
        }
    }
}