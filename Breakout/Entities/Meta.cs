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

    public Meta(string? name, int? time, char? hardened, char? powerUp, char? unbreakable)
    {
        Name = name;
        Time = time;
        Hardened = hardened;
        PowerUp = powerUp;
        Unbreakable = unbreakable;
    }
}