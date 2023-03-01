using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System;
using DIKUArcade.Events;
using DIKUArcade.Input;
using System.Collections.Generic;
namespace Galaga
{
    public class Game : DIKUGame, IGameEventProcessor
    {
        private GameEventBus eventBus;
        private Player _player;
        private const int EXPLOSION_LENGTH_MS = 500;
        private static int numEnemies = 8;
        /* Images */
        private List<Image> explosionStrides;
        private IBaseImage playerShotImage;
        /* Containers */
        private EntityContainer<Enemy> enemies;
        private EntityContainer<PlayerShot> playerShots;
        private AnimationContainer enemyExplosions;

        public Game(WindowArgs windowArgs) : base(windowArgs)
        {
            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });
            window.SetKeyEventHandler(KeyHandler);
            eventBus.Subscribe(GameEventType.InputEvent, this);
            SpawnEnemies();
            SetupPlayer();
            SetupPlayerShots();
            SetupExplosion();
        }

        private void SetupExplosion(){
           enemyExplosions = new AnimationContainer(numEnemies);
           explosionStrides = ImageStride.CreateStrides(8, Path.Combine("Assets", "Images", "Explosion.png"));
        }
        private void SetupPlayer(){
            _player = new Player(
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
            // TODO: add explosion to the AnimationContainer
            enemyExplosions.AddAnimation(
                new StationaryShape(position, extent), EXPLOSION_LENGTH_MS, new ImageStride(EXPLOSION_LENGTH_MS / 8, explosionStrides)
            );
        }


        private void IterateShots() {
            playerShots.Iterate(shot => {
                // TODO: move the shot's shape
                shot.Shape.AsDynamicShape().Move();
                /* TODO: guard against window borders */ 
                if (shot.Shape.Position.Y > 1) {
                // TODO: delete shot
                    shot.DeleteEntity();
                } else {
                    enemies.Iterate(enemy => {
                        // TODO: if collision btw shot and enemy -> delete both entities
                        DynamicShape shotShape = shot.Shape.AsDynamicShape();
                        if (DIKUArcade.Physics.CollisionDetection.Aabb(shotShape, enemy.Shape).Collision){
                            AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
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
                    this.window.CloseWindow();
                    break;
                case KeyboardKey.Space:
                    playerShots.AddEntity(
                        new PlayerShot(_player.GetPosition(), new Image(Path.Combine("Assets", "Images", "BulletRed2.png")))
                    );
                    break;
                case KeyboardKey.A:
                    _player.SetMoveLeft(true);
                    break;
                case KeyboardKey.D:
                    _player.SetMoveRight(true);
                    break;
            }
            // TODO: Close window if escape is pressed
            // TODO: switch on key string and set the player's move direction
        }
        private void KeyRelease(KeyboardKey key)
        {
            switch (key)
            {
                case KeyboardKey.A:
                    _player.SetMoveLeft(false);
                    break;
                case KeyboardKey.D:
                    _player.SetMoveRight(false);
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
            // Leave this empty for now
        }

        public override void Render()
        {
            _player.Render();
            enemies.RenderEntities();
            playerShots.RenderEntities();
            enemyExplosions.RenderAnimations();

        }

        public override void Update()
        {
            window.PollEvents();
            eventBus.ProcessEventsSequentially();
            _player.Move();
            IterateShots();
        }


    }
}
