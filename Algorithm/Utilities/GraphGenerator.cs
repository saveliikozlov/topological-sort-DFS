using Algorithm.Classes;

namespace Algorithm.Utilities;

public class GraphGenerator
{
    private Random random = new Random();

    public List<(int from, int to)> GenerateGraph(int verticesCount, double density)
    {
        
        List<int> nodes = new List<int>();
        for (int i = 0; i < verticesCount; i++)
            nodes.Add(i);
        Shuffle(nodes);
        
        List<(int from, int to)> AllPossibleEdges = new List<(int from, int to)>();
        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = i + 1; j < verticesCount; j++)
            {
                int from = nodes[i];
                int to = nodes[j];
                AllPossibleEdges.Add((from, to));
            }
        }
        
        int MaxEdges = AllPossibleEdges.Count;
        int targetEdges = Convert.ToInt32(density * MaxEdges);
        
        Shuffle(AllPossibleEdges);
        return AllPossibleEdges.Take(Math.Min(targetEdges, MaxEdges)).ToList();
    }
    
    
    
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}