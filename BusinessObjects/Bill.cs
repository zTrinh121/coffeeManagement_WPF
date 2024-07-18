using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Bill
{
    public int BillId { get; set; }

    public DateTime DateCheckIn { get; set; }

    public DateTime? DateCheckOut { get; set; }

    public int IdTable { get; set; }

    public int Status { get; set; }

    public virtual ICollection<BillInfo> BillInfos { get; set; } = new List<BillInfo>();

    public virtual Table IdTableNavigation { get; set; } = null!;
}
