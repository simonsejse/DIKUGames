
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Galaga;

public class PlayerShot : Entity 
{
  private static Vec2F extent = new Vec2F(0.008f, 0.021f), direction = new Vec2F(0.0f, 0.1f);
  
  public PlayerShot(Vec2F position, IBaseImage image) : base(new DynamicShape(position, extent, direction), image) {}
} 
