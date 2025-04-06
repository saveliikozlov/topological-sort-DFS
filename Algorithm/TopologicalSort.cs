namespace Algorithm;
using System;
using System.Collections.Generic;

class TopologicalSort
{
    private DepthFirstSearch dfs;

    public TopologicalSort(object graphInput)
    {
        if (graphInput is int[,])  
        {
            dfs = new DepthFirstSearch((int[,])graphInput);
        }
        else if (graphInput is Dictionary<int, List<int>>)  
        {
            dfs = new DepthFirstSearch((Dictionary<int, List<int>>)graphInput);
        }
        else
        {
            throw new ArgumentException("Invalid graph input type.");
        }
    }
    
    public List<int> Sort()
    {
        Stack<int> stack = new Stack<int>();
        Dictionary<int, List<int>> graph = dfs.graph;
        
        if (dfs.graph != null)
        {
            foreach (var vertex in graph.Keys)
            {
                if (!dfs.visited.Contains(vertex))
                {
                    dfs.PerformDFS(vertex, stack);
                }
            }
        }
        else if (dfs.matrixGraph != null)  
        {
            int n = dfs.matrixGraph.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                if (!dfs.visited.Contains(i))
                {
                    dfs.PerformDFS(i, stack);
                }
            }
        }
        

        List<int> result = new List<int>();
        while (stack.Count > 0)
        {
            result.Add(stack.Pop());
        }
        return result;
    }
}
