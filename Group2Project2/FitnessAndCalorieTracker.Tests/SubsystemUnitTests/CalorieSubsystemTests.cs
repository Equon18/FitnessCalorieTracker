Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessAndCalorieTracker.Tests.SubsystemUnitTests
{
    public class CalorieSubsystemTests
    {
        // -------------------------------------------------------
        // 1) Create CalorieEntry (Success)
        // -------------------------------------------------------
        [Fact]
        public void Create_CalorieEntry_Should_Save_To_Database()
        {
            var context = TestHelper.GetInMemoryDbContext();

            // User must exist (controller requires it)
            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });
            context.SaveChanges();

            var controller = new CalorieController(context);

            var entry = new CalorieEntry
            {
                FoodName = "Chicken",
                Calories = 500,
                Date = DateTime.Today
            };

            var result = controller.Create(entry) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
            Assert.Equal(1, context.CalorieEntries.Count());
        }

        // -------------------------------------------------------
        // 2) Create CalorieEntry (Fail — No User Exists)
        // -------------------------------------------------------
        [Fact]
        public void Create_CalorieEntry_Should_Fail_When_No_User_Exists()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new CalorieController(context);

            var entry = new CalorieEntry
            {
                FoodName = "Chicken",
                Calories = 500,
                Date = DateTime.Today
            };

            var result = controller.Create(entry) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(0, context.CalorieEntries.Count());
            Assert.True(controller.ModelState.ErrorCount > 0);
        }

        [Fact]
        public void Edit_CalorieEntry_Should_Update_Data()
        {
            var context = TestHelper.GetInMemoryDbContext();

            // Add user
            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });

            // Add entry
            var entry = new CalorieEntry
            {
                Id = 1,
                UserId = 1,
                FoodName = "Chicken",
                Calories = 500,
                Date = DateTime.Today
            };
            context.CalorieEntries.Add(entry);
            context.SaveChanges();

            // Detach existing entity to avoid duplicate tracking
            context.Entry(entry).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            var controller = new CalorieController(context);

            // Updated entry
            var updatedEntry = new CalorieEntry
            {
                Id = 1,
                FoodName = "Beef",
                Calories = 700,
                Date = DateTime.Today
            };

            var result = controller.Edit(updatedEntry) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);

            var saved = context.CalorieEntries.Find(1);
            Assert.NotNull(saved);
            Assert.Equal("Beef", saved!.FoodName);
            Assert.Equal(700, saved.Calories);
        }


        // -------------------------------------------------------
        // 4) Delete CalorieEntry
        // -------------------------------------------------------
        [Fact]
        public void Delete_CalorieEntry_Should_Remove_From_Database()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });

            context.CalorieEntries.Add(new CalorieEntry
            {
                Id = 1,
                UserId = 1,
                FoodName = "Pizza",
                Calories = 800,
                Date = DateTime.Today
            });
            context.SaveChanges();

            var controller = new CalorieController(context);

            var result = controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
            Assert.Equal(0, context.CalorieEntries.Count());
        }

        // -------------------------------------------------------
        // 5) Index Search (FoodName)
        // -------------------------------------------------------
        [Fact]
        public void Index_Should_Filter_By_FoodName()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.CalorieEntries.AddRange(
                new CalorieEntry { Id = 1, UserId = 1, FoodName = "Chicken", Calories = 300, Date = DateTime.Today },
                new CalorieEntry { Id = 2, UserId = 1, FoodName = "Beef", Calories = 500, Date = DateTime.Today }
            );
            context.SaveChanges();

            var controller = new CalorieController(context);

            var result = controller.Index("Chicken", null) as ViewResult;
            Assert.NotNull(result);

            var list = result!.Model as System.Collections.Generic.List<CalorieEntry>;
            Assert.Single(list!);
            Assert.Equal("Chicken", list![0].FoodName);
        }

        // -------------------------------------------------------
        // 6) Index Search (Date)
        // -------------------------------------------------------
        [Fact]
        public void Index_Should_Filter_By_Date()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.CalorieEntries.AddRange(
                new CalorieEntry { Id = 1, UserId = 1, FoodName = "Chicken", Calories = 300, Date = DateTime.Today },
                new CalorieEntry { Id = 2, UserId = 1, FoodName = "Beef", Calories = 500, Date = DateTime.Today.AddDays(-1) }
            );
            context.SaveChanges();

            var controller = new CalorieController(context);

            var result = controller.Index(string.Empty, DateTime.Today) as ViewResult;
            Assert.NotNull(result);

            var list = result!.Model as System.Collections.Generic.List<CalorieEntry>;
            Assert.Single(list!);
            Assert.Equal("Chicken", list![0].FoodName);
        }
    }
}
