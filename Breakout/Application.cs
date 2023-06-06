using DIKUArcade.GUI;

namespace Breakout;


public class Application
{
    private static void Main(string[] args)
    {
        var window = new WindowArgs
        {
            Title = "Breakout v1",
            Width = 700,
            Height = 700
        };

        var game = new Game(window);
        game.Run();
    }
}