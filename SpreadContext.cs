using Microsoft.EntityFrameworkCore;
namespace SpreadJsDemoApi
{
    public class SpreadContext : DbContext
    {
        public SpreadContext(DbContextOptions<SpreadContext> options)
           : base(options)
        {
        }
        public DbSet<TableHead> TableHead { get; set; }
        public DbSet<ShuiNiHunLingTu> ShuiNiHunLingTu { get; set; }
        public DbSet<GangJingAnZhuang> GangJingAnZhuang { get; set; }
        public DbSet<PostionTemp> PostionTemp { get; set; }
        public DbSet<Relation> Relation { get; set; }

    }
}
