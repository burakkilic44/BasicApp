﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicApp.Business.Abstract;
using BasicApp.Entitites;
using BasicApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details(int? id)
        {
            if(id == null) { return NotFound(); }

            Product product = _productService.GetById((int)id);

            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult List()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}