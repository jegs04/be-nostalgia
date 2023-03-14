using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nostalgia.API.Context.Account;


public partial class TblUser
{
    public string UserNo { get; set; }

    public string? UserId { get; set; }

    public string? UserPwd { get; set; }

    public string? UserMail { get; set; }

    public string? UserAnswer { get; set; }

    public string? UserQuestion { get; set; }

}
