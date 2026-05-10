using System.Diagnostics;

namespace FitnessCalorieTracker
{
    // DailySummary class
    // Responsible: Jupiter Lebrun
    public class DailySummary
    {
        public void DisplaySummary(List<CalorieEntry> calorieEntries, List<Workout> workouts, User user)
        {
            int totalCalories = 0;
            int totalBurned = 0;

            foreach (CalorieEntry entry in calorieEntries)
            {
                totalCalories += entry.GetCalories();
            }

            foreach (Workout workout in workouts)
            {
                totalBurned += workout.GetCaloriesBurned();
            }

            int netCalories = totalCalories - totalBurned;


            CssStyleConsoleHelper.printHeader("Daily Summary");
            CssStyleConsoleHelper.printInfoLine("Calories Consumed: ", totalCalories.ToString());
            CssStyleConsoleHelper.printInfoLine("Calories Burned: ", totalBurned.ToString());
            CssStyleConsoleHelper.printInfoLine("Net Calories: ", netCalories.ToString());

            if (workouts.Count == 0)
            {
                CssStyleConsoleHelper.printInfoLine("Work Out History: ", "No workout history found");
            }
            else
            {
                CssStyleConsoleHelper.printInfoLine("Work Out History: ", "");

                for (int index = 0; index < workouts.Count; index++)
                {
                    Workout workout = workouts[index];

                    string workoutInfo = workout.GetWorkoutName()
                                         + " - "
                                         + workout.GetMinutes()
                                         + " minutes - "
                                         + workout.GetCaloriesBurned()
                                         + " calories burned";

                    CssStyleConsoleHelper.printInfoLine((index + 1) + ". ", workoutInfo);
                }
            }

            if (user.HasProfile())
            {
                CssStyleConsoleHelper.printInfoLine("Daily Goal: ", user.GetCalorieGoal().ToString());
                if (netCalories <= user.GetCalorieGoal())
                {
                    CssStyleConsoleHelper.printSuccess("Goal Status: On track");
                }
                else
                {
                    CssStyleConsoleHelper.printError("Goal Status: Over goal");
                }
            }
            else
            {
                CssStyleConsoleHelper.printError("Please create a user profile to view your daily summary.");
            }
        }
    }
}