namespace DefensieTrainer.WebApp.Constants
{
    public class TrainingTypes
    {
        public static readonly Dictionary<int, string> SortTraining = new Dictionary<int, string>
        {
            { 0, "hardlopen" },
            { 1, "zwemmen" }
        };
        public static string GetSortTrainingString(int key)
        {
            if (SortTraining.ContainsKey(key))
            {
                return SortTraining[key];
            }
            else
            {
                throw new KeyNotFoundException($"Key {key} not found in SortTraining dictionary.");
            }
        }
    }
}
