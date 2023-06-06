using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

/// <summary>
/// Represents a factory for creating background entities in Breakout (the background image).
/// </summary>
public class BackgroundFactory : IEntityFactory<Entity> {
    private readonly string _imagePath;
    
    /// <summary>
    /// Initializes a new instance of the BackgroundFactory class with the provided image paths.
    /// </summary>
    /// <param name="args">The image paths to use for creating the background entities.</param>
    public BackgroundFactory(params string[] args) {
        _imagePath = Path.Combine(args);
    }
    
    /// <summary>
    /// Creates a background entity using the configured image path.
    /// </summary>
    /// <returns>The created background entity.</returns>
    public Entity Create() {
        var image = new Image(_imagePath);
        return new Entity(new StationaryShape(new Vec2F(0, 0), new Vec2F(1, 1)), image);
    }
}