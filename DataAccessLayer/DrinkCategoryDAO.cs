using BusinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DrinkCategoryDAO : SingletonBase<DrinkCategoryDAO>
    {
        public async Task<DrinkCategory> GetDrinkCategory(int categoryId)
        {
            DrinkCategory category;
            try
            {
                category = await _context.DrinkCategories.SingleOrDefaultAsync(x => x.DrinkCategoryId == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public async Task InsertDrinkCategory(DrinkCategory category)
        {
            try
            {
                _context.DrinkCategories.Add(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DrinkCategory>> GetDrinkCategories()
        {
            List<DrinkCategory> categories;
            try
            {
                categories = await _context.DrinkCategories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        public async Task UpdateDrinkCategory(DrinkCategory category)
        {
            try
            {
                _context.DrinkCategories.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDrinkCategory(DrinkCategory category)
        {
            try
            {
                _context.DrinkCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
