using System;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Events;
using DIKUArcade.Input;
using System.Collections.Generic;
using DIKUArcade.Physics;

namespace Galaga;
public class Game : DIKUGame, IGameEventProcessor {
    private GameEventBus eventBus;
    private Player player;
    private EntityContainer<Enemy> enemies;
    private EntityContainer<PlayerShot> playerShots;
    private IBaseImage playerShotImage;
    private AnimationContainer enemyExplosions;
    private List<Image> explosionStrides;
    private const int EXPLOSION_LENGTH_MS = 500;    
    
    public Game(WindowArgs windowArgs) : base(windowArgs) {
        player = new Player(
            new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine("Assets", "Images", "Player.png")));
        // TODO: Set key event handler (inherited window field of DIKUGame class)

        eventBus = new GameEventBus();
        eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent, GameEventType.WindowEvent });
        window.SetKeyEventHandler(KeyHandler);
        eventBus.Subscribe(GameEventType.InputEvent, this);
        eventBus.Subscribe(GameEventType.WindowEvent, this);

        List<Image> images = ImageStride.CreateStrides
            (4, Path.Combine("Assets", "Images", "BlueMonster.png"));
        const int numEnemies = 8;
        enemies = new EntityContainer<Enemy>(numEnemies);
        for (int i = 0; i < numEnemies; i++) {
            enemies.AddEntity(new Enemy(
                new DynamicShape(new Vec2F(0.1f + (float)i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                new ImageStride(80, images)));
        }

        playerShots = new EntityContainer<PlayerShot>();
        playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
    
        enemyExplosions = new AnimationContainer(numEnemies);
        explosionStrides = ImageStride.CreateStrides(8,
            Path.Combine("Assets", "Images", "Explosion.png"));
    }

    // TODO: Outcomment

    public override void Render() {
        player.Render();
        enemies.RenderEntities();
        playerShots.RenderEntities();
        enemyExplosions.RenderAnimations();
    }

    public override void Update() {
        window.PollEvents();
        eventBus.ProcessEventsSequentially();
        player.Move();
        IterateShots();
    }

    private void KeyPress(KeyboardKey key) {
    // TODO: switch on key string and set the player's move direction
        if (key == KeyboardKey.Escape) {
            eventBus.RegisterEvent(new GameEvent{EventType=GameEventType.WindowEvent, From=this, Message="EXIT"});
        } else if (key == KeyboardKey.Left) {
            player.SetMoveLeft(true);
        } else if (key == KeyboardKey.Right) {
            player.SetMoveRight(true);
        } else if (key == KeyboardKey.Space) {
            playerShots.AddEntity(new PlayerShot(player.GetPosition(), playerShotImage));
        }
    }
    private void KeyRelease(KeyboardKey key) {
    // TODO: switch on key string and disable the player's move direction
        if (key ==  KeyboardKey.Left) {
            player.SetMoveLeft(false);
        } else if (key ==  KeyboardKey.Right) {
            player.SetMoveRight(false);
        }
    }
    private void KeyHandler(KeyboardAction action, KeyboardKey key) {
        // TODO: Switch on KeyBoardAction and call proper method
        if (action == KeyboardAction.KeyPress) {
            KeyPress(key);
        } else if (action == KeyboardAction.KeyRelease) {
            KeyRelease(key);
        }
    }
    public void ProcessEvent(GameEvent gameEvent) {
        // Leave this empty for now
        if (gameEvent.EventType == GameEventType.WindowEvent) {
            if (gameEvent.Message == "EXIT") {
                window.CloseWindow();
            }
        }
    }

    private void IterateShots() {
        playerShots.Iterate(shot => {
            // TODO: move the shot's shape
            shot.Shape.Move();
            if (shot.Shape.Position.Y <= 0.0f/* TODO: guard against window borders */ ) {
                // TODO: delete shot
                shot.DeleteEntity();
            } else {
                enemies.Iterate(enemy => {
                    // TODO: if collision btw shot and enemy -> delete both entities

                    if (CollisionDetection.Aabb(shot.Shape.AsDynamicShape(), enemy.Shape).Collision) {
                        AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                        enemy.DeleteEntity();
                        shot.DeleteEntity();
                    }
                });
            }
        });
    }


    public void AddExplosion(Vec2F position, Vec2F extent) {
        // TODO: add explosion to the AnimationContainer
        enemyExplosions.AddAnimation(new StationaryShape (position, extent), EXPLOSION_LENGTH_MS, new ImageStride (EXPLOSION_LENGTH_MS/8, explosionStrides));
    }
}
