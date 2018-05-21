﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using filmdesigners.at.Models;

namespace filmdesigners.at.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<filmdesigners.at.Models.Member> Member { get; set; }

        public DbSet<filmdesigners.at.Models.Project> Project { get; set; }

        public DbSet<filmdesigners.at.Models.Enrollment> Enrollment { get; set; }

        public DbSet<filmdesigners.at.Models.Job> Job { get; set; }

        public DbSet<filmdesigners.at.Models.Award> Award { get; set; }

        public DbSet<filmdesigners.at.Models.Chapter> Chapter { get; set; }

        public DbSet<filmdesigners.at.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<filmdesigners.at.Models.Event> Event { get; set; }

        public DbSet<filmdesigners.at.Models.OldUrl> OldUrl { get; set; }

        public DbSet<filmdesigners.at.Models.DSGVOAnswer> DSGVOAnswer { get; set; }
    }
}
