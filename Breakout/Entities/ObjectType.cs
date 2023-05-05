using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;

namespace Breakout.Entites;

    /// <summary>
    /// Enumeration of different types of game objects in Breakout.
    /// </summary>
    public enum ObjectType
    {
        Wall,
        Block,
        Player,
        Ball
    }

    public static class ObjectTypeFactory
    {
        public static (Shape, Vec2F) CreateShape(ObjectType objectType)
        {
            Vec2F position;
            Shape shape;
            switch (objectType)
            {
                case ObjectType.Wall:
                    // create wall shape and set position
                    shape = new DynamicShape(
                        new Vec2F(0.0f, 0.0f), new Vec2F(1.0f, 1.0f), new Vec2F(0.5f, 0.5f));
                    position = new Vec2F(0.0f, 0.0f);
                    break;
                case ObjectType.Block:
                    // create block shape and set position
                    shape = new DynamicShape(
                        new Vec2F(0.0f, 0.0f), new Vec2F(1.0f, 1.0f), new Vec2F(0.5f, 0.5f));
                    position = new Vec2F(0.0f, 0.0f);
                    break;
                case ObjectType.Player:
                    // create player shape and set position
                    shape = new DynamicShape(
                        new Vec2F(0.0f, 0.0f), new Vec2F(0.2f, 0.05f), new Vec2F(0.0f, 0.0f));
                    position = new Vec2F(0.4f, 0.1f);
                    break;
                case ObjectType.Ball:
                    // create ball shape and set position
                    shape = new DynamicShape(
                        new Vec2F(0.0f, 0.0f), new Vec2F(0.03f, 0.03f), new Vec2F(0.001f, 0.001f));
                    position = new Vec2F(0.5f, 0.5f);
                    break;
                default:
                    throw new ArgumentException("Invalid object type");
            }
            return (shape, position);
        }
        
        
    }
