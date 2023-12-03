using HLHJZJ_ADT_2023241.Models;

namespace HLHJZJ_ADT_2023241.Logic
{
    public interface IProductLogic
    {
        void Create(Product obj);
        Product Read(int id);
        IQueryable<Product> ReadAll();
        void Update(Product obj);
        void Delete(int id);
    }

}