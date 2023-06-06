using Breakout.Entities;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using Breakout.Entities.BlockTypes;
using Breakout.GameModifiers.PowerUps;
using Breakout.PowerUps;

namespace BreakoutTests.EntitiesTest;

[TestFixture]
public class BlockEntityTest
{
    
    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
    }
    
    [Test]
    public void TestBlockDefaultValues()
    {
        var blockEntity = BlockEntity.Create(
            new Vec2F(0.5f, 0.5f),
            new Image(Path.Combine("Assets", "Images", "teal-block.png")), 
            new Image(Path.Combine("Assets", "Images", "teal-block-damaged.png")),
            new StandardBlockType(), 
            new ExtraLifeGameModifier(),
            null
        );
        Assert.That(blockEntity.Health, Is.EqualTo(1));
        Assert.That(blockEntity.StartHealth, Is.EqualTo(1));
        Assert.That(blockEntity.Value, Is.EqualTo(10));
        Assert.That(blockEntity.Image, Is.Not.Null);
        Assert.That(blockEntity.DamagedImage, Is.Not.Null);
    }

    [Test]
    public void TestBlockTakeDamageAndIsDead()
    {
        var blockEntity = BlockEntity.Create(
            new Vec2F(0.5f, 0.5f),
            new Image(Path.Combine("Assets", "Images", "teal-block.png")), 
            new Image(Path.Combine("Assets", "Images", "teal-block-damaged.png")),
            new HardenedBlockType(),
            new ExtraLifeGameModifier(),
            null

        );
        Assert.That(blockEntity.Health, Is.EqualTo(2));
        blockEntity.TakeDamage();
        Assert.That(blockEntity.Health, Is.LessThan(2));
        Assert.That(blockEntity.Health, Is.EqualTo(1));
        Assert.That(blockEntity.IsDead(), Is.Not.True);
        blockEntity.TakeDamage();
        Assert.That(blockEntity.Health, Is.LessThan(1));
        Assert.That(blockEntity.IsDead(), Is.True);
    }

    [Test]
    public void TestHardenedBlockType()
    {
        var blockEntity = BlockEntity.Create(
            new Vec2F(0.5f, 0.5f),
            new Image(Path.Combine("Assets", "Images", "teal-block.png")), 
            new Image(Path.Combine("Assets", "Images", "teal-block-damaged.png")),
            new HardenedBlockType(),
            new ExtraLifeGameModifier(),
            null
        );
        Assert.That(blockEntity.Health, Is.EqualTo(2));
        Assert.That(blockEntity.StartHealth, Is.EqualTo(2));
    }

    [Test]
    public void TestUnbreakableType()
    {
        var blockEntity = BlockEntity.Create(
            new Vec2F(0.5f, 0.5f),
            new Image(Path.Combine("Assets", "Images", "teal-block.png")), 
            new Image(Path.Combine("Assets", "Images", "teal-block-damaged.png")),
            new UnbreakableBlockType(),
            new ExtraLifeGameModifier(),
            null
        );
        Assert.That(blockEntity.Health, Is.EqualTo(-1));
        blockEntity.HandleCollision();
        Assert.That(blockEntity.Health, Is.EqualTo(-1));
    }
}