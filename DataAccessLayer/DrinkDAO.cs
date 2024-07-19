using BusinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DrinkDAO : SingletonBase<DrinkDAO>
    {
        private readonly QuanLyQuanCafeContext _context;

        public DrinkDAO()
        {
            _context = new QuanLyQuanCafeContext();
        }

        public async Task<Drink> GetDrink(int drinkId)
        {
            Drink drink;
            try
            {
                drink = await _context.Drinks.Include(x => x.IdCategoryNavigation).SingleOrDefaultAsync(x => x.DrinkId == drinkId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return drink;
        }

        public async Task InsertDrink(Drink drink)
        {
            try
            {
                _context.Drinks.Add(drink);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes.", ex);
            }
        }



        public async Task<IEnumerable<Drink>> GetDrinks()
        {
            List<Drink> drinks;
            try
            {
                drinks = await _context.Drinks.Include(x => x.IdCategoryNavigation).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return drinks;
        }

        public async Task<IEnumerable<Drink>> GetDrinksByCategoryId(int categoryId)
        {
            List<Drink> drinks;
            try
            {
                drinks = await _context.Drinks.Include(x => x.IdCategoryNavigation).Where(x => x.IdCategory == categoryId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return drinks;
        }

        public async Task UpdateDrink(Drink drink)
        {
            try
            {
                _context.Drinks.Update(drink);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDrink(Drink drink)
        {
            try
            {
                _context.Drinks.Remove(drink);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
