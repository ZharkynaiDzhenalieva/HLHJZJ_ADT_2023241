using System;
using HLHJZJ_ADT_2023241.Models;

namespace HLHJZJ_ADT_2023241.Logic
{
	public interface ITopicLogic
	{
        void Create(Topic obj);
        Topic Read(int id);
        IQueryable<Topic> ReadAll();
        void Update(Topic obj);
        void Delete(int id);
    }
}

