using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Drink
{
    public int DrinkId { get; set; }

    public string DrinkName { get; set; } = null!;

    public int IdCategory { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public string ImageUri
    {
        get { return Image; }
    }

    public virtual ICollection<BillInfo> BillInfos { get; set; } = new List<BillInfo>();

    public virtual DrinkCategory IdCategoryNavigation { get; set; } = null!;
}
