namespace FitnessCalorieTracker
{
    // CalorieEntry class
    // Responsible: Quentin Robinson
    public class CalorieEntry
    {
        private string foodName;
        private int calories;

        public CalorieEntry()
        {
            this.foodName = "";
            this.calories = 0;
        }

        public void CreateEntry()
        {
            Console.Write("Enter food name: ");
            this.foodName = Console.ReadLine() ?? "";

            Console.Write("Enter calories: ");
            this.calories = this.readNumber();

            while (this.calories < 0)
            {
                Console.Write("Calories cannot be negative. Enter calories again: ");
                this.calories = this.readNumber();
            }

            Console.WriteLine("Calorie entry saved.");
        }

        public void DisplayEntry()
        {
            Console.WriteLine(this.foodName + " - " + this.calories + " calories");
        }

        public int GetCalories()
        {
            return this.calories;
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