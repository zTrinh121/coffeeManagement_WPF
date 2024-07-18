using BusinessObjects;
using DataAccessLayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        public async Task DeleteDrink(Drink drink)
        {
            await DrinkDAO.Instance.DeleteDrink(drink);
        }

        public async Task<Drink> GetDrink(int drinkId)
        {
            return await DrinkDAO.Instance.GetDrink(drinkId);
        }

        public async Task<IEnumerable<Drink>> GetDrinks()
        {
            return await DrinkDAO.Instance.GetDrinks();
        }

        public async Task<IEnumerable<Drink>> GetDrinksByCategoryId(int categoryId)
        {
            return await DrinkDAO.Instance.GetDrinksByCategoryId(categoryId);
        }

        public async Task InsertDrink(Drink drink)
        {
            await DrinkDAO.Instance.InsertDrink(drink);
        }

        public async Task UpdateDrink(Drink drink)
        {
            await DrinkDAO.Instance.UpdateDrink(drink);
        }
    }
}
