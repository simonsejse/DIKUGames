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
        private GameEventBus eventBus;
        private Player player;
        private Score score = new Score();
        private static int EXPLOSION_LENGTH_MS = 500;
        private static int numEnemies = 8;
        /* Images */
        private List<Image> explosionStrides;
        private IBaseImage playerShotImage;
        /* Containers */
        private EntityContainer<Enemy> enemies;
        private EntityContainer<PlayerShot> playerShots;
        private AnimationContainer enemyExplosions;
        private Text scoreText; 

        public Game(WindowArgs windowArgs) : base(windowArgs)
        {
            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent, GameEventType.WindowEvent });
            window.SetKeyEventHandler(KeyHandler);
            eventBus.Subscribe(GameEventType.InputEvent, this);
            SpawnEnemies();
            SetupPlayer();
            SetupPlayerShots();
            SetupExplosion();
            SetupScoreText();
        }

        private void SetupScoreText(){
            scoreText = new Text("Score: 0", new Vec2F(0.4f, 0.5f), new Vec2F(0.4f, 0.25f));
            scoreText.SetColor(new Vec3F(1, 1, 1));
        }

        private void SetupExplosion(){
           enemyExplosions = new AnimationContainer(numEnemies);
           explosionStrides = ImageStride.CreateStrides(8, Path.Combine("Assets", "Images", "Explosion.png"));
        }
        private void SetupPlayer(){
            player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png"))
            );
        }
        private void SetupPlayerShots(){
            playerShots = new EntityContainer<PlayerShot>();
            playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
        }

        private void SpawnEnemies(){
            List<Image> images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            enemies = new EntityContainer<Enemy>(numEnemies);
            for (int i = 0; i < numEnemies; i++) {
                enemies.AddEntity(
                    new Enemy(
                        new DynamicShape(new Vec2F(0.1f + (float)i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                        new ImageStride(80, images)
                    )
                ); 
            }
        }

        public void AddExplosion(Vec2F position, Vec2F extent) {
            enemyExplosions.AddAnimation(
                new StationaryShape(position, extent), EXPLOSION_LENGTH_MS, new ImageStride(EXPLOSION_LENGTH_MS / 8, explosionStrides)
            );
        }


        private void IterateShots() {
            playerShots.Iterate(shot => {
                shot.Shape.AsDynamicShape().Move();
                if (shot.Shape.Position.Y > 1) {
                    shot.DeleteEntity();
                } else {
                    enemies.Iterate(enemy => {
                        DynamicShape shotShape = shot.Shape.AsDynamicShape();
                        if (DIKUArcade.Physics.CollisionDetection.Aabb(shotShape, enemy.Shape).Collision){
                            AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                            score.IncrementScore();
                            enemy.DeleteEntity();
                            shot.DeleteEntity();
                        }
                    });
                }
            });
        }


        private void KeyPress(KeyboardKey key)
        {
            switch (key)
            {
               case KeyboardKey.Escape:
                    GameEvent close = new GameEvent {
                        To = this,
                        EventType = GameEventType.WindowEvent
                    };
                    eventBus.RegisterEvent(close);
                    break;
                case KeyboardKey.R:
                    SpawnEnemies();
                    break;
                case KeyboardKey.Space:
                    Vec2F pos = player.GetPosition();
                    playerShots.AddEntity(
                        new PlayerShot(new Vec2F(pos.X + player.GetExtent().X / 2, pos.Y + player.GetExtent().Y / 2), new Image(Path.Combine("Assets", "Images", "BulletRed2.png")))
                    );
                    break;
                case KeyboardKey.W:
                    player.SetMoveUp(true);
                    break;
                case KeyboardKey.A:
                    player.SetMoveLeft(true);
                    break;
                case KeyboardKey.S:
                    player.SetMoveDown(true);
                    break;
                case KeyboardKey.D:
                    player.SetMoveRight(true);
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
                    player.SetMoveUp(false);
                    break;
                case KeyboardKey.A:
                    player.SetMoveLeft(false);
                    break;
                case KeyboardKey.S:
                    player.SetMoveDown(false);
                    break;
                case KeyboardKey.D:
                    player.SetMoveRight(false);
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
            player.Render();
            enemies.RenderEntities();
            playerShots.RenderEntities();
            enemyExplosions.RenderAnimations();
            scoreText.RenderText();
        }

        public override void Update()
        {
            window.PollEvents();
            eventBus.ProcessEventsSequentially();
            player.Move();
            IterateShots();
            scoreText.SetText(String.Format("Score: {0}", score.GetScore()));
        }


    }
}
