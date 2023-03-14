using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class CLoginipblockLog
{
    public DateTime IptTime { get; set; }

    public string? Note { get; set; }

    public string? IptAdmorId { get; set; }

    public string? IptIpAddr { get; set; }
}
