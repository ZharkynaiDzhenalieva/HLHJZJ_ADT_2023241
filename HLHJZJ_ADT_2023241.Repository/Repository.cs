using System;
namespace HLHJZJ_ADT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected LegoDBContext db;

        public Repository(LegoDBContext db)
        {
            this.db = db;
        }

        public void Create(T obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }


        public abstract T Read(int id);
        public IQueryable<T> ReadAll()
        {
            return db.Set<T>();
        }
        public abstract void Update(T obj);
        public abstract void Delete(int id);
    }
}

