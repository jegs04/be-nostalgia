using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class VwServer
{
    public string ServerId { get; set; } = null!;

    public string ServerNm { get; set; } = null!;

    public int FromLoginFlag { get; set; }

    public int ToLoginFlag { get; set; }

    public string UseTag { get; set; } = null!;
}
