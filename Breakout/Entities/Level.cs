using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Entities;

public class Level
{
    public char[][] Map { get; set; }
    public Meta Meta { get; set; }
    public Dictionary<char, string> Legends  { get; set; }
}