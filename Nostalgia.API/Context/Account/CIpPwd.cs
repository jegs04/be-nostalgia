using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class CIpPwd
{
    public byte[] StartIp { get; set; } = null!;

    public byte[] EndIp { get; set; } = null!;

    public string IpPwd { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? IptTime { get; set; }

    public DateTime? UptTime { get; set; }
}
