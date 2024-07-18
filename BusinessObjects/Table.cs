using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Table
{
    public int TableId { get; set; }

    public string TableName { get; set; } = null!;

    public string TableStatus { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
