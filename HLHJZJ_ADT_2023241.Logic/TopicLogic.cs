using System;
using HLHJZJ_ADT_2023241.Models;
using HLHJZJ_ADT_2023241.Repository;

namespace HLHJZJ_ADT_2023241.Logic
{
	public class TopicLogic : ITopicLogic
	{
        IRepository<Topic> topicRepo;

        public TopicLogic(IRepository<Topic> topicRepo)
		{
            this.topicRepo = topicRepo;
		}

        public void Create(Topic obj)
        {
            topicRepo.Create(obj);
        }

        public void Delete(int id)
        {
            topicRepo.Delete(id);
        }

        public Topic Read(int id)
        {
            return topicRepo.Read(id);
        }

        public IQueryable<Topic> ReadAll()
        {
            return topicRepo.ReadAll();
        }

        public void Update(Topic obj)
        {
            topicRepo.Update(obj);
        }
    }
}

