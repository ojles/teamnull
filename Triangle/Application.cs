namespace teamnull
{
    internal static class Application
    {
        public static void Main(string[] args)
        {
            // run task2
            const string dataFolder = "../../Data";
            var triangles = Tasks.ReadTrianglesToSortedList($"{dataFolder}/Triangles.txt");
            Tasks.WriteTriangleListToFile(triangles, $"{dataFolder}/TrianglesSorted.txt");
        }
    }
}