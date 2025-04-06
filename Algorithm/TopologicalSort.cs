namespace Algorithm;
using System;
using System.Collections.Generic;

class TopologicalSort
{
    private DepthFirstSearch dfs;

    public TopologicalSort(Dictionary<int, List<int>> graph)
    {
        dfs = new DepthFirstSearch(graph);  
    }
    
    public List<int> Sort()
    {
        Stack<int> stack = new Stack<int>();
        Dictionary<int, List<int>> graph = dfs.graph;

        foreach (var vertex in graph.Keys)
        {
            if (!dfs.visited.Contains(vertex))
            {
                dfs.PerformDFS(vertex, stack);
            }
        }

        List<int> result = new List<int>();
        while (stack.Count > 0)
        {
            result.Add(stack.Pop());
        }
        return result;
    }

    public static void Main(string[] args)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>()
        {
            { 0, new List<int> { 1, 2 } },
            { 1, new List<int> { 3 } },
            { 2, new List<int> { 3 } },
            { 3, new List<int> { 4 } },
            { 4, new List<int>() }  
        };

        TopologicalSort ts = new TopologicalSort(graph);

        List<int> result = ts.Sort();

        Console.WriteLine("Topological Sort:");
        foreach (var vertex in result)
        {
            Console.Write(vertex + " ");
        }
    }
}
