using System;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Events;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Galaga.entities;
using Galaga.MovementStrategy;
using Galaga.Squadron;

namespace Galaga
{
    public class Game : DIKUGame, IGameEventProcessor
    {
        private bool _isGameOver;
        private const int ExplosionLengthMs = 500;
        private const int NumEnemies = 8;
        public GameEventBus EventBus { get; private set; }
        public Player Player { get; private set; }

        private readonly KeyboardIntermediaryHandler _keyboardIntermediaryHandler;
        
        // Display UI
        private Level _level;
        private Score _score;
        private GameOver _gameOver;
        private Health _health;

        // Images
        private List<Image> _explosionStrides;
        private List<Image> _enemyStridesRed;
        private List<Image> _enemyStridesBlue;
        public IBaseImage PlayerShotImage { get; private set; }

        // Containers
        private EntityContainer<Enemy> _enemies;
        public EntityContainer<PlayerShot> PlayerShots;
        private AnimationContainer _enemyExplosions;
        private readonly List<ISquadron> _squadrons = new();

        private readonly Random _random = new();
        
        public Game(WindowArgs windowArgs) : base(windowArgs)
        {
            _keyboardIntermediaryHandler = new KeyboardIntermediaryHandler(this);
            SetupEventBus();
            SetupStrides();
            InitEnemies();
            SetupPlayer();
            SetupPlayerShots();
            SetupExplosion();
            SetupUiDisplay();
        }
        private void SetupEventBus()
        {
            EventBus = new GameEventBus();
            EventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent, GameEventType.PlayerEvent, GameEventType.WindowEvent });
            window.SetKeyEventHandler(_keyboardIntermediaryHandler.KeyHandler);
            EventBus.Subscribe(GameEventType.InputEvent, this);
        }
        
        private void SetupStrides()
        {
            _enemyStridesBlue = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            _enemyStridesRed = ImageStride.CreateStrides(2, Path.Combine("Assets", "Images", "RedMonster.png"));
        }


        private void SetupUiDisplay()
        {
            _score = new Score(new Vec2F(0.75f, -0.22f), new Vec2F(0.3f, 0.3f));
            _level = new Level(new Vec2F(0.75f, -0.17f), new Vec2F(0.3f, 0.3f));
            _health = new Health(new Vec2F(0.03f, -0.22f), new Vec2F(0.3f, 0.3f));
            _gameOver = new GameOver(new Vec2F(0.23f, 0.05f), new Vec2F(0.7f, 0.7f));
        }

        private void SetupExplosion(){
           _enemyExplosions = new AnimationContainer(NumEnemies);
           _explosionStrides = ImageStride.CreateStrides(8, Path.Combine("Assets", "Images", "Explosion.png"));
        }
        
        private void SetupPlayer(){
            Player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png"))
            );
        }
        private void SetupPlayerShots(){
            PlayerShots = new EntityContainer<PlayerShot>();
            PlayerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
        }
        
        private void InitEnemies(){
            _enemies = new EntityContainer<Enemy>(NumEnemies);
           
            var lineSquadron = new LineSquadron();
            var zigSquadron = new ZigSquadron();
            var circleSquadron = new CircleSquadron();
            
            _squadrons.AddRange(new List<ISquadron> {lineSquadron, zigSquadron, circleSquadron});
        }
        
        public void AddExplosion(Vec2F position, Vec2F extent) {
            _enemyExplosions.AddAnimation(
                new StationaryShape(position, extent), ExplosionLengthMs, new ImageStride(ExplosionLengthMs / 8, _explosionStrides)
            );
        }
        
        private void IterateShots() {
            PlayerShots.Iterate(shot => {
                shot.Shape.AsDynamicShape().Move();
                if (shot.Shape.Position.Y > 1) {
                    shot.DeleteEntity();
                } else {
                    _enemies.Iterate(enemy => {
                        var shotShape = shot.Shape.AsDynamicShape();
                        if (!DIKUArcade.Physics.CollisionDetection.Aabb(shotShape, enemy.Shape).Collision) return;
                        _score.IncrementScore();
            
                        EventBus.RegisterEvent(new GameEvent
                        {
                            EventType = GameEventType.PlayerEvent,
                            To = enemy,
                            From = this,
                        });
                        shot.DeleteEntity();
                    });
                }
            });
        }

        public void ProcessEvent(GameEvent gameEvent)
        {
            if (gameEvent.EventType == GameEventType.WindowEvent){
                window.CloseWindow();
            }
        }

        public override void Render()
        {
            Player.Render();
            _enemies.RenderEntities();
            PlayerShots.RenderEntities();
            _enemyExplosions.RenderAnimations();
            _score.RenderText();
            _level.RenderText();
            _health.RenderHealth();            
            if (_isGameOver) _gameOver.RenderText(_score.GetScore(), _level.GetScore());

        }

        public override void Update()
        {
            window.PollEvents();
            EventBus.ProcessEventsSequentially();
            if (_isGameOver) return;
            Player.Move();
            IterateShots();
            CheckGameState();
        }

        private void CheckGameState()
        {
            if (_health.GetHealth() <= 0)
            {
                GameOver();
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

        private void GameOver()
        {
            _isGameOver = true;
            _enemies.ClearContainer();
            Player.Entity.DeleteEntity();
            PlayerShots.ClearContainer();
        }
    }
}
