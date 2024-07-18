using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class DrinkCategory
{
    public int DrinkCategoryId { get; set; }

    public string DrinkCategoryName { get; set; } = null!;

    public virtual ICollection<Drink> Drinks { get; set; } = new List<Drink>();
}
