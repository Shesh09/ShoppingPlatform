using Microsoft.AspNetCore.Mvc;
using ShoppingPlatform.Models;
using ShoppingPlatform.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingPlatform.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: Product
        public IEnumerable<ProductModel> Index(int id)
        {
            var productList = productRepository.GetById(id);
            return productList;
        }

        //// GET: Product/Details/5
        //public IActionResult Details([FromBody] ProductModel newProduct)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var addedProduct = productRepository.Add(newProduct);
        //    return ("Get", new { id = addedProduct.ProductId }, addedProduct);
        //}

        // GET: Product/Create
        public IActionResult Create(ProductModel newProduct)
        {
            var model = productRepository.Add(newProduct);
            return (IActionResult)View();
        }

        // POST: Product/Create
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return (IActionResult)RedirectToAction("Index");
            }
            catch
            {
                return (IActionResult)View();
            }
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int id, [FromBody] ProductModel productToUpdate)
        {

            productRepository.Update(productToUpdate);
            return (IActionResult)View();
        }

        // POST: Product/Edit/5
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return (IActionResult)RedirectToAction("Index");
            }
            catch
            {
                return (IActionResult)View();
            }
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int id, ProductModel productToDelete)
        {
            if (!productRepository.Exists(id))
            {
                return (IActionResult)HttpNotFound();
            }

            var isDeleted = productRepository.Delete(productToDelete);
            return (IActionResult)HttpNotFound();
        }

        // POST: Product/Delete/5
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return (IActionResult)RedirectToAction("Index");
            }
            catch
            {
                return (IActionResult)View();
            }
        }
    }
}
