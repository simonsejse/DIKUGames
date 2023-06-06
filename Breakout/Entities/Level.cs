namespace Breakout.Entities;

public class Level {
    /// <summary>
    /// Map is a 2-dimensional char array accessible through a public getter and private setter
    /// </summary>
    public char[][] Map { get; private set; }
    /// <summary>
    /// Meta is an instance of Meta-class, accessible through a public getter and private setter
    /// </summary>
    public Meta Meta { get; private set; }
    /// <summary>
    /// Legends is a dictionary mapping characters to strings, accessible through a public getter 
    /// and private setter
    /// </summary>
    public Dictionary<char, string> Legends  { get; private set; }
    
   /// <summary>
   /// Initializes a new instance of the Level-class with the specified map, meta, and legends
   /// </summary>
   /// <param name="map">A two-dimensional char array representing the level map</param>
   /// <param name="meta">A Meta object containing metadata about the level</param>
   /// <param name="legends">A dictionary containing character keys and corresponding string values 
   /// for the level legends</param>
    public Level(char[][] map, Meta meta, Dictionary<char, string> legends) {
        Map = map;
        Meta = meta;
        Legends = legends;
    }
}