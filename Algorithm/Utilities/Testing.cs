namespace Algorithm.Utilities;
using System.Diagnostics;
using Algorithm.Classes;

public static class Testing
{
    public static void Test()
    {
        GraphGenerator generator = new GraphGenerator();
        var results = new List<ExperimentResult>();
        var timer = new Stopwatch();
        
        //Warmup
        for (int vertices = 100; vertices <= 200; vertices += 100)
        {
            for (double density = 0.3; density <= 0.6; density += 0.3)
            {
                var edges = generator.GenerateGraph(vertices, density);
                var listGenerator = new ListGraph(vertices);
                foreach (var (from, to) in edges)
                {
                    listGenerator.AddEdge(from, to);
                }
                var listGraph = listGenerator.GetAdjList();
                var listSorter = new TopologicalSort(listGraph);
                listSorter.Sort(); 
                
            
                var matrixGenerator = new MatrixGraph(vertices);
                foreach (var (from, to) in edges)
                {
                    matrixGenerator.AddEdge(from, to);
                }
                var matrixGraph = matrixGenerator.GetMatrix();
                var matrixSorter = new TopologicalSort(matrixGraph);
                matrixSorter.Sort();
            }
        }
        
        //Real testing
        for (int vertices = 20; vertices <= 200; vertices += 10)
        {
            for (double density = 0.1; density <= 1; density += 0.1)
            {
                for (var times = 0; times < 200; times++)
                {
                    var random = new Random();
                    var num = random.Next(1,3);
                    var edges = generator.GenerateGraph(vertices, density);
                    if (num == 1)
                    {
                        TestList(vertices, density, edges);
                        TestMatrix(vertices, density, edges);
                    }
                    else if (num == 2)
                    {
                        TestMatrix(vertices, density, edges);
                        TestList(vertices, density, edges);
                    }
                }
            }
        }
        
        var averaged = results
            .GroupBy(r => new { r.VertexCount, r.EdgeDensity, r.Representation })
            .Select(g => new ExperimentResult
            {
                VertexCount = g.Key.VertexCount,
                EdgeDensity = g.Key.EdgeDensity,
                Representation = g.Key.Representation,
                Time = g.Average(r => r.Time)
            })
            .ToList();

        SaveResults.SaveResultsToCSV(averaged, "filepath"); //add filepath
        return;

        void TestList(int vertices, double density, List<(int from, int to)> edges)
        {
            var listGenerator = new ListGraph(vertices);
            foreach (var (from, to) in edges)
            {
                listGenerator.AddEdge(from, to);
            }
            var listGraph = listGenerator.GetAdjList();
            var listSorter = new TopologicalSort(listGraph);
            timer.Start();
            listSorter.Sort(); 
            timer.Stop();
            var timeList = timer.Elapsed.TotalMilliseconds;
                    
            results.Add(new ExperimentResult
            {
                VertexCount = vertices,
                EdgeDensity = density,
                Representation = "List",
                Time = timeList
            });
        }

        void TestMatrix(int vertices, double density, List<(int from, int to)> edges)
        {
            var matrixGenerator = new MatrixGraph(vertices);
            foreach (var (from, to) in edges)
            {
                matrixGenerator.AddEdge(from, to);
            }
            var matrixGraph = matrixGenerator.GetMatrix();
            var matrixSorter = new TopologicalSort(matrixGraph);
            timer.Reset();
            timer.Start();
            matrixSorter.Sort();
            timer.Stop();
            var timeMatrix = timer.Elapsed.TotalMilliseconds;
                
            results.Add(new ExperimentResult
            {
                VertexCount = vertices,
                EdgeDensity = density,
                Representation = "Matrix",
                Time = timeMatrix
            });
        }
    }
}