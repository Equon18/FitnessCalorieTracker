Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessAndCalorieTracker.Tests.SubsystemUnitTests
{
    public class WorkoutSubsystemTests
    {
        // -------------------------------------------------------
        // 1) Create should fail when no user exists
        // -------------------------------------------------------
        [Fact]
        public void Create_Should_Fail_When_No_User_Exists()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new WorkoutController(context);

            var workout = new Workout
            {
                WorkoutType = "Running",
                DurationMinutes = 30,
                CaloriesBurned = 200,
                Date = DateTime.Today
            };

            var result = controller.Create(workout) as ViewResult;

            Assert.NotNull(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ErrorCount > 0);
        }

        // -------------------------------------------------------
        // 2) Create should succeed when user exists
        // -------------------------------------------------------
        [Fact]
        public void Create_Should_Succeed_When_User_Exists()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 20,
                Height = 170,
                Weight = 60,
                DailyCalorieGoal = 2000
            });
            context.SaveChanges();

            var controller = new WorkoutController(context);

            var workout = new Workout
            {
                WorkoutType = "Running",
                DurationMinutes = 45,
                CaloriesBurned = 300,
                Date = DateTime.Today
            };

            var result = controller.Create(workout) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

            var saved = context.Workouts.FirstOrDefault();
            Assert.NotNull(saved);
            Assert.Equal(1, saved.UserId);
            Assert.Equal("Running", saved.WorkoutType);
            Assert.Equal(45, saved.DurationMinutes);
            Assert.Equal(300, saved.CaloriesBurned);
        }

        // -------------------------------------------------------
        // 3) Edit should update workout but preserve UserId
        // -------------------------------------------------------
        [Fact]
        public void Edit_Should_Update_Workout_And_Preserve_UserId()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 20,
                Height = 170,
                Weight = 60,
                DailyCalorieGoal = 2000
            });

            context.Workouts.Add(new Workout
            {
                Id = 10,
                UserId = 1,
                WorkoutType = "Running",
                DurationMinutes = 30,
                CaloriesBurned = 200,
                Date = DateTime.Today
            });

            context.SaveChanges();

            // ⭐ FIX: Detach existing entity to prevent tracking conflict
            var tracked = context.Workouts.Local.FirstOrDefault(w => w.Id == 10);
            if (tracked != null)
            {
                context.Entry(tracked).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            var controller = new WorkoutController(context);

            var updated = new Workout
            {
                Id = 10,
                WorkoutType = "Cycling",
                DurationMinutes = 60,
                CaloriesBurned = 500,
                Date = DateTime.Today
            };

            var result = controller.Edit(updated) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

            var saved = context.Workouts.First(w => w.Id == 10);
            Assert.Equal("Cycling", saved.WorkoutType);
            Assert.Equal(60, saved.DurationMinutes);
            Assert.Equal(500, saved.CaloriesBurned);

            // UserId must remain unchanged
            Assert.Equal(1, saved.UserId);
        }


        // -------------------------------------------------------
        // 4) Delete should remove workout
        // -------------------------------------------------------
        [Fact]
        public void Delete_Should_Remove_Workout()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Workouts.Add(new Workout
            {
                Id = 5,
                UserId = 1,
                WorkoutType = "Running",
                DurationMinutes = 20,
                CaloriesBurned = 150,
                Date = DateTime.Today
            });

            context.SaveChanges();

            var controller = new WorkoutController(context);

            var result = controller.DeleteConfirmed(5) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

            Assert.Empty(context.Workouts);
        }

        // -------------------------------------------------------
        // 5) Index should filter by search term
        // -------------------------------------------------------
        [Fact]
        public void Index_Should_Filter_By_SearchTerm()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Workouts.AddRange(
                new Workout { UserId = 1, WorkoutType = "Running", DurationMinutes = 30, CaloriesBurned = 200, Date = DateTime.Today },
                new Workout { UserId = 1, WorkoutType = "Cycling", DurationMinutes = 40, CaloriesBurned = 300, Date = DateTime.Today }
            );
            context.SaveChanges();

            var controller = new WorkoutController(context);

            var result = controller.Index("Run", null) as ViewResult;
            Assert.NotNull(result);

            var list = result.Model as List<Workout>;
            Assert.NotNull(list);
            Assert.Single(list);
            Assert.Equal("Running", list[0].WorkoutType);
        }

        // -------------------------------------------------------
        // 6) Index should filter by date
        // -------------------------------------------------------
        [Fact]
        public void Index_Should_Filter_By_Date()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Workouts.AddRange(
                new Workout { UserId = 1, WorkoutType = "Running", DurationMinutes = 30, CaloriesBurned = 200, Date = DateTime.Today },
                new Workout { UserId = 1, WorkoutType = "Cycling", DurationMinutes = 40, CaloriesBurned = 300, Date = DateTime.Today.AddDays(-1) }
            );
            context.SaveChanges();

            var controller = new WorkoutController(context);

            var result = controller.Index(string.Empty, DateTime.Today) as ViewResult;
            Assert.NotNull(result);

            var list = result.Model as List<Workout>;
            Assert.NotNull(list);
            Assert.Single(list);
            Assert.Equal("Running", list[0].WorkoutType);
        }
    }
}
