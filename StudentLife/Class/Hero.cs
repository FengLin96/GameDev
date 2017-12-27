using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLife.Class;

namespace StudentLife.Class
{
    class Hero
    {
        public Vector2 Positie { get; set; }
        private Texture2D Texture { get; set;}
        private Animation walk,stand,run,jump,damaged,animation;
        public Vector2 VelocityX = new Vector2(2,0);
        public Vector2 VelocityY = new Vector2(0, 90);
        public Bediening Bediening { get; set; }
        private SpriteEffects heroFlip = SpriteEffects.None;

        private enum richting :int { naarLinks = -1, naarRechts = 1};
        public Hero(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;

            #region frames stappen
            walk = new Animation();
            walk.AddFrame(new Rectangle(242, 20, 33, 51));
            walk.AddFrame(new Rectangle(287, 21, 25, 50));
            walk.AddFrame(new Rectangle(327, 20, 26, 50));
            walk.AddFrame(new Rectangle(369, 20, 24, 51));
            walk.AddFrame(new Rectangle(413, 19, 21, 52));
            walk.AddFrame(new Rectangle(451, 18, 23, 53));

            #endregion

            #region frames run
            run = new Animation();
            run.AddFrame(new Rectangle(6, 105, 46, 47));
            run.AddFrame(new Rectangle(63, 106, 46, 46));
            run.AddFrame(new Rectangle(117, 106, 59, 54));
            run.AddFrame(new Rectangle(187, 107, 65, 54));
            run.AddFrame(new Rectangle(264, 108, 68, 54));
            run.AddFrame(new Rectangle(341, 108, 74, 52));
           // run.AddFrame(new Rectangle(423, 109, 82, 52));
          //run.AddFrame(new Rectangle(513, 111, 85, 51));
            //run.AddFrame(new Rectangle(11, 172, 96, 55));
            //run.AddFrame(new Rectangle(122, 173, 103, 54));
            //run.AddFrame(new Rectangle(240, 174, 105, 53));


            #endregion

            #region frames stand
            stand = new Animation();
            stand.AddFrame(new Rectangle(17,20,36,51));
            stand.AddFrame(new Rectangle(65,21,36,50));
            stand.AddFrame(new Rectangle(114,23,35,48));
            stand.AddFrame(new Rectangle(164,26,36,46));
            stand.AantalBewegingenPerSeconde = 1;
            #endregion
            animation = stand ;

            #region frames jump
            jump = new Animation();
            jump.AddFrame(new Rectangle(8, 309, 44, 50));
            jump.AddFrame(new Rectangle(64, 311, 44, 50));
            jump.AddFrame(new Rectangle(120, 307, 31, 54));
            jump.AddFrame(new Rectangle(174, 307, 85, 54));
            jump.AddFrame(new Rectangle(228, 321, 54, 40));
            jump.AddFrame(new Rectangle(295, 324, 62, 37));
            jump.AddFrame(new Rectangle(368, 327, 62, 35));
            jump.AddFrame(new Rectangle(441, 309, 62, 54));
            jump.AddFrame(new Rectangle(514, 309, 75, 54));
            jump.AddFrame(new Rectangle(597, 310, 72, 50));

            #endregion

        }
            
        public void Update(GameTime gametime)
        {
            Bediening.Update();
            animation.Update(gametime);
            
            if (Bediening.isKeyNotDown)
            {
                animation = stand;
            }
            
            if (Bediening.Left)
            {
                Walking((int)richting.naarLinks);
            }
            if (Bediening.Right)
            {
                Walking((int)richting.naarRechts);
            }
            if(Bediening.Run && Bediening.Left)
            {
                Run((int)richting.naarLinks,4f);
            }
            if (Bediening.Run && Bediening.Right)
            {
                Run((int)richting.naarRechts, 4f);
            }
            if (Bediening.Jump)
            {
                Jump();
            }
            
        }
       
        

       
        private void Walking( int richting)
        {
            animation = walk;
            if (richting > 0)
            {
                this.Positie += VelocityX;
                heroFlip = SpriteEffects.None;
            }
            else if (richting < 0)
            {
                this.Positie -= VelocityX;
                heroFlip = SpriteEffects.FlipHorizontally;
            }
        }

        private void Run(int richting, float runVelocity)
        {
            Vector2 velocity = new Vector2(runVelocity, 0);
            animation = run;
            if (richting > 0)
            {
                this.Positie += velocity;
                heroFlip = SpriteEffects.None;
            }
            else if(richting < 0)
            {
                this.Positie -= velocity;
                heroFlip = SpriteEffects.FlipHorizontally;
            }
        }

        public void Jump()  //idee: http://www.xnadevelopment.com/tutorials/thewizardjumping/thewizardjumping.shtml
        {
            animation = jump;

            float maxJumpHeight = 90;
            bool isGround;
            float beginY = this.Positie.Y;
            float currentY = 0;
            bool hasJumped = false;
            float gravity = 9.81f;

            //controleer of de jump al gereleased is sinds vorige jump
            if (hasJumped == false && Bediening.Jump) // als de vorige Key.J state = false en currentJ = true dan mag springen
            {
                //Controleer of de personage al in de lucht is
                if (!(beginY < currentY)) // Als begin positie groter is dan currentY mag de personage springen.
                {
                    // jump
                    this.Positie -= VelocityY;
                    hasJumped = true;
                }
            }

            if (beginY - currentY > maxJumpHeight) // als de maxJumpHeight heeft bereikt dan val die naar beneden.
            {
                // going down
                this.Positie += new Vector2(0, gravity);
                
            }

            if (currentY > beginY)  // als currentY groter is dan beginY dan stop met vallen.
            {
                hasJumped = false;
            }
        }

        public void Damage()
        {
            throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            Console.WriteLine("Position X = " + Positie.X + " Position Y = " + Positie.Y);
            Rectangle destinationRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, animation.CurrentFrame.SourceRectangle.Width, animation.CurrentFrame.SourceRectangle.Height);

            spritebatch.Draw(texture: Texture, destinationRectangle: destinationRectangle, sourceRectangle: animation.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: new Vector2(0, 0), effects: heroFlip, layerDepth: 0f);


        }

       
    }
}
