using Breakout.Entities;

namespace Breakout.Factories;

/// <summary>
/// Concrete implementation of <see cref="IModelFactory{T}"/> for creating instances of <see cref="Level"/>.
/// </summary>
public class LevelFactory : IModelFactory<Level>
{
    /// <summary>
    /// Parses the input data string and returns a new instance of <see cref="Level"/> with the parsed data.
    /// </summary>
    /// <param name="data">The input data string to parse.</param>
    /// <returns>A new instance of <see cref="Level"/> with the parsed data.</returns>
    public Level Parse(string data)
    {
        
        //TODO: Change this to LINQ as well
        string mapStart = data.Split("Map:")[1];
        string mapEnd = mapStart.Split("Map/")[0];
        
        string newLine = mapEnd.Contains("\r\n") ? "\r\n" : "\n";

        string[] map = mapEnd.Split(newLine)
            .Select(row => row.Trim())
            .Where(row => row.Length > 0)
            .ToArray()
            .Reverse() //Needed to make it go from top-to-bottom
            .ToArray();
        
        char[][] xs = map.Select(row => row.Select(column => column).ToArray()).ToArray();
        
        string metaStart = data.Split("Meta:")[1];
        string metaEnd = metaStart.Split("Meta/")[0];
        Dictionary<string, string> metadata = metaEnd.Split(newLine)
            .Select(line => line.Trim())
            .Where(line => line.Length > 0)
            .ToDictionary(line => line.Split(":")[0].Trim(), line => line.Split(":")[1].Trim());
        
        
        string? name = metadata.TryGetValue("Name", out string? value) ? value : null;
        int? time = metadata.TryGetValue("Time", out value) ? int.Parse(value) : null;
        char? hardened = metadata.TryGetValue("Hardened", out value) ? char.Parse(value) : null;
        char? powerUp = metadata.TryGetValue("PowerUp", out value) ? char.Parse(value) : null;
        char? unbreakable = metadata.TryGetValue("Unbreakable", out value) ? char.Parse(value) : null;
        
        var meta = new Meta(name, time, hardened, powerUp, unbreakable);
 
        string legendStart = data.Split("Legend:")[1];
        string legendEnd = legendStart.Split("Legend/")[0];
        
        Dictionary<char, string> legend = legendEnd.Split(newLine)
            .Select(line => line.Trim())
            .Where(line => line.Length > 0)
            .ToDictionary(line => line[0], line => line.Split(")")[1].Trim());
        
        return new Level(xs, meta, legend);
    }
}