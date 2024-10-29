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
            this.Size = new Size(400, 400);
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
        }
    }
}
