using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class CIpBan
{
    public byte[] StartIp { get; set; } = null!;

    public byte[] EndIp { get; set; } = null!;

    public string? Location { get; set; }

    public string? DetailLoc { get; set; }

    public DateTime? IptTime { get; set; }
}
