using System.Text;
using Algorithm.Classes;

namespace Algorithm.Utilities;

public static class SaveResults
{
    public static void SaveResultsToCSV(List<ExperimentResult> results, string path)
    {
        var csv = new StringBuilder();
        csv.AppendLine("VertexCount,EdgeDensity,Representation,Time");
        foreach (var r in results)
        {
            csv.AppendLine($"{r.VertexCount},{r.EdgeDensity},{r.Representation},{r.Time}");
        }
        File.WriteAllText(path, csv.ToString());
    }
}