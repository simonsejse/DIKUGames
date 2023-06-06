namespace Breakout.Entities;


public class Meta {
    public string? Name { get; }
    public int? Time { get; }
    public char? Hardened { get; }
    public char? PowerUp { get; }
    public char? Unbreakable { get; }
    

    /// <summary>
    /// Represents metadata for a game entity.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    /// <param name="time">The time of the entity.</param>
    /// <param name="hardened">Indicates if the entity is hardened.</param>
    /// <param name="powerUp">Indicates if the entity has a power-up.</param>
    /// <param name="unbreakable">Indicates if the entity is unbreakable.</param>
    public Meta(string? name, int? time, char? hardened, char? powerUp, char? unbreakable) {
        Name = name;
        Time = time;
        Hardened = hardened;
        PowerUp = powerUp;
        Unbreakable = unbreakable;
    }
}