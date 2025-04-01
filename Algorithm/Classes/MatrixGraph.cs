namespace Algorithm.Classes;

public class MatrixGraph
{
    private int[,] matrix;
    private int vertices;

    public MatrixGraph(int vertices)
    {
        this.vertices = vertices;
        matrix = new int[vertices, vertices];
    }
    public void AddEdge(int i, int j)
    {
        matrix[i, j] = 1;
        matrix[j, i] = 1;
    }
    // IF NEEDED
    // public void RemoveEdge(int i, int j)
    // {
    //     matrix[i, j] = 0;
    //     matrix[j, i] = 1;
    // }

    public bool HasEdge(int i, int j)
    {
        if (matrix[i, j] == 1)
            return true;
        return false;
    }

    public void PrintMatrix()
    {
        Console.WriteLine("Adjacency matrix:");
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public int[,] GetMatrix()
    {
        return matrix;
    }
}