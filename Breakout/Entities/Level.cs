namespace Breakout.Entities;

public class Level
{
    #region Properties and fields
    /// <summary>
    /// Map is a 2-dimensional char array accessible through a public getter and private setter
    /// </summary>
    public char[][] Map { get; private set; }
    /// <summary>
    /// Meta is an instance of Meta-class, accessible through a public getter and private setter
    /// </summary>
    public Meta Meta { get; private set; }
    /// <summary>
    /// Legends is a dictionary mapping characters to strings, accessible through a public getter and private setter
    /// </summary>
    public Dictionary<char, string> Legends  { get; private set; }
    
    #endregion
    
    #region Constructor
   /// <summary>
   /// Initializes a new instance of the Level-class with the specified map, meta, and legends
   /// </summary>
   /// <param name="map">A two-dimensional char array representing the level map</param>
   /// <param name="meta">A Meta object containing metadata about the level</param>
   /// <param name="legends">A dictionary containing character keys and corresponding string values for the level legends</param>
    public Level(char[][] map, Meta meta, Dictionary<char, string> legends)
    {
        Map = map;
        Meta = meta;
        Legends = legends;
    }
    #endregion
    
    /*
    #region Level builder

    public class Builder
    {
        private char[][] _map;
        private Meta _meta;
        private Dictionary<char, string> _legends;

        public Builder SetMap(char[][] map)
        {
            _map = map;
            return this;
        }
    
        public Builder SetMeta(Meta meta)
        {
            _meta = meta;
            return this;
        }
    
        public Builder SetLegends(Dictionary<char, string> legends)
        {
            _legends = legends;
            return this;
        }
    
        public Level Build()
        {
            return new Level(_map, _meta, _legends);
        }   
    }
    #endregion
    */
   
}