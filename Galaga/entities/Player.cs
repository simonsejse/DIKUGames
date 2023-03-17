using System;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga.entities
{
    public class Player : IGameEventProcessor
    {
        public Entity Entity { get; }
        private DynamicShape _shape;
        private float _moveUp = 0.0f;
        private float _moveDown = 0.0f;
        private float _moveLeft = 0.0f;
        private float _moveRight = 0.0f;
        private float _movementSpeed = 0.01f;

        public Player(DynamicShape shape, IBaseImage image)
        {
            Entity = new Entity(shape, image);
            _shape = shape;
        }
        public Vec2F GetPosition(){
            return _shape.Position;
        }
        public Vec2F GetExtent(){
            return _shape.Extent;
        }
        public void Render()
        {
            Entity.RenderEntity();
        }
        private void UpdateDirection()
        {
            float x = _moveLeft + _moveRight;
            float y = _moveUp + _moveDown;
            _shape.Direction = new Vec2F(x, y);
        }

        public void Move()
        {
            // TODO: move the shape and guard against the window borders
            if (_shape.Position.X < 0){
                SetMoveLeft(false);
            }
            if (_shape.Position.X > 0.9){
                SetMoveRight(false);
            }
            if (_shape.Position.Y > 0.6){
                SetMoveUp(false); 
            } 
            if (_shape.Position.Y < 0){
                SetMoveDown(false); 
            }
            _shape.Move();
        }

        private void SetMoveUp(bool val)
        {
            _moveUp = val ? _moveUp + _movementSpeed : 0f;
            UpdateDirection();
        }

        private void SetMoveDown(bool val)
        {
            _moveDown = val ? _moveDown - _movementSpeed : 0f;
            UpdateDirection();
        }

        private void SetMoveLeft(bool val)
        {
            _moveLeft = val ? _moveLeft - _movementSpeed : 0f;
            UpdateDirection();
        }

        private void SetMoveRight(bool val)
        {
            _moveRight = val ? _moveRight + _movementSpeed : 0f;
            UpdateDirection();
        }

        public void ProcessEvent(GameEvent gameEvent)
        {
            if (gameEvent.EventType == GameEventType.PlayerEvent)
            {
                switch (gameEvent.Message)
                {
                    case nameof(MovementDirection.Forward):
                        SetMoveUp(gameEvent.IntArg1 == 1);
                        break;
                    case nameof(MovementDirection.Backward):
                        SetMoveDown(gameEvent.IntArg1 == 1);
                        break;  
                    case nameof(MovementDirection.Left):
                        SetMoveLeft(gameEvent.IntArg1 == 1);
                        break;
                    case nameof(MovementDirection.Right):
                        SetMoveRight(gameEvent.IntArg1 == 1);
                        break;
                    default:
                        Console.WriteLine("Hvad fanden sker der?");
                        break;
                }
            }
            Console.WriteLine("I am called!");
        }
    }
}