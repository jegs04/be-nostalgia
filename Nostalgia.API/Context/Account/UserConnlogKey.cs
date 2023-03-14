using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class UserConnlogKey
{
    public string ConnNo { get; set; } = null!;

    public string UserNo { get; set; } = null!;

    public string? ConnSort { get; set; }

    public int? LoginFlag { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public byte[]? ConnIp { get; set; }

    public string? PcbangNo { get; set; }

    public string? AgencyNo { get; set; }

    public int? UserAge { get; set; }

    public string? UserSex { get; set; }
}
