using DIKUArcade.Math;

namespace Breakout.Utility;

public static class ConstantsUtil
{
    
    public static readonly Vec2F StartGamePosition = new(0.1f, 0.1f);
    public static readonly Vec2F StartGameExtent = new(0.5f, 0.5f);

    public static readonly Vec2F ContinueGamePosition = new(0.1f, 0.1f);
    public static readonly Vec2F ContinueGameExtent = new(0.5f, 0.5f);
    
    public static readonly Vec2F ToMainMenuPosition =  new(0.1f, 0f);
    public static readonly Vec2F ToMainMenuExtent = new(0.5f, 0.5f);
    
    public static readonly Vec2F QuitGamePosition =new(0.1f, 0f);
    public static readonly Vec2F QuitGameExtent = new(0.5f, 0.5f);
    
    public static readonly Vec2F PlayerPosition = new(0.5f - 0.2f / 2f, 0.03f);
    public static readonly Vec2F PlayerExtent = new(0.2f,0.028f);
    
    public static readonly Vec2F BallPosition = new(0.5f - 0.03f / 2, 0.03f + 0.03f);
    public static readonly Vec2F BallExtent = new(0.03f, 0.03f);    

    public static readonly Vec2F BlockExtent = new(0.08333333333f, 0.04f);

    public static readonly Vec2F HealthPosition = new(0.01f, 0.04f);
    public static readonly Vec2F HealthExtent = new(0.2f, 0.2f);
    
    public static readonly Vec2F ScorePosition = new(0.01f, 0.01f);
    public static readonly Vec2F ScoreExtent = new(0.2f, 0.2f);

    public static readonly Vec2F LevelPosition = new(0.01f, -0.02f);
    public static readonly Vec2F LevelExtent = new(0.2f, 0.2f);
    
    public static readonly Vec2F TimerPosition = new(.01f, -0.05f);
    public static readonly Vec2F TimerExtent = new(0.2f, 0.2f);
    
    public static readonly Vec2F BallDirection = new(0.01f, 0.01f);
    public const float BallSpeed = 0.1f;
    
    public static readonly Vec2F PowerUpExtent = new(0.04f, 0.04f);

}