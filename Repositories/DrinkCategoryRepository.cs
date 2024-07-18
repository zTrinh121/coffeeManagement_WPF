using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class DrinkCategoryRepository : IDrinkCategoryRepository
    {
        public async Task DeleteDrinkCategory(DrinkCategory category)
        {
            await DrinkCategoryDAO.Instance.DeleteDrinkCategory(category);
        }

        public async Task<DrinkCategory> GetDrinkCategory(int categoryId)
        {
            return await DrinkCategoryDAO.Instance.GetDrinkCategory(categoryId);
        }

        public async Task<IEnumerable<DrinkCategory>> GetDrinkCategories()
        {
            return await DrinkCategoryDAO.Instance.GetDrinkCategories();
        }

        public async Task InsertDrinkCategory(DrinkCategory category)
        {
            await DrinkCategoryDAO.Instance.InsertDrinkCategory(category);
        }

        public async Task UpdateDrinkCategory(DrinkCategory category)
        {
            await DrinkCategoryDAO.Instance.UpdateDrinkCategory(category);
        }
    }
}
