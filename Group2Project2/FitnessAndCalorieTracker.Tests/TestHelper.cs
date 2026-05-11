Contributor: Jisoo Yoon

using FitnessAndCalorieTracker.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitnessAndCalorieTracker.Tests
{
    public static class TestHelper
    {
        public static AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }
    }
}
