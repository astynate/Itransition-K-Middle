namespace Itransition_K_Middle
{
    public class KMiddle
    {
        public Point[] Points { get; init; } = [];
        public Point[] Centroids { get; private set; } = [];
        public int CountClusters { get; init; } = 0;

        public KMiddle(Point[] points, int countClusters, int countUpdates) 
        {
            Points = points;
            CountClusters = countClusters;
            Centroids = new Point[countClusters];

            InitializeCentroids();

            for (int i = 0; i < countUpdates; i++)
            {
                UpdateCentroids();
            }
        }

        private void InitializeCentroids()
        {
            Random rand = new Random();

            for (int i = 0; i < CountClusters; i++)
            {
                var index = rand.Next(Points.Length);
                var centroidPoint = new Point(Points[index].X, Points[index].Y);

                Centroids[i] = centroidPoint;
            }
        }

        private Point CalculateAverage(List<Point> points)
        {
            var sumX = points.Sum(p => p.X);
            var sumY = points.Sum(p => p.Y);

            var count = points.Count;

            return new Point(sumX / count, sumY / count);
        }

        private void UpdateCentroids()
        {
            for (int i = 0; i < CountClusters; i++)
            {
                var clusterPoints = Points
                    .Where(p => GetNearestCentroidToTargetPoint(p) == i)
                    .ToList();
                
                if (clusterPoints.Count > 0)
                {
                    Centroids[i] = CalculateAverage(clusterPoints);
                }
            }
        }

        private int GetNearestCentroidToTargetPoint(Point point)
        {
            var minDistance = double.MaxValue;
            var nearestIndex = 0;

            for (int i = 0; i < Centroids.Length; i++)
            {
                var distance = GetDistance(point, Centroids[i]);
                
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestIndex = i;
                }
            }

            return nearestIndex;
        }

        private double GetDistance(Point firstPoint, Point secondPoint) 
            => Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2));
    }
}