using System;
using HLHJZJ_ADT_2023241.Models;

namespace HLHJZJ_ADT_2023241.Repository
{
	public class ProductRepository : Repository<Product>
	{
        public ProductRepository(LegoDBContext db) : base(db)
        {
        }

        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public override Product Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Product obj)
        {
            var oldProduct = Read(obj.Id);
            oldProduct.Id = obj.Id;
            oldProduct.VendorCode = obj.VendorCode;
            oldProduct.Cost = obj.Cost;
            oldProduct.Topic_id = obj.Topic_id;
            db.SaveChanges();
        }
    }
}

