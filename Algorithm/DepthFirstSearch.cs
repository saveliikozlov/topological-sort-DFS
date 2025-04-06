namespace Algorithm;

public class DepthFirstSearch
{
    public Dictionary<int, List<int>> graph;
    public HashSet<int> visited;
    public int[,] matrixGraph;
 

    public DepthFirstSearch(Dictionary<int, List<int>> graph)
    {
        this.graph = graph;  
        this.visited = new HashSet<int>();
        this.matrixGraph = null;
    }
    public DepthFirstSearch(int[,] matrixGraph)
    {
        this.matrixGraph = matrixGraph;
        this.visited = new HashSet<int>();
        this.graph = null;  
    }
    
    public void PerformDFS(int v, Stack<int> stack)
    {
        visited.Add(v);
        if (graph != null)
        {
            foreach (var neighbor in graph[v])
            {
                if (!visited.Contains(neighbor))
                {
                    PerformDFS(neighbor, stack);
                }
            }
        }
        else if (matrixGraph != null)
        {
            int n = matrixGraph.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                if (matrixGraph[v, i] == 1 && !visited.Contains(i))
                {
                    PerformDFS(i, stack);
                }
            }
        }
        
        stack.Push(v);
    }
}
