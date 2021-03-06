﻿using Microsoft.Xna.Framework;

namespace YaSaog.Entities {

    public class SolidSpike : BaseEntity {

        public SolidSpike() : this(0, 0) { }

        public SolidSpike(int posX, int posY) {
            X = posX;
            Y = posY;

            Size = new Vector2(32, 32);
            CollisionType = "spike";
        }

        public override void Init() {                        
        }       

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Spikes, BoundingBox, Color.White);
        }

        public override void Delete() {            
        }
    }
}