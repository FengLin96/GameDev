using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife.Class
{
    class Beweging
    {
        public Vector2 VelocityX { get; set; }
        public Vector2 VelocityY { get; set; }
        
        public Vector2 Position { get; set; }
        public SpriteEffects Heroflip { get; set; }
        
        public Beweging(Vector2 velocityX,Vector2 velocityY,Vector2 position)
        {
            this.VelocityY = velocityY;
            this.VelocityX = velocityX;
            this.Position = position;
        }
       
       
        public virtual void WalkingLeft()
        {
            Heroflip = SpriteEffects.FlipHorizontally;
            Position += VelocityX;

        }
        public virtual void WalkingRight()
        {
            Position += VelocityX;
        }
        public virtual void Run()
        {
            Vector2 _velocityX = new Vector2(this.VelocityX.X * 2, this.VelocityX.Y);
            Position += _velocityX;
        }
        public virtual void Jump(Bediening currentJState,Vector2 position)      //idee: http://www.xnadevelopment.com/tutorials/thewizardjumping/thewizardjumping.shtml
        {
            Bediening previousJ = new Bediening();
            previousJ.Jump = currentJState.Jump;
            float maxJump = 50;
            float ground;
            float beginY = position.Y;
            float currentY = 0;
            //controleer of de key.j is gereleased is sinds vorige jump
            if (previousJ.Jump == false && currentJState.Jump) // als de vorige Key.J state = false en currentJ = true dan mag springen
            {
                //TODO:jump
                //Controleer of de personage al in de lucht is
                if(!(beginY < currentY)) // Als begin positie groter is dan currentY mag de personage springen.
                {

                }
            }
        }
        

    }
}
