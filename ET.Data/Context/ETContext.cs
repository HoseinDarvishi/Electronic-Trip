﻿using ET.Data.Mappings;
using ET.Domain.UserAgg;
using System.Data.Entity;

namespace ET.Data.Context
{
   public class ETContext : DbContext
   {
      public ETContext() : base() {}

      public virtual DbSet<User> Users { get; private set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Configurations.AddFromAssembly(typeof(UserMapping).Assembly);
         base.OnModelCreating(modelBuilder);
      }
   }
}