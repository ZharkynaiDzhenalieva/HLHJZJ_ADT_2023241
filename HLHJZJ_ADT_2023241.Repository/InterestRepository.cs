using HLHJZJ_ADT_2023241.Models;

namespace HLHJZJ_ADT_2023241.Repository
{
    public class InterestRepository : Repository<Interest>
	{
        public InterestRepository(LegoDBContext db) : base(db)
        {
        }

        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public override Interest Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Interest obj)
        {
            var oldProduct = Read(obj.Id);
            oldProduct.Id = obj.Id;
            oldProduct.Name = obj.Name;
            db.SaveChanges();
        }
    }
}

