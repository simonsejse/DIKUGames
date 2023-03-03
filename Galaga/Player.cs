using System;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga {
    public class Player {
        // TODO: Add private fields
        private float moveLeft = 0.0f;
        private float moveRight = 0.0f;
        const float MOVEMENT_SPEED = 0.01f;
        private Entity entity;
        private DynamicShape shape;
        public Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }
        public void Render() {
            entity.RenderEntity();
        }

        public void Move() {
        // TODO: move the shape and guard against the window borders
            if (shape.Position.X <= 0.0f) {
                SetMoveLeft(false);
            } else if (shape.Position.X >= 0.9f) {
                SetMoveRight(false);
            }
            shape.Move();
        }
        public void SetMoveLeft(bool val) {
            // TODO:set moveLeft appropriately and call UpdateDirection()
            if (val == true) {
                Console.WriteLine("MoveLeft: " + moveLeft);
                moveLeft -= MOVEMENT_SPEED;
            } else {
                moveLeft = 0;
            }
            UpdateDirection();
        }
        public void SetMoveRight(bool val) {
            // TODO:set moveRight appropriately and call UpdateDirection()
            if (val == true) {
                Console.WriteLine("MoveRight: " + moveRight);
                moveRight += MOVEMENT_SPEED;
            }else {
                moveRight = 0;
            }
            UpdateDirection();
        }

        private void UpdateDirection() {
            shape.Direction.X = moveLeft+moveRight;
        }

        public Vec2F GetPosition () {
            return shape.Position;
        }
    } 
}