using System;
using System.Collections.Generic;

namespace Nostalgia.API.Context.Account;

public partial class MbUsrPun
{
    public string UserNo { get; set; } = null!;

    public string? CharacterName { get; set; }

    public string PunNo { get; set; } = null!;

    public short PStepNo { get; set; }

    public string PReasonSort { get; set; } = null!;

    public DateTime? PExpireTime { get; set; }

    public string LoBlockTag { get; set; } = null!;

    public string WrBlockTag { get; set; } = null!;

    public DateTime? UptTime { get; set; }
}
