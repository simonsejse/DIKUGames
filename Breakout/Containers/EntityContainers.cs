using System.Drawing;
using Breakout.Entities;
using Breakout.Factories;
using Breakout.States;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Containers;

public class EntityManager
{
    private ITextFactory _textFactory;
    public EntityContainer<BlockEntity> BlockEntities { get; set; }
    public EntityContainer<BallEntity> BallEntities { get; }
    public PlayerEntity PlayerEntity { get; }
    private Text _scoreText;
    private Text _levelText;
    private Text _healthText;

    public EntityManager()
    {
        PlayerEntity = PlayerEntity.Create();
        BlockEntities = new EntityContainer<BlockEntity>();
        BallEntities = new EntityContainer<BallEntity>();
        _textFactory = new DefaultTextFactory();
        int lives = PlayerEntity.GetLives();
        _healthText = _textFactory.Create($"{lives} {string.Concat(Enumerable.Repeat("❤", lives))}", ConstantsUtil.HealthPosition, ConstantsUtil.HealthExtent, Color.Red);
        _scoreText = _textFactory.Create($"Score: {PlayerEntity.GetPoints()}", ConstantsUtil.ScorePosition, ConstantsUtil.ScoreExtent, Color.White);
        _levelText = _textFactory.Create("Level: 0", ConstantsUtil.LevelPosition, ConstantsUtil.LevelExtent, Color.White);
    }

    public void RenderEntities()
    {
        BlockEntities.RenderEntities();
        BallEntities.RenderEntities();
        PlayerEntity.RenderEntity();
        _scoreText.RenderText();
        _levelText.RenderText();
        _healthText.RenderText();
    }

    public void Move()
    {
        PlayerEntity.Move();
        BallEntities.Iterate(ball =>
        {
            ball.CheckBlockCollisions(BlockEntities, PlayerEntity);
            CollisionManager.CheckBallPlayerCollision(ball, PlayerEntity);
            ball.Move();
        });
    }

    public void Update(GameRunningState state)
    {
        int lives = PlayerEntity.GetLives();
        _healthText = _textFactory.Create($"{lives} {string.Concat(Enumerable.Repeat("❤", lives))}", ConstantsUtil.HealthPosition, ConstantsUtil.HealthExtent, Color.Red);
        _scoreText = _textFactory.Create($"Score: {PlayerEntity.GetPoints()}", ConstantsUtil.ScorePosition, ConstantsUtil.ScoreExtent, Color.White);
        _levelText = _textFactory.Create($"Level: {state.GetLevel()}", ConstantsUtil.LevelPosition, ConstantsUtil.LevelExtent, Color.White);
    }
    
    public void AddBallEntity(BallEntity ballEntity)
    {
        BallEntities.AddEntity(ballEntity);
    }
    
    public void AddBlockEntity(BlockEntity blockEntity)
    {
        BlockEntities.AddEntity(blockEntity);
    }
    
}