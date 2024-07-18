using BusinessObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDrinkCategoryRepository
    {
        Task<DrinkCategory> GetDrinkCategory(int categoryId);
        Task InsertDrinkCategory(DrinkCategory category);
        Task DeleteDrinkCategory(DrinkCategory category);
        Task UpdateDrinkCategory(DrinkCategory category);
        Task<IEnumerable<DrinkCategory>> GetDrinkCategories();
    }
}
