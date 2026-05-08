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

        public void DisplayWorkout()
        {
            Console.WriteLine(this.workoutName + " - " + this.minutes + " minutes - " + this.caloriesBurned + " calories burned");
        }

        public int GetCaloriesBurned()
        {
            return this.caloriesBurned;
        }

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