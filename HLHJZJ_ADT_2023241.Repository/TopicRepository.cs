using HLHJZJ_ADT_2023241.Models;

namespace HLHJZJ_ADT_2023241.Repository
{
    public class TopicRepository : Repository<Topic>
    {
        public TopicRepository(LegoDBContext db) : base(db)
        {
        }

        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public override Topic Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Topic obj)
        {
            var oldTopic = Read(obj.Id);
            oldTopic.Id = obj.Id;
            oldTopic.Name = obj.Name;
            db.SaveChanges();
        }
    }
}

