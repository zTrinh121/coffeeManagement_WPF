using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Account
{
    public int AccountId { get; set; }

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public int Type { get; set; }
}
