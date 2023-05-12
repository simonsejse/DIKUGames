namespace Breakout.Entities;


public class Meta
{
    public string? Name { get; set; }
    public int? Time { get;set; }
    public char? Hardened { get; set;}
    public char? PowerUp { get;set; }
    public char? Unbreakable { get;set; }

    public Meta()
    {
        
    }

    
    /// <summary>
    /// Constructor that takes several optional (?) parameters
    /// These parameters are generated individually from the level-ASCII-map.txt files
    /// </summary>
    /// <param name="name">Name of the level</param>
    /// <param name="time">Time limit to cmomplete the level</param>
    /// <param name="hardened">TODO: </param>
    /// <param name="powerUp">TODO: </param>
    /// <param name="unbreakable">TODO: </param>

    public Meta(string? name, int? time, char? hardened, char? powerUp, char? unbreakable)
    {
        Name = name;
        Time = time;
        Hardened = hardened;
        PowerUp = powerUp;
        Unbreakable = unbreakable;
    }
}