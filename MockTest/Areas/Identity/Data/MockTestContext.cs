using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MockTest.Areas.Identity.Data;

namespace MockTest.Data
{
    public class MockTestContext : IdentityDbContext<MockTestUser>
    {
        public MockTestContext(DbContextOptions<MockTestContext> options)
            : base(options)
        {
        }

        public DbSet<MockTest.Models.Questions> Questions { get; set; }
        public DbSet<MockTest.Models.Score> Score { get; set; }
    }
}
