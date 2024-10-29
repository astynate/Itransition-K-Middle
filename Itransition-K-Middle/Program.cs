namespace Itransition_K_Middle
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var countClasters = 3;
            var leftBorder = 50;
            var rightBorder = 500;
            var clusterSize = 250;
            var minPointsInClaster = 7;
            var maxPointsInClaster = 20;
            var clusterDistance = 150;

            var points = new Point[countClasters][];
            var random = new Random();

            var clusterOffsets = new int[countClasters];

            for (int i = 0; i < countClasters; i++)
            {
                var newOffset = leftBorder;
                var previousOffsets = clusterOffsets.Take(i).Concat(clusterOffsets.Skip(i + 1)).ToArray();

                while (!IsValidOffset(newOffset, previousOffsets, clusterDistance, clusterSize))
                {
                    newOffset = random.Next(leftBorder, rightBorder);
                }

                clusterOffsets[i] = newOffset;
            }

            for (int i = 0; i < countClasters; i++)
            {
                var pointsInCluster = random.Next(minPointsInClaster, maxPointsInClaster + 1);
                
                points[i] = new Point[pointsInCluster];

                for (var j = 0; j < pointsInCluster; j++)
                {
                    var offsetX = (int)(random.NextDouble() * clusterSize / 2);
                    var offsetY = (int)(random.NextDouble() * clusterSize / 2);

                    points[i][j] = new Point(offsetX + clusterOffsets[i], offsetY + clusterOffsets[i]);
                }
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new GraphForm(points));
        }

        private static bool IsValidOffset(int newOffset, int[] existingOffsets, int clusterDistance, int boxSize)
        {
            foreach (var offset in existingOffsets)
            {
                if (Math.Abs(newOffset - offset) < clusterDistance)
                {
                    return false;
                }
            }

            return true;
        }
    }
}