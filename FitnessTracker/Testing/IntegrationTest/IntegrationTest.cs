using Xunit;
using FitnessCalorieTracker;
using System;
using System.IO;
using System.Collections.Generic;

// IntegrationTest.cs
// Responsible: All Team Members

namespace FitnessCalorieTrackerTests
{
    public class IntegrationTest
    {
        // ---------------------------------------------------------
        // INTEGRATION TEST 1
        // Full system flow: Profile → CalorieEntry → Workout → Reminder → Summary
        // ---------------------------------------------------------
        [Fact]
        public void Test_FullSystemIntegration()
        {
            // 1) Create Profile
            TestHelper.SetConsoleInput("Jisoo\n22\n55\n1800\n");
            User user = new User();
            user.CreateProfile();
            Assert.True(user.HasProfile());

            // 2) Add Calorie Entry
            TestHelper.SetConsoleInput("Banana\n105\n");
            CalorieEntry entry = new CalorieEntry();
            entry.CreateEntry();

            var calories = new List<CalorieEntry>() { entry };

            Assert.Equal("Banana", entry.GetFoodName());
            Assert.Equal(105, entry.GetCalories());

            // 3) Add Workout
            TestHelper.SetConsoleInput("2\n30\n250\n"); // Running
            Workout workout = new Workout();
            workout.CreateWorkout();

            var workouts = new List<Workout>() { workout };

            Assert.Equal("Running", workout.GetWorkoutName());
            Assert.Equal(30, workout.GetMinutes());
            Assert.Equal(250, workout.GetCaloriesBurned());

            // 4) Add Reminder
            TestHelper.SetConsoleInput("Drink water\n");
            Reminder reminder = new Reminder();
            reminder.CreateReminder();

            // 5) Daily Summary
            var output = TestHelper.CaptureConsoleOutput();

            DailySummary summary = new DailySummary();
            summary.DisplaySummary(calories, workouts, user);

            string result = output.ToString();

            // Assertions
            Assert.Contains("Calories Consumed", result);
            Assert.Contains("105", result);
            Assert.Contains("250", result);
            Assert.Contains("Net Calories", result);
            Assert.Contains("Goal Status", result);
        }

        // ---------------------------------------------------------
        // INTEGRATION TEST 2
        // Summary should work even when no workouts exist
        // ---------------------------------------------------------
        [Fact]
        public void Test_SummaryWithoutWorkout()
        {
            TestHelper.SetConsoleInput("Jisoo\n22\n55\n1800\n");
            User user = new User();
            user.CreateProfile();

            TestHelper.SetConsoleInput("Apple\n80\n");
            CalorieEntry entry = new CalorieEntry();
            entry.CreateEntry();

            var calories = new List<CalorieEntry>() { entry };
            var workouts = new List<Workout>(); // empty

            var output = TestHelper.CaptureConsoleOutput();

            DailySummary summary = new DailySummary();
            summary.DisplaySummary(calories, workouts, user);

            string result = output.ToString();

            Assert.Contains("No workout history found", result);
            Assert.Contains("80", result);
        }

        // ---------------------------------------------------------
        // INTEGRATION TEST 3
        // Workout menu should block adding workouts when no profile exists
        // ---------------------------------------------------------
        [Fact]
        public void Test_WorkoutWithoutProfile()
        {
            AppManager app = new AppManager();

            var output = TestHelper.CaptureConsoleOutput();

            var method = typeof(AppManager)
                .GetMethod("handleWorkoutMenu",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

            Assert.NotNull(method);

            TestHelper.SetConsoleInput("1\n"); // choose "Add Workout"

            method!.Invoke(app, null);

            string result = output.ToString();

            Assert.Contains("Please create a user profile", result);
        }
    }
}
