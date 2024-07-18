using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class BillInfo
{
    public int BillInfoId { get; set; }

    public int IdBill { get; set; }

    public int IdDrink { get; set; }

    public int Count { get; set; }

    public virtual Bill IdBillNavigation { get; set; } = null!;

    public virtual Drink IdDrinkNavigation { get; set; } = null!;
}
