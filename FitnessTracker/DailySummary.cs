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

            Console.WriteLine();
            Console.WriteLine("Daily Summary");
            Console.WriteLine("Calories Consumed: " + totalCalories);
            Console.WriteLine("Calories Burned: " + totalBurned);
            Console.WriteLine("Net Calories: " + netCalories);

            if (user.HasProfile())
            {
                Console.WriteLine("Daily Goal: " + user.GetCalorieGoal());

                if (netCalories <= user.GetCalorieGoal())
                {
                    Console.WriteLine("Goal Status: On track");
                }
                else
                {
                    Console.WriteLine("Goal Status: Over goal");
                }
            }
            else
            {
                Console.WriteLine("Goal Status: Create a profile to compare with your goal.");
            }
        }
    }
}