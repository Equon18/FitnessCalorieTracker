using Xunit;
using FitnessCalorieTracker;
using System;
using System.IO;
using System.Collections.Generic;

// UnitTest.cs
// Responsible: All Team Members
namespace FitnessCalorieTrackerTests
{
    public class UnitTest
    {
        // -----------------------------
        // TEST CASE 1 — Create Profile
        // -----------------------------
        [Fact]
        public void Test_CreateProfile()
        {
            TestHelper.SetConsoleInput("Jisoo\n22\n55\n1800\n");
            var output = TestHelper.CaptureConsoleOutput();

            User user = new User();
            user.CreateProfile();

            string result = output.ToString();

            Assert.Contains("Profile saved.", result);
            Assert.True(user.HasProfile());
            Assert.Equal(1800, user.GetCalorieGoal());
        }

        // -----------------------------
        // TEST CASE 2 — Add Calorie Entry
        // -----------------------------
        [Fact]
        public void Test_AddCalorieEntry()
        {
            TestHelper.SetConsoleInput("Banana\n105\n");
            var output = TestHelper.CaptureConsoleOutput();

            CalorieEntry entry = new CalorieEntry();
            entry.CreateEntry();

            string result = output.ToString();

            Assert.Contains("Calorie entry saved.", result);
            Assert.Equal("Banana", entry.GetFoodName());
            Assert.Equal(105, entry.GetCalories());
        }

        // -----------------------------
        // TEST CASE 3 — View Calorie History
        // -----------------------------
        [Fact]
        public void Test_ViewCalorieHistory()
        {
            // Arrange
            AppManager app = new AppManager();

            CalorieEntry entry = new CalorieEntry();
            TestHelper.SetConsoleInput("Banana\n105\n");
            entry.CreateEntry();

            // AppManager 내부 리스트에 직접 추가
            var calorieListField = typeof(AppManager)
                .GetField("calorieEntries", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(calorieListField);

            var list = calorieListField!.GetValue(app) as List<CalorieEntry>;
            Assert.NotNull(list);

            list!.Add(entry);

            // Act
            var output = TestHelper.CaptureConsoleOutput();

            var method = typeof(AppManager)
                .GetMethod("displayCalorieHistory", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(method);

            method!.Invoke(app, null);

            // Assert
            string result = output.ToString();
            Assert.Contains("Banana", result);
            Assert.Contains("105 calories", result);
        }

        // -----------------------------
        // TEST CASE 4 — Add Workout
        // -----------------------------
        [Fact]
        public void Test_AddWorkout()
        {
            TestHelper.SetConsoleInput("2\n30\n250\n");
            var output = TestHelper.CaptureConsoleOutput();

            Workout workout = new Workout();
            workout.CreateWorkout();

            string result = output.ToString();

            Assert.Contains("Workout saved.", result);
            Assert.Equal("Running", workout.GetWorkoutName());
            Assert.Equal(30, workout.GetMinutes());
            Assert.Equal(250, workout.GetCaloriesBurned());
        }

        // -----------------------------
        // TEST CASE 5 — View Workout History
        // -----------------------------
        [Fact]
        public void Test_ViewWorkoutHistory()
        {
            // Create profile
            User user = new User();
            TestHelper.SetConsoleInput("Jisoo\n22\n55\n1800\n");
            user.CreateProfile();

            // Create workout
            Workout workout = new Workout();
            TestHelper.SetConsoleInput("2\n30\n250\n");
            workout.CreateWorkout();

            var output = TestHelper.CaptureConsoleOutput();
            workout.DisplayWorkout();

            string result = output.ToString();

            Assert.Contains("Running", result);
            Assert.Contains("30 minutes", result);
            Assert.Contains("250 calories burned", result);
        }

        // -----------------------------
        // TEST CASE 6 — Add Reminder
        // -----------------------------
        [Fact]
        public void Test_AddReminder()
        {
            TestHelper.SetConsoleInput("Drink water\n");
            var output = TestHelper.CaptureConsoleOutput();

            Reminder reminder = new Reminder();
            reminder.CreateReminder();

            string result = output.ToString();

            Assert.Contains("Reminder saved.", result);
        }

        // -----------------------------
        // TEST CASE 7 — Mark Reminder Complete
        // -----------------------------
        [Fact]
        public void Test_MarkReminderComplete()
        {
            Reminder reminder = new Reminder();
            TestHelper.SetConsoleInput("Drink water\n");
            reminder.CreateReminder();

            var output = TestHelper.CaptureConsoleOutput();
            reminder.MarkComplete();

            string result = output.ToString();

            Assert.Contains("Reminder marked complete.", result);
        }

        // -----------------------------
        // TEST CASE 8 — Daily Summary
        // -----------------------------
        [Fact]
        public void Test_DailySummary()
        {
            // Create user
            User user = new User();
            TestHelper.SetConsoleInput("Jisoo\n22\n55\n1800\n");
            user.CreateProfile();

            // Add calorie entry
            CalorieEntry entry = new CalorieEntry();
            TestHelper.SetConsoleInput("Banana\n105\n");
            entry.CreateEntry();

            // Add workout
            Workout workout = new Workout();
            TestHelper.SetConsoleInput("2\n30\n250\n");
            workout.CreateWorkout();

            var calories = new List<CalorieEntry>() { entry };
            var workouts = new List<Workout>() { workout };

            var output = TestHelper.CaptureConsoleOutput();

            DailySummary summary = new DailySummary();
            summary.DisplaySummary(calories, workouts, user);

            string result = output.ToString();

            Assert.Contains("Calories Consumed", result);
            Assert.Contains("105", result);
            Assert.Contains("250", result);
            Assert.Contains("Net Calories", result);
            Assert.Contains("Goal Status", result);
        }
    }
}
