using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class CpUserProfile
{
    public string UserNo { get; set; } = null!;

    public string UserId { get; set; } = null!;

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

    public string? CertifyNo { get; set; }
}
