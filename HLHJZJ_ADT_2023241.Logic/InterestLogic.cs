using System;
using HLHJZJ_ADT_2023241.Models;
using HLHJZJ_ADT_2023241.Repository;

namespace HLHJZJ_ADT_2023241.Logic
{
	public class InterestLogic : IInterestLogic
    { 
    IRepository<Interest> interestRepo;

    public InterestLogic(IRepository<Interest> interestRepo)
    {
        this.interestRepo = interestRepo;
    }

    public void Create(Interest obj)
    {
        interestRepo.Create(obj);
    }

    public void Delete(int id)
    {
            interestRepo.Delete(id);
    }

    public Interest Read(int id)
    {
        return interestRepo.Read(id);
    }

    public IQueryable<Interest> ReadAll()
    {
        return interestRepo.ReadAll();
    }

    public void Update(Interest obj)
    {
            interestRepo.Update(obj);
    }

    }
}

