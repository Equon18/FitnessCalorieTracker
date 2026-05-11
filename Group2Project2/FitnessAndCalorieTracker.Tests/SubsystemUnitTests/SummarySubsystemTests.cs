Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessAndCalorieTracker.Tests.SubsystemUnitTests
{
    public class SummarySubsystemTests
    {
        // -------------------------------------------------------
        // 1) Summary should return message when no user exists
        // -------------------------------------------------------
        [Fact]
        public void Summary_Should_Return_EmptyViewModel_When_No_User_Exists()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new SummaryController(context);

            var result = controller.Index(DateTime.Today) as ViewResult;

            Assert.NotNull(result);

            var vm = result!.Model as DailySummaryViewModel;
            Assert.NotNull(vm);

            Assert.Equal(0, vm.TotalCaloriesConsumed);
            Assert.Equal(0, vm.TotalCaloriesBurned);
            Assert.Equal(0, vm.DailyGoal);
        }

        // -------------------------------------------------------
        // 2) Summary should calculate calories correctly
        // -------------------------------------------------------
        [Fact]
        public void Summary_Should_Calculate_Calories_Correctly()
        {
            var context = TestHelper.GetInMemoryDbContext();

            // Add user
            var user = new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            };
            context.Users.Add(user);

            // Add calorie entries (FoodName required)
            context.CalorieEntries.AddRange(
                new CalorieEntry { UserId = 1, FoodName = "Chicken", Calories = 500, Date = DateTime.Today },
                new CalorieEntry { UserId = 1, FoodName = "Rice", Calories = 300, Date = DateTime.Today }
            );

            // Add workouts
            context.Workouts.AddRange(
                new Workout { UserId = 1, WorkoutType = "Running", CaloriesBurned = 200, Date = DateTime.Today },
                new Workout { UserId = 1, WorkoutType = "Cycling", CaloriesBurned = 100, Date = DateTime.Today }
            );

            context.SaveChanges();

            var controller = new SummaryController(context);

            var result = controller.Index(DateTime.Today) as ViewResult;

            Assert.NotNull(result);

            var vm = result!.Model as DailySummaryViewModel;
            Assert.NotNull(vm);

            Assert.Equal(800, vm!.TotalCaloriesConsumed);
            Assert.Equal(300, vm.TotalCaloriesBurned);
            Assert.Equal(500, vm.NetCalories);
            Assert.Equal(2000, vm.DailyGoal);
            Assert.Equal("On Track", vm.GoalStatus);
        }


        // -------------------------------------------------------
        // 3) Summary should show Over Goal when net > goal
        // -------------------------------------------------------
        [Fact]
        public void Summary_Should_Show_OverGoal_When_NetCalories_Exceed_Goal()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 1000
            });

            // FIX: FoodName is required
            context.CalorieEntries.Add(new CalorieEntry
            {
                UserId = 1,
                FoodName = "TestFood",
                Calories = 1500,
                Date = DateTime.Today
            });

            context.Workouts.Add(new Workout
            {
                UserId = 1,
                WorkoutType = "Running",
                CaloriesBurned = 100,
                Date = DateTime.Today
            });

            context.SaveChanges();

            var controller = new SummaryController(context);

            var result = controller.Index(DateTime.Today) as ViewResult;
            Assert.NotNull(result);

            var vm = result!.Model as DailySummaryViewModel;
            Assert.NotNull(vm);

            Assert.Equal(1500, vm!.TotalCaloriesConsumed);
            Assert.Equal(100, vm.TotalCaloriesBurned);
            Assert.Equal(1400, vm.NetCalories);
            Assert.Equal("Over Limit", vm.GoalStatus);
        }



        // -------------------------------------------------------
        // 4) Summary should filter by date
        // -------------------------------------------------------
        [Fact]
        public void Summary_Should_Filter_By_Date()
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

            // Today
            context.CalorieEntries.Add(new CalorieEntry
            {
                UserId = 1,
                FoodName = "Chicken", // Required field
                Calories = 500,
                Date = DateTime.Today
            });

            // Yesterday
            context.CalorieEntries.Add(new CalorieEntry
            {
                UserId = 1,
                FoodName = "Rice", // Required field
                Calories = 999,
                Date = DateTime.Today.AddDays(-1)
            });

            context.SaveChanges();

            var controller = new SummaryController(context);

            var result = controller.Index(DateTime.Today) as ViewResult;

            Assert.NotNull(result);

            var vm = result!.Model as DailySummaryViewModel;
            Assert.NotNull(vm);

            Assert.Equal(500, vm!.TotalCaloriesConsumed);
        }
    }
}
