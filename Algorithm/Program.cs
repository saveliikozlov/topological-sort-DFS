using Algorithm.Utilities;

namespace Algorithm;
using Classes;
public class Program
{
    public static void Main(string[] args)
    {
        int vertices = 20;
        double density = 1;
        GraphGenerator generator = new GraphGenerator();
        var edges = generator.GenerateGraph(vertices, density);
        
        
        var listGenerator = new ListGraph(vertices);
        foreach (var (from, to) in edges)
        {
            listGenerator.AddEdge(from, to);
        }
        listGenerator.Print();
        var listGraph = listGenerator.GetAdjList();
        var sorter = new TopologicalSort(listGraph);
        var result = sorter.Sort();
        foreach (var i in result)
        {
            Console.Write(i + "->");
        }
        
        
        var matrixGraph = new MatrixGraph(vertices);
        foreach (var (from, to) in edges)
        {
            matrixGraph.AddEdge(from, to);
        }
        
    }
}

