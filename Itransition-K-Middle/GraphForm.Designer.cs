namespace Itransition_K_Middle
{
    partial class GraphForm : Form
    {
        private readonly Point[][] _clusters = [];

        private readonly Color[] _colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple };

        public GraphForm(Point[][] points)
        {
            this._clusters = points;

            this.Text = "Simple Graph Drawing";
            this.Size = new Size(800, 800);
            this.Paint += new PaintEventHandler(DrawGraph);
        }

        private void DrawGraph(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < _clusters.Length; i++)
            {
                var cluster = _clusters[i];
                var clusterColor = _colors[i % _colors.Length];

                foreach (var point in cluster)
                {
                    e.Graphics.FillEllipse(new SolidBrush(clusterColor), point.X - 8, point.Y - 8, 16, 16);
                }
            }

            var kMiddle = new KMiddle(_clusters.SelectMany(x => x).ToArray(), 3, 100);

            for (var i = 0; i < kMiddle.Centroids.Length; i++)
            {
                e.Graphics.FillEllipse(new SolidBrush(_colors[4]), kMiddle.Centroids[i].X - 20, kMiddle.Centroids[i].Y - 20, 40, 40);
            }
        }
    }
}