using ShoppingPlatform.Context;
using ShoppingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingPlatform.RepositoryPattern
{
    public interface IProductRepository
    {
        ProductModel Add(ProductModel newProduct);
        bool Delete(ProductModel productToDelete);
        bool Exists(int id);
        IEnumerable<ProductModel> GetAll();
        IEnumerable<ProductModel> GetById(int id);
        void Update(ProductModel productToUpdate);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductModel> GetById(int id)
        {
            return context.Products.Where(x => x.ProductId == id).ToList();
        }
        public ProductModel Add(ProductModel newProduct)
        {
            var addedProduct = context.Products.Add(newProduct);
            context.SaveChanges();
            return addedProduct;
        }
        public void Update(ProductModel productToUpdate)
        {
            context.Products.Attach(productToUpdate);
            context.SaveChanges();
        }
        public bool Delete(ProductModel productToDelete)
        {
            var deletedItem= context.Products.Remove(productToDelete);
            context.SaveChanges();
            return deletedItem != null;
        }
        public IEnumerable<ProductModel> GetAll()
        {

            return context.Products.ToList();
        }
        public bool Exists(int id)
        {
            var exists = context.Products.Count(x => x.ProductId == id);
            return exists == 1;
        }

    }
}