using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class UserProfile
{
    public string UserNo { get; set; }

    public string UserId { get; set; }

    public string? UserPwd { get; set; }

    public string? ResidentNo { get; set; }

    public string? UserType { get; set; }

    public int? LoginFlag { get; set; }

    public string? LoginTag { get; set; }

    public DateTime? IptTime { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public byte[]? UserIpAddr { get; set; }

    public string? ServerId { get; set; }
}
