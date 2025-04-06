namespace Algorithm;

public class DepthFirstSearch
{
    public Dictionary<int, List<int>> graph;
    public HashSet<int> visited;

    public DepthFirstSearch(Dictionary<int, List<int>> graph)
    {
        this.graph = graph;  
        this.visited = new HashSet<int>();
    }

    
    public void PerformDFS(int v, Stack<int> stack)
    {
        visited.Add(v);

       
        foreach (var neighbor in graph[v])
        {
            if (!visited.Contains(neighbor))
            {
                PerformDFS(neighbor, stack);
            }
        }
        
        stack.Push(v);
    }
}
