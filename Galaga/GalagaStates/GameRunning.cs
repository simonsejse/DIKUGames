using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;
using Galaga.entities;
using Galaga.Squadron;

namespace Galaga.GalagaStates;

public class GameRunning : IGameState
{
    private const int ExplosionLengthMs = 500;
    private const int NumEnemies = 8;

    private IKeyboardIntermediaryHandler _keyboardIntermediaryHandler;
    private Player _player;

    // Display UI
    private Level _level;
    private Score _score;
    private Health _health;

    // Images
    private List<Image> _explosionStrides;
    private List<Image> _enemyStridesRed;
    private List<Image> _enemyStridesBlue;
    private IBaseImage _playerShotImage;

    // Containers
    private EntityContainer<PlayerShot> _playerShots;
    private EntityContainer<Enemy> _enemies;
    private AnimationContainer _enemyExplosions;
    private readonly List<ISquadron> _squadrons = new();

    private readonly Random _random = new();

    private static GameRunning _gameRunning;

    public static GameRunning GetInstance()
    {
        GameRunning CreateGameRunning()
        {
            var gameState = new GameRunning();
            gameState.InitializeGameState();
            gameState._keyboardIntermediaryHandler = new RunningStateKeyboardAction(
                gameState._player, 
                gameState._playerShots, 
                gameState._playerShotImage
            );
            return gameState;
        }
        return _gameRunning ??= CreateGameRunning();
    }
    
    private void InitializeGameState()
    {
        _enemyStridesBlue = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
        _enemyStridesRed = ImageStride.CreateStrides(2, Path.Combine("Assets", "Images", "RedMonster.png"));
        
        _enemies = new EntityContainer<Enemy>(NumEnemies);
       
        var lineSquadron = new LineSquadron();
        var zigSquadron = new ZigSquadron();
        var circleSquadron = new CircleSquadron();
        
        _squadrons.AddRange(new List<ISquadron> {lineSquadron, zigSquadron, circleSquadron});
        
        _player = new Player(
            new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine("Assets", "Images", "Player.png"))
        );
        
        _playerShots = new EntityContainer<PlayerShot>();
        _playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
        
        _enemyExplosions = new AnimationContainer(NumEnemies);
        _explosionStrides = ImageStride.CreateStrides(8, Path.Combine("Assets", "Images", "Explosion.png"));
        
        _score = new Score(new Vec2F(0.75f, -0.22f), new Vec2F(0.3f, 0.3f));
        _level = new Level(new Vec2F(0.75f, -0.17f), new Vec2F(0.3f, 0.3f));
        _health = new Health(new Vec2F(0.03f, -0.22f), new Vec2F(0.3f, 0.3f));
    }

    public void AddExplosion(Vec2F position, Vec2F extent) {
        _enemyExplosions.AddAnimation(
            new StationaryShape(position, extent), ExplosionLengthMs, new ImageStride(ExplosionLengthMs / 8, _explosionStrides)
        );
    }

    private void IterateShots() {
        _playerShots.Iterate(shot => {
            shot.Shape.AsDynamicShape().Move();
            if (shot.Shape.Position.Y > 1) {
                shot.DeleteEntity();
            } else {
                _enemies.Iterate(enemy => {
                    var shotShape = shot.Shape.AsDynamicShape();
                    if (!DIKUArcade.Physics.CollisionDetection.Aabb(shotShape, enemy.Shape).Collision) return;
                    _score.IncrementScore();
        
                    enemy.Hitpoints--;
                    switch (enemy.Hitpoints)
                    {
                        case < 3 and > 0:
                            enemy.Image = enemy.AlternativeEnemyStride;
                            enemy.Speed += 0.003f;
                            break;
                        case <= 0:
                            AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                            enemy.DeleteEntity();
                            break;
                    }
                    shot.DeleteEntity();
                });
            }
        });
    }
        
    
    public void ResetState()
    {
        InitializeGameState();
    }

    public void UpdateState()
    {
        _player.Move();
        IterateShots();
        CheckGameState();
    }

    public void RenderState()
    {
        _player.Render();
        _enemies.RenderEntities();
        _playerShots.RenderEntities();
        _enemyExplosions.RenderAnimations();
        _score.RenderText();
        _level.RenderText();
        _health.RenderHealth();            
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        switch (action)
        {
            case KeyboardAction.KeyPress:
                _keyboardIntermediaryHandler.KeyPress(key);
                break;
            case KeyboardAction.KeyRelease:
                _keyboardIntermediaryHandler.KeyRelease(key);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, "The action provided was out of bounds.");
        }
    }
    
    private void CheckGameState()
    {
        if (_health.GetHealth() <= 0)
        {
            GalagaBus.GetBus().RegisterEvent(
                new GameEvent<GameEventType>
                {
                    EventType = GameEventType.GameStateEvent,
                    Message = "CHANGE_STATE",
                    StringArg1 = Enum.GetName(GameStateType.GameLost)
                }
            );
            return;
        }

        if (_enemies.CountEntities() == 0)
        {
            var squadron = _squadrons[_random.Next(_squadrons.Count)];
            squadron.CreateEnemies(_enemyStridesBlue, _enemyStridesRed);

            void EnemyTasks(Enemy e)
            {
                e.Speed += (_level.GetScore() + 1) * 0.0002f;
                _enemies.AddEntity(e);
            }

            squadron.Enemies.Iterate(EnemyTasks);
            _level.IncrementLevel();
        }
        else
        {
            _enemies.Iterate(enemy =>
            {
                enemy.Move();
                if (enemy.Shape.Position.Y > 0) return;
                _health.LoseHealth();
                enemy.DeleteEntity();
            });
        }
    }
}

