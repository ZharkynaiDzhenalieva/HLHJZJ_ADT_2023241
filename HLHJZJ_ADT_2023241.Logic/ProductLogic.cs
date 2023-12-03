using System;
using HLHJZJ_ADT_2023241.Models;
using HLHJZJ_ADT_2023241.Repository;

namespace HLHJZJ_ADT_2023241.Logic
{
	public class ProductLogic : IProductLogic
	{
        IRepository<Product> ProductRepo;

        public ProductLogic(IRepository<Product> ProductRepo)
		{
            this.ProductRepo = ProductRepo;
		}

        public void Create(Product obj)
        {
            ProductRepo.Create(obj);
        }

        public void Delete(int id)
        {
            ProductRepo.Delete(id);
        }

        public Product Read(int id)
        {
            return ProductRepo.Read(id);
        }

        public IQueryable<Product> ReadAll()
        {
            return ProductRepo.ReadAll();
        }

        public void Update(Product obj)
        {
            ProductRepo.Update(obj);
        }
    }
}

