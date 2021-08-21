using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeEventsDomain.Classes;

namespace CodeEventsDomain.DataModel
{
    public class CodingEventContext:DbContext
    {
        public DbSet<myApp> APP_DS { set; get; }
        public DbSet<APP_Layers> APPLayer_DS { set; get; }
        public DbSet<CodingEvent> Events_DS { set; get; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CodeEventsDomain.Classes.APP_Layers>()
        //        .HasOptional(l => l.ParentLayer)
        //        .WithMany()
        //        .HasForeignKey(p => new { p.Parent_Layer_ID, p.AppID });
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
