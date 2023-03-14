using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System;
using DIKUArcade.Events;
using System.Collections.Generic;
namespace Galaga
{
    public class Game : DIKUGame, IGameEventProcessor
    {
        private readonly GameEventBus _eventBus;
        private Player _player;
        private readonly Score _score = new Score();
        private const int ExplosionLengthMs = 500;
        private const int NumEnemies = 8;

        /* Images */
        private List<Image> _explosionStrides;
        private List<Image> _enemyStridesRed;
        private List<Image> _enemyStridesBlue;
        private IBaseImage _playerShotImage;
        
        /* Containers */
        private EntityContainer<Enemy> _enemies;
        private EntityContainer<PlayerShot> _playerShots;
            
        private AnimationContainer _enemyExplosions;
        private Text _scoreText; 

        public Game(WindowArgs windowArgs) : base(windowArgs)
        {
            _eventBus = new GameEventBus();
            _eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent, GameEventType.PlayerEvent, GameEventType.GameStateEvent, GameEventType.WindowEvent });
            window.SetKeyEventHandler(KeyHandler);
            _eventBus.Subscribe(GameEventType.InputEvent, this);
            SpawnEnemies();
            SetupPlayer();
            SetupPlayerShots();
            SetupExplosion();
            SetupScoreText();
        }

        private void SetupScoreText(){
            _scoreText = new Text("Score: 0", new Vec2F(0.4f, 0.5f), new Vec2F(0.4f, 0.25f));
            _scoreText.SetColor(new Vec3F(1, 1, 1));
        }

        private void SetupExplosion(){
           _enemyExplosions = new AnimationContainer(NumEnemies);
           _explosionStrides = ImageStride.CreateStrides(8, Path.Combine("Assets", "Images", "Explosion.png"));
        }
        private void SetupPlayer(){
            _player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png"))
            );
        }
        private void SetupPlayerShots(){
            _playerShots = new EntityContainer<PlayerShot>();
            _playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
        }

        private void SpawnEnemies(){
            _enemyStridesBlue = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            _enemyStridesRed = ImageStride.CreateStrides(2, Path.Combine("Assets", "Images", "RedMonster.png"));
            _enemies = new EntityContainer<Enemy>(NumEnemies);
            for (int i = 0; i < NumEnemies; i++) {
                _enemies.AddEntity(
                    new Enemy(
                        new DynamicShape(new Vec2F(0.1f + (float)i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                        new ImageStride(80, _enemyStridesBlue)
                    )
                );
            }
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
                        shot.DeleteEntity();
                        
                        var damageEvent = new GameEvent
                        {
                            EventType = GameEventType.GameStateEvent,
                            From = this,
                            To = enemy,
                        };
                        _eventBus.RegisterEvent(damageEvent);
                        //enemy.DeleteEntity();
                        //AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                    });
                }
            });
        }


        private void KeyPress(KeyboardKey key)
        {
            switch (key)
            {
               case KeyboardKey.Escape:
                    var close = new GameEvent {
                        To = this,
                        EventType = GameEventType.WindowEvent
                    };
                    _eventBus.RegisterEvent(close);
                    break;
                case KeyboardKey.R:
                    SpawnEnemies();
                    break;
                case KeyboardKey.Space:
                    var pos = _player.GetPosition();
                    _playerShots.AddEntity(
                        new PlayerShot(new Vec2F(pos.X + _player.GetExtent().X / 2, pos.Y + _player.GetExtent().Y / 2), new Image(Path.Combine("Assets", "Images", "BulletRed2.png")))
                    );
                    break;
                case KeyboardKey.W:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Forward),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.A:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Left),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.S:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Backward),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.D:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Right),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
            }
            // TODO: Close window if escape is pressed
            // TODO: switch on key string and set the player's move direction
        }
        private void KeyRelease(KeyboardKey key)
        {
            switch (key)
            {
                case KeyboardKey.W:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Forward),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;
                case KeyboardKey.A:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Left),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;
                case KeyboardKey.S:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Backward),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;
                case KeyboardKey.D:
                    _eventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Right),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;

            }
        }
        private void KeyHandler(KeyboardAction action, KeyboardKey key)
        {
            switch(action){
                case KeyboardAction.KeyPress:
                    KeyPress(key);
                    break;
                case KeyboardAction.KeyRelease:
                    KeyRelease(key);
                    break;
            }            
        }
        public void ProcessEvent(GameEvent gameEvent)
        {
            if (gameEvent.EventType == GameEventType.WindowEvent){
                window.CloseWindow();
            }
        }

        public override void Render()
        {
            _player.Render();
            _enemies.RenderEntities();
            _playerShots.RenderEntities();
            _enemyExplosions.RenderAnimations();
            _scoreText.RenderText();
        }

        public override void Update()
        {
            window.PollEvents();
            _eventBus.ProcessEventsSequentially();
            _player.Move();
            IterateShots();
            _scoreText.SetText($"Score: {_score.GetScore()}");
        }


    }
}
