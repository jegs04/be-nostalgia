using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class MbUsrIp
{
    public string UserNo { get; set; } = null!;

    public string GmItemCd { get; set; } = null!;

    public byte[] FromIpAddr { get; set; } = null!;

    public byte[] ToIpAddr { get; set; } = null!;

    public string? UptIpAddr { get; set; }

    public DateTime? UptTime { get; set; }

    public string? AgencyNo { get; set; }
}
