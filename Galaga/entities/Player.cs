using System;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Galaga
{
    public class Player
    {
        private Entity _entity;
        private DynamicShape _shape;
        private float _moveLeft = 0.0f;
        private float _moveRight = 0.0f;
        private float _movementSpeed = 0.01f;

        public Player(DynamicShape shape, IBaseImage image)
        {
            this._entity = new Entity(shape, image);
            this._shape = shape;
        }

        public void Render()
        {
            this._entity.RenderEntity();
        }
        private void UpdateDirection()
        {
            float x = _moveLeft + _moveRight;
            Console.WriteLine("Update " + x);
            _shape.Direction = new DIKUArcade.Math.Vec2F(x, 0);
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
            this._shape.Move();
        }
        public void SetMoveLeft(bool val)
        {
            _moveLeft = val ? _moveLeft - _movementSpeed : 0f;
            UpdateDirection();
        }

        public void SetMoveRight(bool val)
        {
            _moveRight = val ? _moveRight + _movementSpeed : 0f;
            UpdateDirection();
        }
        public Vec2F GetPosition(){
            return _shape.Position;
        }
    }
}