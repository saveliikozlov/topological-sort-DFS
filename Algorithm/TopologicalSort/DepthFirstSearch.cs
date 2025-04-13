namespace Algorithm;

public class DepthFirstSearch
{
    public List<int>[] listGraph;
    public HashSet<int> visited;
    public int[,] matrixGraph;
 

    public DepthFirstSearch(List<int>[] listGraph)
    {
        this.listGraph = listGraph;  
        visited = new HashSet<int>();
        matrixGraph = null;
    }
    public DepthFirstSearch(int[,] matrixGraph)
    {
        this.matrixGraph = matrixGraph;
        visited = new HashSet<int>();
        listGraph = null;  
    }
    
    public void PerformDFS(int v, Stack<int> stack)
    {
        visited.Add(v);
        if (listGraph != null)
        {
            foreach (var neighbor in listGraph[v])
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
