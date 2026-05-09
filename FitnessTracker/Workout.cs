namespace FitnessCalorieTracker
{
    // Workout class
    // Responsible: Jupiter Lebrun
    public class Workout
    {
        private string workoutName;
        private int minutes;
        private int caloriesBurned;

        public Workout()
        {
            this.workoutName = "";
            this.minutes = 0;
            this.caloriesBurned = 0;
        }

        public void CreateWorkout()
        {
            Console.Write("Enter workout name: ");
            this.workoutName = Console.ReadLine() ?? "";

            Console.Write("Enter workout duration in minutes: ");
            this.minutes = this.readNumber();

            while (this.minutes < 0)
            {
                Console.Write("Minutes cannot be negative. Enter minutes again: ");
                this.minutes = this.readNumber();
            }

            Console.Write("Enter calories burned: ");
            this.caloriesBurned = this.readNumber();

            while (this.caloriesBurned < 0)
            {
                Console.Write("Calories burned cannot be negative. Enter calories again: ");
                this.caloriesBurned = this.readNumber();
            }

            Console.WriteLine("Workout saved.");
        }

        // -----------------------------
        // NEW: Edit existing workout
        // RESPONSIBLE: Jisoo Yoon
        // -----------------------------
        public void EditWorkout()
        {
            Console.Write("Enter new workout name (leave blank to keep current): ");
            string newName = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(newName))
            {
                this.workoutName = newName;
            }

            Console.Write("Enter new duration in minutes (-1 to keep current): ");
            int newMinutes = this.readNumber();
            if (newMinutes >= 0)
            {
                this.minutes = newMinutes;
            }

            Console.Write("Enter new calories burned (-1 to keep current): ");
            int newCalories = this.readNumber();
            if (newCalories >= 0)
            {
                this.caloriesBurned = newCalories;
            }

            Console.WriteLine("Workout updated.");
        }

        // -----------------------------
        // Display workout
        // -----------------------------
        public void DisplayWorkout()
        {
            Console.WriteLine(this.workoutName + " - " + this.minutes + " minutes - " + this.caloriesBurned + " calories burned");
        }

        // -----------------------------
        // Getters for WorkoutName
        // RESPONSIBLE: Jisoo YOon
        // -----------------------------
        public string GetWorkoutName()
        {
            return this.workoutName;
        }

        // -----------------------------
        // Getters for Minutes
        // RESPONSIBLE: Jisoo Yoon
        // -----------------------------
        public int GetMinutes()
        {
            return this.minutes;
        }

        public int GetCaloriesBurned()
        {
            return this.caloriesBurned;
        }

        // -----------------------------
        // Helper: read number safely
        // -----------------------------
        private int readNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Enter a valid number: ");
            }

            return number;
        }
    }
}
