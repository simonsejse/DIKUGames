using Breakout.Entities;

namespace Breakout.Factories;

public class LevelFactory : IModelFactory<Level>
{
    public Level Parse(string data)
    {
        var mapStart = data.Split("Map:")[1];
        var mapEnd = mapStart.Split("Map/")[0];
        var map = mapEnd.Split("\r\n").Skip(1).SkipLast(1).ToArray();
        
        var xs = Enumerable.Range(0, 25).Select(i => new char[12]).ToArray();

        for (var row = 0; row < map.Length; row++)
        {
            for (var column = 0; column < map[row].Length; column++)
            {
                xs[row][column] = map[row][column];
            }
        }

        var metaStart = data.Split("Meta:")[1];
        var metaEnd = metaStart.Split("Meta/")[0];
        var metadata = metaEnd.Split("\r\n")
            .Select(line => line.Trim())
            .Where(line => line.Length > 0)
            .ToDictionary(line => line.Split(":")[0].Trim(), line => line.Split(":")[1].Trim());
        
        
        var name = metadata.TryGetValue("Name", out var value) ? value : null;
        int? time = metadata.TryGetValue("Time", out value) ? int.Parse(value) : null;
        char? hardened = metadata.TryGetValue("Hardened", out value) ? char.Parse(value) : null;
        char? powerUp = metadata.TryGetValue("PowerUp", out value) ? char.Parse(value) : null;
        char? unbreakable = metadata.TryGetValue("Unbreakable", out value) ? char.Parse(value) : null;
        
        var meta = new Meta(name, time, hardened, powerUp, unbreakable);
 
        var legendStart = data.Split("Legend:")[1];
        var legendEnd = legendStart.Split("Legend/")[0];
        var legend = legendEnd.Split("\r\n")
            .Select(line => line.Trim())
            .Where(line => line.Length > 0)
            .ToDictionary(line => line[0], line => line.Split(")")[1].Trim());
        
        return new Level(xs, meta, legend);

    }
}