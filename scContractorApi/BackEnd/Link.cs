using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace scContractorApi.BackEnd
{
    public class ListLinkContext : DbContext
    {       
        public DbSet<Link> Links { get; set; }
        public ListLinkContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=links.db");
        }
    }
    public class Link
    {
        [Key]
        public string Id { get; set; }
        public string Token { get; set; }
        public string RequestLink { get; set; }
        public string TargetLink { get; set; }
        public long CreateDate { get; set; }
        public int RequestCount { get; set; }
    }
}
