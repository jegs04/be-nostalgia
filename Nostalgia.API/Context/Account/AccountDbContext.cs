using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nostalgia.API.Context.Account;

public partial class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CIpBan> CIpBans { get; set; }

    public virtual DbSet<CIpPermit> CIpPermits { get; set; }

    public virtual DbSet<CIpPwd> CIpPwds { get; set; }

    public virtual DbSet<CLoginipblockLog> CLoginipblockLogs { get; set; }

    public virtual DbSet<CSequence> CSequences { get; set; }

    public virtual DbSet<CpUserProfile> CpUserProfiles { get; set; }

    public virtual DbSet<MbUsrIp> MbUsrIps { get; set; }

    public virtual DbSet<MbUsrPun> MbUsrPuns { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<UserConnlogKey> UserConnlogKeys { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<VwServer> VwServers { get; set; }

    public virtual DbSet<VwUserProfile> VwUserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Chinese_PRC_CI_AS");

        modelBuilder.Entity<CIpBan>(entity =>
        {
            entity.HasKey(e => new { e.StartIp, e.EndIp });

            entity.ToTable("C_IP_BAN");

            entity.Property(e => e.StartIp)
                .HasMaxLength(4)
                .HasColumnName("start_ip");
            entity.Property(e => e.EndIp)
                .HasMaxLength(4)
                .HasColumnName("end_ip");
            entity.Property(e => e.DetailLoc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("detail_loc");
            entity.Property(e => e.IptTime)
                .HasColumnType("datetime")
                .HasColumnName("ipt_time");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<CIpPermit>(entity =>
        {
            entity.HasKey(e => new { e.StartIp, e.EndIp });

            entity.ToTable("C_IP_PERMIT");

            entity.Property(e => e.StartIp)
                .HasMaxLength(4)
                .HasColumnName("start_ip");
            entity.Property(e => e.EndIp)
                .HasMaxLength(4)
                .HasColumnName("end_ip");
            entity.Property(e => e.IpLocate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ip_locate");
            entity.Property(e => e.IptTime)
                .HasColumnType("datetime")
                .HasColumnName("ipt_time");
            entity.Property(e => e.UptTime)
                .HasColumnType("datetime")
                .HasColumnName("upt_time");
        });

        modelBuilder.Entity<CIpPwd>(entity =>
        {
            entity.HasKey(e => new { e.StartIp, e.EndIp });

            entity.ToTable("C_IP_PWD");

            entity.Property(e => e.StartIp)
                .HasMaxLength(4)
                .HasColumnName("start_ip");
            entity.Property(e => e.EndIp)
                .HasMaxLength(4)
                .HasColumnName("end_ip");
            entity.Property(e => e.IpPwd)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ip_pwd");
            entity.Property(e => e.IptTime)
                .HasColumnType("datetime")
                .HasColumnName("ipt_time");
            entity.Property(e => e.Note)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.UptTime)
                .HasColumnType("datetime")
                .HasColumnName("upt_time");
        });

        modelBuilder.Entity<CLoginipblockLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("C_LOGINIPBLOCK_LOG");

            entity.HasIndex(e => e.IptTime, "IX_C_IP_BLOCK_LOG_01")
                .IsDescending()
                .IsClustered();

            entity.Property(e => e.IptAdmorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ipt_admor_id");
            entity.Property(e => e.IptIpAddr)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ipt_ip_addr");
            entity.Property(e => e.IptTime)
                .HasColumnType("datetime")
                .HasColumnName("ipt_time");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("note");
        });

        modelBuilder.Entity<CSequence>(entity =>
        {
            entity.HasKey(e => new { e.Regdate, e.TabNm });

            entity.ToTable("C_SEQUENCE");

            entity.Property(e => e.Regdate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("regdate");
            entity.Property(e => e.TabNm)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("tab_nm");
            entity.Property(e => e.EndTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .IsFixedLength()
                .HasColumnName("end_tag");
            entity.Property(e => e.SeqNo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("seq_no");
            entity.Property(e => e.UptTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("upt_time");
        });

        modelBuilder.Entity<CpUserProfile>(entity =>
        {
            entity.HasKey(e => e.UserNo);

            entity.ToTable("CP_USER_PROFILE");

            entity.HasIndex(e => e.UserId, "IDX_CP_USER_PROFILE_01")
                .IsUnique()
                .HasFillFactor(85);

            entity.Property(e => e.UserNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("user_no");
            entity.Property(e => e.CertifyNo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("certify_no");
            entity.Property(e => e.IptTime)
                .HasColumnType("datetime")
                .HasColumnName("ipt_time");
            entity.Property(e => e.LoginFlag)
                .HasDefaultValueSql("(0)")
                .HasColumnName("login_flag");
            entity.Property(e => e.LoginTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('Y')")
                .IsFixedLength()
                .HasColumnName("login_tag");
            entity.Property(e => e.LoginTime)
                .HasColumnType("datetime")
                .HasColumnName("login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("datetime")
                .HasColumnName("logout_time");
            entity.Property(e => e.ResidentNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("resident_no");
            entity.Property(e => e.ServerId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('000')")
                .HasColumnName("server_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.UserIpAddr)
                .HasMaxLength(4)
                .HasColumnName("user_ip_addr");
            entity.Property(e => e.UserPwd)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("user_pwd");
            entity.Property(e => e.UserType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('1')")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<MbUsrIp>(entity =>
        {
            entity.HasKey(e => new { e.FromIpAddr, e.ToIpAddr, e.GmItemCd, e.UserNo });

            entity.ToTable("MB_USR_IP");

            entity.HasIndex(e => e.UserNo, "IX_MB_USR_IP_01").HasFillFactor(90);

            entity.Property(e => e.FromIpAddr)
                .HasMaxLength(4)
                .HasColumnName("from_ip_addr");
            entity.Property(e => e.ToIpAddr)
                .HasMaxLength(4)
                .HasColumnName("to_ip_addr");
            entity.Property(e => e.GmItemCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gm_item_cd");
            entity.Property(e => e.UserNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("user_no");
            entity.Property(e => e.AgencyNo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("agency_no");
            entity.Property(e => e.UptIpAddr)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("upt_ip_addr");
            entity.Property(e => e.UptTime)
                .HasColumnType("datetime")
                .HasColumnName("upt_time");
        });

        modelBuilder.Entity<MbUsrPun>(entity =>
        {
            entity.HasKey(e => e.UserNo);

            entity.ToTable("MB_USR_PUN");

            entity.Property(e => e.UserNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("user_no");
            entity.Property(e => e.CharacterName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("character_name");
            entity.Property(e => e.LoBlockTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .IsFixedLength()
                .HasColumnName("lo_block_tag");
            entity.Property(e => e.PExpireTime)
                .HasColumnType("datetime")
                .HasColumnName("p_expire_time");
            entity.Property(e => e.PReasonSort)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("p_reason_sort");
            entity.Property(e => e.PStepNo)
                .HasDefaultValueSql("(1)")
                .HasColumnName("p_step_no");
            entity.Property(e => e.PunNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pun_no");
            entity.Property(e => e.UptTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("upt_time");
            entity.Property(e => e.WrBlockTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .IsFixedLength()
                .HasColumnName("wr_block_tag");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserNo);

            entity.ToTable("Tbl_user");

            entity.Property(e => e.UserAnswer)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("user_answer");
            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.UserMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_mail");
            entity.Property(e => e.UserNo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("user_no");
            entity.Property(e => e.UserPwd)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("user_pwd");
            entity.Property(e => e.UserQuestion)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("user_question");
        });

        modelBuilder.Entity<UserConnlogKey>(entity =>
        {
            entity.HasKey(e => e.ConnNo);

            entity.ToTable("USER_CONNLOG_KEY");

            entity.Property(e => e.ConnNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("conn_no");
            entity.Property(e => e.AgencyNo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("agency_no");
            entity.Property(e => e.ConnIp)
                .HasMaxLength(4)
                .HasColumnName("conn_ip");
            entity.Property(e => e.ConnSort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("conn_sort");
            entity.Property(e => e.LoginFlag).HasColumnName("login_flag");
            entity.Property(e => e.LoginTime)
                .HasColumnType("datetime")
                .HasColumnName("login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("datetime")
                .HasColumnName("logout_time");
            entity.Property(e => e.PcbangNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("pcbang_no");
            entity.Property(e => e.UserAge)
                .HasDefaultValueSql("(0)")
                .HasColumnName("user_age");
            entity.Property(e => e.UserNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("user_no");
            entity.Property(e => e.UserSex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("user_sex");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserNo);

            entity.ToTable("USER_PROFILE");

            entity.HasIndex(e => e.UserId, "IDX_USER_ID")
                .IsUnique()
                .HasFillFactor(85);

            entity.Property(e => e.UserNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("user_no");
            entity.Property(e => e.IptTime)
                .HasColumnType("datetime")
                .HasColumnName("ipt_time");
            entity.Property(e => e.LoginFlag)
                .HasDefaultValueSql("(0)")
                .HasColumnName("login_flag");
            entity.Property(e => e.LoginTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('Y')")
                .IsFixedLength()
                .HasColumnName("login_tag");
            entity.Property(e => e.LoginTime)
                .HasColumnType("datetime")
                .HasColumnName("login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("datetime")
                .HasColumnName("logout_time");
            entity.Property(e => e.ResidentNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("resident_no");
            entity.Property(e => e.ServerId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('000')")
                .HasColumnName("server_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.UserIpAddr)
                .HasMaxLength(4)
                .HasColumnName("user_ip_addr");
            entity.Property(e => e.UserPwd)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("user_pwd");
            entity.Property(e => e.UserType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('1')")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<VwServer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_SERVER");

            entity.Property(e => e.FromLoginFlag).HasColumnName("from_login_flag");
            entity.Property(e => e.ServerId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("server_id");
            entity.Property(e => e.ServerNm)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("server_nm");
            entity.Property(e => e.ToLoginFlag).HasColumnName("to_login_flag");
            entity.Property(e => e.UseTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("use_tag");
        });

        modelBuilder.Entity<VwUserProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_USER_PROFILE");

            entity.Property(e => e.CertifyNo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("certify_no");
            entity.Property(e => e.IptTime)
                .HasColumnType("datetime")
                .HasColumnName("ipt_time");
            entity.Property(e => e.LoginFlag).HasColumnName("login_flag");
            entity.Property(e => e.LoginTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("login_tag");
            entity.Property(e => e.LoginTime)
                .HasColumnType("datetime")
                .HasColumnName("login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("datetime")
                .HasColumnName("logout_time");
            entity.Property(e => e.ResidentNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("resident_no");
            entity.Property(e => e.ServerId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("server_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.UserIpAddr)
                .HasMaxLength(4)
                .HasColumnName("user_ip_addr");
            entity.Property(e => e.UserNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("user_no");
            entity.Property(e => e.UserPwd)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("user_pwd");
            entity.Property(e => e.UserType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("user_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
