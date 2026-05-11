Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAndCalorieTracker.Tests.FunctionalTests
{
    public class FunctionalTests
    {
        // ✅ 1. Full user-based flow: User → Calorie → Workout → Summary
        [Fact]
        public void Full_User_Flow_Should_Work_Correctly()
        {
            var context = TestHelper.GetInMemoryDbContext();

            // Step 1: Create User
            var userController = new UserController(context);
            var user = new User
            {
                Name = "FunctionalUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            };
            var userResult = userController.Create(user) as RedirectToActionResult;
            Assert.NotNull(userResult);
            Assert.Equal("Index", userResult!.ActionName);

            // Step 2: Add Calorie Entry
            var calorieController = new CalorieController(context);
            var calorieEntry = new CalorieEntry
            {
                UserId = 1,
                FoodName = "Chicken",
                Calories = 500,
                Date = DateTime.Today
            };
            var calorieResult = calorieController.Create(calorieEntry) as RedirectToActionResult;
            Assert.NotNull(calorieResult);
            Assert.Equal("Index", calorieResult!.ActionName);

            // Step 3: Add Workout Entry
            var workoutController = new WorkoutController(context);
            var workout = new Workout
            {
                UserId = 1,
                WorkoutType = "Running",
                DurationMinutes = 30,
                CaloriesBurned = 200,
                Date = DateTime.Today
            };
            var workoutResult = workoutController.Create(workout) as RedirectToActionResult;
            Assert.NotNull(workoutResult);
            Assert.Equal("Index", workoutResult!.ActionName);

            // Step 4: Generate Summary
            var summaryController = new SummaryController(context);
            var summaryResult = summaryController.Index(DateTime.Today) as ViewResult;
            Assert.NotNull(summaryResult);

            var vm = summaryResult!.Model as DailySummaryViewModel;
            Assert.NotNull(vm);

            // Step 5: Validate Summary Values
            Assert.Equal(500, vm!.TotalCaloriesConsumed);
            Assert.Equal(200, vm.TotalCaloriesBurned);
            Assert.Equal(300, vm.NetCalories);
            Assert.Equal(2000, vm.DailyGoal);
            Assert.Equal("On Track", vm.GoalStatus);
        }

        // ✅ 2. Reminder Functionality
        [Fact]
        public void Reminder_Should_Save_And_Display_Correctly()
        {
            var context = TestHelper.GetInMemoryDbContext();
            context.Users.Add(new User { Id = 1, Name = "ReminderUser", Age = 25, Height = 170, Weight = 65, DailyCalorieGoal = 2000 });
            context.SaveChanges();

            var reminderController = new ReminderController(context);
            var reminder = new Reminder
            {
                Title = "Drink Water",
                Description = "500ml after lunch",
                ReminderTime = DateTime.Now.AddHours(1),
                UserId = 1
            };

            var result = reminderController.Create(reminder) as RedirectToActionResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
            Assert.Equal(1, context.Reminders.Count());
        }

        // ✅ 3. Application Flow Validation
        [Fact]
        public void Application_Should_Handle_Multiple_Users_And_Data_Correctly()
        {
            var context = TestHelper.GetInMemoryDbContext();

            // Create multiple users
            context.Users.AddRange(
                new User { Id = 1, Name = "Alice", Age = 28, Height = 165, Weight = 60, DailyCalorieGoal = 1800 },
                new User { Id = 2, Name = "Bob", Age = 30, Height = 175, Weight = 75, DailyCalorieGoal = 2200 }
            );
            context.SaveChanges();

            // Add calorie entries for both users
            context.CalorieEntries.AddRange(
                new CalorieEntry { UserId = 1, FoodName = "Salad", Calories = 300, Date = DateTime.Today },
                new CalorieEntry { UserId = 2, FoodName = "Steak", Calories = 700, Date = DateTime.Today }
            );

            // Add workouts for both users
            context.Workouts.AddRange(
                new Workout { UserId = 1, WorkoutType = "Yoga", DurationMinutes = 45, CaloriesBurned = 150, Date = DateTime.Today },
                new Workout { UserId = 2, WorkoutType = "Cycling", DurationMinutes = 60, CaloriesBurned = 400, Date = DateTime.Today }
            );
            context.SaveChanges();

            // Generate summaries
            var summaryController = new SummaryController(context);
            var aliceSummary = summaryController.Index(DateTime.Today) as ViewResult;
            Assert.NotNull(aliceSummary);

            var vm = aliceSummary!.Model as DailySummaryViewModel;
            Assert.NotNull(vm);
            Assert.Equal(300, vm!.TotalCaloriesConsumed);
            Assert.Equal(150, vm.TotalCaloriesBurned);
        }
    }
}
