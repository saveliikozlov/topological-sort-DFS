using Algorithm.Utilities;

namespace Algorithm;
using Algorithm.Classes;
public class Program
{
    public static void Main(string[] args)
    {
        int vertices = 5;
        double density = 0.5;
        GraphGenerator generator = new GraphGenerator();
        var edges = generator.GenerateGraph(vertices, density);
        
        var listgraph = new ListGraph(vertices);
        foreach (var (from, to) in edges)
        {
            listgraph.AddEdge(from, to);
        }
        listgraph.Print();
        Console.WriteLine("-------------------");
        
        var matrixGraph = new MatrixGraph(vertices);
        foreach (var (from, to) in edges)
        {
            matrixGraph.AddEdge(from, to);
        }
        matrixGraph.PrintMatrix();
    }
}

