using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class CSequence
{
    public string Regdate { get; set; } = null!;

    public string TabNm { get; set; } = null!;

    public decimal? SeqNo { get; set; }

    public string? EndTag { get; set; }

    public DateTime? UptTime { get; set; }
}
