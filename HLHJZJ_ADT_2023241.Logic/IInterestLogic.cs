using System;
using HLHJZJ_ADT_2023241.Models;

namespace HLHJZJ_ADT_2023241.Logic
{
	public interface IInterestLogic
	{
        void Create(Interest obj);
        Interest Read(int id);
        IQueryable<Interest> ReadAll();
        void Update(Interest obj);
        void Delete(int id);
    }
}

