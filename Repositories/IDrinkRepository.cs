using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDrinkRepository
    {
        Task<Drink> GetDrink(int drinkId);
        Task InsertDrink(Drink drink);
        Task DeleteDrink(Drink drink);
        Task UpdateDrink(Drink drink);
        Task<IEnumerable<Drink>> GetDrinks();
        Task<IEnumerable<Drink>> GetDrinksByCategoryId(int categoryId);
    }
}
