namespace Algorithm;
using System;
using System.Collections.Generic;

class TopologicalSort
{
    public DepthFirstSearch dfs;
    public TopologicalSort(object graphInput)
    {
        if (graphInput is int[,])  
        {
            dfs = new DepthFirstSearch((int[,])graphInput);
        }
        else if (graphInput is List<int>[])  
        {
            dfs = new DepthFirstSearch((List<int>[])graphInput);
        }
        else
        {
            throw new ArgumentException("Invalid graph input type.");
        }
    }
    
    public List<int> Sort()
    {
        var stack = new Stack<int>();
        List<int>[] graph = dfs.listGraph;
        
        if (dfs.listGraph != null)
        {
            var vertexCount = dfs.listGraph.Length;
            for (int i = 0; i < vertexCount; i++)
            {
                if (!dfs.visited.Contains(i))
                {
                    dfs.PerformDFS(i, stack);
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
