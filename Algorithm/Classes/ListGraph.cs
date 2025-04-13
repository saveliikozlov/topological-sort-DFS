namespace Algorithm.Classes;

public class ListGraph
{
    private List<int>[] AdjList;
    private int vertices;

    public ListGraph(int vertices)
    {
        this.vertices = vertices;
        AdjList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            AdjList[i] = new List<int>();
        }
    }

    public void AddEdge(int i, int j)
    {
        AdjList[i].Add(j);
    }
    // IF NEEDED
    // public void RemoveEdge(int i, int j)
    // {
    //     AdjList[i].Remove(j);
    // }

    public bool ContainsEdge(int i, int j)
    {
        return AdjList[i].Contains(j);
    }

    public void Print()
    {
        Console.WriteLine("Adjacency List:");
        for (int i = 0; i < vertices; i++)
        {
            Console.Write(i + ": ");
            foreach (int neighbor in AdjList[i])
            {
                Console.Write(neighbor + " ");
            }
            Console.WriteLine();
        }
    }
    
    public List<int>[] GetAdjList()
    {
        return AdjList;
    }
}