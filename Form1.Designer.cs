namespace pr24_pril
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class GraphForm : Form
    {
        private Button addVertexButton;
        private Button addEdgeButton;
        private Button deleteButton;
        private Button welshPowellButton;
        private Button degreeRemovalButton;
        private Button komoskoBatsynButton;
        private Button saveButton;
        private PictureBox drawingArea;
        private Label colorCountLabel;

        private List<Point> vertices;
        private List<Tuple<int, int>> edges;
        private int[,] adjacencyMatrix;
        private bool isAddingVertex = false;
        private bool isAddingEdge = false;
        private bool isDeleting = false;
        private int selectedVertex = -1;
        List<Color> colorList = new List<Color>
            {
                Color.Gold,
                Color.Green,
                Color.Yellow,
                Color.Orange,
                Color.Purple,
                Color.Brown,
                Color.Cyan,
                Color.Magenta,
                Color.Lime,
                Color.Pink,
                Color.Teal,
                Color.Lavender,
                Color.Tan,
                Color.SkyBlue,
            };

        public GraphForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.addVertexButton = new Button();
            this.addEdgeButton = new Button();
            this.deleteButton = new Button();
            this.welshPowellButton = new Button();
            this.degreeRemovalButton = new Button();
            this.komoskoBatsynButton = new Button();
            this.saveButton = new Button();
            this.drawingArea = new PictureBox();
            this.colorCountLabel = new Label();

            this.vertices = new List<Point>();
            this.edges = new List<Tuple<int, int>>();

            // 
            // addVertexButton
            // 
            this.addVertexButton.Location = new System.Drawing.Point(12, 12);
            this.addVertexButton.Name = "addVertexButton";
            this.addVertexButton.Size = new System.Drawing.Size(160, 30);
            this.addVertexButton.TabIndex = 0;
            this.addVertexButton.Text = "Добавить вершину";
            this.addVertexButton.UseVisualStyleBackColor = true;
            this.addVertexButton.Click += new System.EventHandler(this.addVertexButton_Click);
            // 
            // addEdgeButton
            // 
            this.addEdgeButton.Location = new System.Drawing.Point(12, 48);
            this.addEdgeButton.Name = "addEdgeButton";
            this.addEdgeButton.Size = new System.Drawing.Size(160, 30);
            this.addEdgeButton.TabIndex = 1;
            this.addEdgeButton.Text = "Добавить ребро";
            this.addEdgeButton.UseVisualStyleBackColor = true;
            this.addEdgeButton.Click += new System.EventHandler(this.addEdgeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 84);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(160, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить объект";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // welshPowellButton
            // 
            this.welshPowellButton.Location = new System.Drawing.Point(12, 120);
            this.welshPowellButton.Name = "welshPowellButton";
            this.welshPowellButton.Size = new System.Drawing.Size(160, 30);
            this.welshPowellButton.TabIndex = 3;
            this.welshPowellButton.Text = "Алгоритм 1";
            this.welshPowellButton.UseVisualStyleBackColor = true;
            this.welshPowellButton.Click += new System.EventHandler(this.welshPowellButton_Click);
            // 
            // degreeRemovalButton
            // 
            this.degreeRemovalButton.Location = new System.Drawing.Point(12, 156);
            this.degreeRemovalButton.Name = "degreeRemovalButton";
            this.degreeRemovalButton.Size = new System.Drawing.Size(160, 30);
            this.degreeRemovalButton.TabIndex = 4;
            this.degreeRemovalButton.Text = "Алгоритм 2";
            this.degreeRemovalButton.UseVisualStyleBackColor = true;
            this.degreeRemovalButton.Click += new System.EventHandler(this.degreeRemovalButton_Click);
            // 
            // komoskoBatsynButton
            // 
            this.komoskoBatsynButton.Location = new System.Drawing.Point(12, 192);
            this.komoskoBatsynButton.Name = "komoskoBatsynButton";
            this.komoskoBatsynButton.Size = new System.Drawing.Size(160, 30);
            this.komoskoBatsynButton.TabIndex = 5;
            this.komoskoBatsynButton.Text = "Алгоритм 3";
            this.komoskoBatsynButton.UseVisualStyleBackColor = true;
            this.komoskoBatsynButton.Click += new System.EventHandler(this.komoskoBatsynButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 228);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 30);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить изображение";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.Color.White;
            this.drawingArea.Location = new System.Drawing.Point(180, 12);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(600, 600);
            this.drawingArea.TabIndex = 7;
            this.drawingArea.TabStop = false;
            this.drawingArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseClick);
            this.drawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingArea_Paint);
            // 
            // colorCountLabel
            // 
            this.colorCountLabel.AutoSize = true;
            this.colorCountLabel.Location = new System.Drawing.Point(12, 270);
            this.colorCountLabel.Name = "colorCountLabel";
            this.colorCountLabel.Size = new System.Drawing.Size(100, 23);
            this.colorCountLabel.TabIndex = 8;
            this.colorCountLabel.Text = "Цветов используется: 0";

            // 
            // GraphForm
            // 
            this.ClientSize = new System.Drawing.Size(794, 631);
            this.Controls.Add(this.addVertexButton);
            this.Controls.Add(this.addEdgeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.welshPowellButton);
            this.Controls.Add(this.degreeRemovalButton);
            this.Controls.Add(this.komoskoBatsynButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.colorCountLabel);
            this.Name = "GraphForm";
            this.Text = "Раскраска графа";
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
        }

        private void addVertexButton_Click(object sender, EventArgs e)
        {
            isAddingVertex = !isAddingVertex;
            isAddingEdge = false;
            isDeleting = false;
            ResetButtonStates();
            addVertexButton.BackColor = isAddingVertex ? Color.LightGray : SystemColors.Control;
        }

        private void addEdgeButton_Click(object sender, EventArgs e)
        {
            isAddingEdge = !isAddingEdge;
            isAddingVertex = false;
            isDeleting = false;
            ResetButtonStates();
            addEdgeButton.BackColor = isAddingEdge ? Color.LightGray : SystemColors.Control;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            isDeleting = !isDeleting;
            isAddingVertex = false;
            isAddingEdge = false;
            ResetButtonStates();
            deleteButton.BackColor = isDeleting ? Color.LightGray : SystemColors.Control;
        }

        private void ResetButtonStates()
        {
            addVertexButton.BackColor = SystemColors.Control;
            addEdgeButton.BackColor = SystemColors.Control;
            deleteButton.BackColor = SystemColors.Control;
        }

        private void drawingArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (isAddingVertex)
            {
                vertices.Add(new Point(e.X, e.Y));

                int newSize = vertices.Count;
                int[,] newAdjacencyMatrix = new int[newSize, newSize];

                if (adjacencyMatrix != null)
                    for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                        {
                            newAdjacencyMatrix[i, j] = adjacencyMatrix[i, j];
                        }
                    }

                adjacencyMatrix = newAdjacencyMatrix;
                drawingArea.Invalidate();
            }
            else if (isAddingEdge && selectedVertex != -1)
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (IsPointInVertex(e.Location, vertices[i]))
                    {
                        edges.Add(new Tuple<int, int>(selectedVertex, i));
                        adjacencyMatrix[selectedVertex, i] = 1;
                        adjacencyMatrix[i, selectedVertex] = 1;
                        selectedVertex = -1;
                        drawingArea.Invalidate();
                        return;
                    }
                }
            }
            else if (isAddingEdge)
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (IsPointInVertex(e.Location, vertices[i]))
                    {
                        selectedVertex = i;
                        drawingArea.Invalidate();
                        return;
                    }
                }
            }
            else if (isDeleting)
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (IsPointInVertex(e.Location, vertices[i]))
                    {
                        // Удаляем вершину
                        vertices.RemoveAt(i);

                        // Удаляем все рёбра, связанные с удаленной вершиной
                        edges.RemoveAll(edge => edge.Item1 == i || edge.Item2 == i);

                        // Перестраиваем рёбра с обновленными индексами
                        var updatedEdges = new List<Tuple<int, int>>();
                        foreach (var edge in edges)
                        {
                            int newStart = edge.Item1 > i ? edge.Item1 - 1 : edge.Item1;
                            int newEnd = edge.Item2 > i ? edge.Item2 - 1 : edge.Item2;
                            updatedEdges.Add(new Tuple<int, int>(newStart, newEnd));
                        }
                        edges = updatedEdges;

                        // Обновляем матрицу смежности
                        int newSize = vertices.Count;
                        int[,] newAdjacencyMatrix = new int[newSize, newSize];

                        for (int x = 0; x < newSize; x++)
                        {
                            for (int y = 0; y < newSize; y++)
                            {
                                newAdjacencyMatrix[x, y] = adjacencyMatrix[x >= i ? x + 1 : x, y >= i ? y + 1 : y];
                            }
                        }

                        adjacencyMatrix = newAdjacencyMatrix;
                        drawingArea.Invalidate();
                        return;
                    }
                }

                // Удаление рёбер по клику, если это необходимо
                for (int j = 0; j < edges.Count; j++)
                {
                    Tuple<int, int> edge = edges[j];
                    Point start = vertices[edge.Item1];
                    Point end = vertices[edge.Item2];
                    if (IsPointOnLineSegment(e.Location, start, end))
                    {
                        edges.RemoveAt(j);
                        adjacencyMatrix[edge.Item1, edge.Item2] = 0;
                        adjacencyMatrix[edge.Item2, edge.Item1] = 0;
                        drawingArea.Invalidate();
                        return;
                    }
                }
            }
        }

        private bool IsPointInVertex(Point p, Point vertex)
        {
            const int vertexRadius = 10;
            return Math.Sqrt(Math.Pow(p.X - vertex.X, 2) + Math.Pow(p.Y - vertex.Y, 2)) <= vertexRadius;
        }

        private bool IsPointOnLineSegment(Point p, Point start, Point end)
        {
            const int tolerance = 3;
            float dx = end.X - start.X;
            float dy = end.Y - start.Y;
            float lengthSquared = dx * dx + dy * dy;
            float projection = ((p.X - start.X) * dx + (p.Y - start.Y) * dy) / lengthSquared;
            if (projection < 0 || projection > 1) return false;
            float closestX = start.X + projection * dx;
            float closestY = start.Y + projection * dy;
            return Math.Sqrt(Math.Pow(p.X - closestX, 2) + Math.Pow(p.Y - closestY, 2)) <= tolerance;
        }

        private void RemoveVertex(int index)
        {
            vertices.RemoveAt(index);
            edges.RemoveAll(e => e.Item1 == index || e.Item2 == index);
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                adjacencyMatrix[i, index] = 0;
                adjacencyMatrix[index, i] = 0;
            }
        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            foreach (var edge in edges)
            {
                var v1 = vertices[edge.Item1];
                var v2 = vertices[edge.Item2];
                e.Graphics.DrawLine(Pens.Black, v1, v2);
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                var vertex = vertices[i];
                var brush = i == selectedVertex ? Brushes.Red : Brushes.Blue;
                e.Graphics.FillEllipse(brush, vertex.X - 5, vertex.Y - 5, 10, 10);
                e.Graphics.DrawEllipse(Pens.Black, vertex.X - 5, vertex.Y - 5, 10, 10); // Добавляем обводку черным цветом
                e.Graphics.DrawString(i.ToString(), this.Font, Brushes.Black, vertex.X + 5, vertex.Y + 5);
            }
        }

        private void welshPowellButton_Click(object sender, EventArgs e)
        {
            if (adjacencyMatrix.Length == 0)
                return;

            Graph graph = new Graph(adjacencyMatrix);
            int[] colors = graph.WelshPowellColoring();
            UpdateVertexColors(colors);
            UpdateColorCount(colors);
        }

        private void degreeRemovalButton_Click(object sender, EventArgs e)
        {
            if (adjacencyMatrix.Length == 0)
                return;

            Graph graph = new Graph(adjacencyMatrix);
            int[] colors = graph.DegreeRemovalColoring();
            UpdateVertexColors(colors);
            UpdateColorCount(colors);
        }

        private void komoskoBatsynButton_Click(object sender, EventArgs e)
        {
            if (adjacencyMatrix.Length == 0)
                return;

            Graph graph = new Graph(adjacencyMatrix);
            int[] colors = graph.KomoskoBatsynColoring();
            UpdateVertexColors(colors);
            UpdateColorCount(colors);
        }
        private void UpdateColorCount(int[] colors)
        {
            int maxColor = colors.Max();
            colorCountLabel.Text = $"Цветов используется: {maxColor}";
        }
        private void UpdateVertexColors(int[] colors)
        {
            

            List<Brush> brushes = new List<Brush>();
            for (int i = 0; i <= colors.Max(); i++)
            {
                brushes.Add(new SolidBrush(colorList[i % colorList.Count]));
            }

            drawingArea.Paint -= drawingArea_Paint;
            drawingArea.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                foreach (var edge in edges)
                {
                    Point start = vertices[edge.Item1];
                    Point end = vertices[edge.Item2];
                    g.DrawLine(Pens.Black, start, end);
                }

                for (int i = 0; i < vertices.Count; i++)
                {
                    Point vertex = vertices[i];
                    Brush brush;
                    if (i == selectedVertex)
                    {
                        brush = Brushes.Red;
                    }
                    else if (colors != null && i < colors.Length && colors[i] < brushes.Count)
                    {
                        brush = brushes[colors[i]];
                    }
                    else
                    {
                        brush = Brushes.Blue; // Задаем синий цвет, если цвет не найден
                    }
                    g.FillEllipse(brush, vertex.X - 5, vertex.Y - 5, 10, 10);
                    g.DrawEllipse(Pens.Black, vertex.X - 5, vertex.Y - 5, 10, 10); // Добавляем обводку черным цветом
                    g.DrawString(i.ToString(), this.Font, Brushes.Black, vertex.X + 5, vertex.Y + 5);
                }
            };
            drawingArea.Invalidate();
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var bmp = new Bitmap(drawingArea.Width, drawingArea.Height))
            {
                drawingArea.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                var sfd = new SaveFileDialog();
                sfd.Filter = "PNG Image|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName);
                }
            }
        }
    }

    public class Graph
    {
        private int VerticesCount;
        private int[,] AdjacencyMatrix;

        public Graph(int[,] adjacencyMatrix)
        {
            VerticesCount = adjacencyMatrix.GetLength(0);
            AdjacencyMatrix = adjacencyMatrix;
        }

        private int GetVertexDegree(int vertex)
        {
            int degree = 0;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (AdjacencyMatrix[vertex, i] == 1)
                {
                    degree++;
                }
            }
            return degree;
        }

        public int[] WelshPowellColoring()
        {
            var sortedVertices = Enumerable.Range(0, VerticesCount)
                                           .OrderByDescending(v => GetVertexDegree(v))
                                           .ToList();

            int[] colors = new int[VerticesCount];
            for (int i = 0; i < VerticesCount; i++)
            {
                colors[i] = -1;
            }

            int color = 0;

            while (sortedVertices.Any(v => colors[v] == -1))
            {
                color++;

                foreach (var vertex in sortedVertices)
                {
                    if (colors[vertex] == -1 && !HasAdjacentWithColor(vertex, color, colors))
                    {
                        colors[vertex] = color;
                    }
                }
            }

            return colors;
        }

        private bool HasAdjacentWithColor(int vertex, int color, int[] colors)
        {
            for (int i = 0; i < VerticesCount; i++)
            {
                if (AdjacencyMatrix[vertex, i] == 1 && colors[i] == color)
                {
                    return true;
                }
            }
            return false;
        }

        public int[] DegreeRemovalColoring()
        {
            var usedColors = new List<int>();
            int[] colors = new int[VerticesCount];
            for (int i = 0; i < VerticesCount; i++)
            {
                colors[i] = -1;
            }

            int[,] tempMatrix = (int[,])AdjacencyMatrix.Clone();

            while (true)
            {
                var sortedVertices = Enumerable.Range(0, VerticesCount)
                                               .Where(v => colors[v] == -1)
                                               .OrderByDescending(v => GetVertexDegree(v))
                                               .ToList();

                if (!sortedVertices.Any())
                    break;

                var independentSet = new List<int>();
                foreach (var vertex in sortedVertices)
                {
                    if (independentSet.All(v => AdjacencyMatrix[vertex, v] == 0))
                    {
                        independentSet.Add(vertex);
                    }
                }

                int color = usedColors.Count + 1;
                usedColors.Add(color);

                foreach (var vertex in independentSet)
                {
                    colors[vertex] = color;
                }

                foreach (var vertex in independentSet)
                {
                    for (int i = 0; i < VerticesCount; i++)
                    {
                        tempMatrix[vertex, i] = 0;
                        tempMatrix[i, vertex] = 0;
                    }
                }
            }

            return colors;
        }

        public int[] KomoskoBatsynColoring()
        {
            int[] colors = new int[VerticesCount];
            for (int i = 0; i < VerticesCount; i++)
            {
                colors[i] = -1;
            }

            int color = 0;
            List<int> vertices = Enumerable.Range(0, VerticesCount).ToList();

            while (vertices.Any())
            {
                color++;
                int i = vertices[0];
                colors[i] = color;
                vertices.Remove(i);

                int[] row = new int[VerticesCount];
                for (int j = 0; j < VerticesCount; j++)
                {
                    row[j] = AdjacencyMatrix[i, j];
                }

                for (int k = 0; k < VerticesCount; k++)
                {
                    if (colors[k] == -1 && AdjacencyMatrix[i, k] == 0)
                    {
                        bool canColor = true;
                        for (int j = 0; j < VerticesCount; j++)
                        {
                            if (AdjacencyMatrix[k, j] == 1 && colors[j] == color)
                            {
                                canColor = false;
                                break;
                            }
                        }

                        if (canColor)
                        {
                            colors[k] = color;
                            vertices.Remove(k);
                            for (int j = 0; j < VerticesCount; j++)
                            {
                                row[j] |= AdjacencyMatrix[k, j];
                            }
                        }
                    }
                }
            }

            return colors;
        }
    }

}