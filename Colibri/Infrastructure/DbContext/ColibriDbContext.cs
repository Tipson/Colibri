using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Portfolios;
using Colibri.Models.Reviews;
using Colibri.Models.Statistics;
using Colibri.Models.TeamMembers;
using Microsoft.EntityFrameworkCore;


namespace Colibri.Infrastructure.DbContext;

public  class ColibriDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ColibriDbContext(DbContextOptions<ColibriDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<ErrorRow> Errors { get; set; } = null!;
    public virtual DbSet<ProductRow> Products { get; set; }
    public virtual DbSet<PortfolioRow> Portfolios { get; set; }
    public virtual DbSet<PartnerRow> Partners { get; set; } = null!;
    public virtual DbSet<StatisticRow> Statistics { get; set; }
    public virtual DbSet<ReviewRow> Reviews { get; set; }
    public virtual DbSet<TeamMemberRow> TeamMembers { get; set; }
}