using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class CIpPermit
{
    public byte[] StartIp { get; set; } = null!;

    public byte[] EndIp { get; set; } = null!;

    public string? IpLocate { get; set; }

    public DateTime? IptTime { get; set; }

    public DateTime? UptTime { get; set; }
}
