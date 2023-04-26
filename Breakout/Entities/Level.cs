namespace Breakout.Entities;

public class Level
{
    public char[][] Map { get; private set; }
    public Meta Meta { get; private set; }
    public Dictionary<char, string> Legends  { get; private set; }
    
    #region Constructor
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