using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StudentLife.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife
{
    class Movement
    {
        private Vector2 positie;
        public Vector2 Positie
        {
            get { return positie; }
            set { positie = value; }
        }

        private SpriteEffects heroFlip;
        public SpriteEffects Heroflip
        {
            get { return heroFlip; }
            set { heroFlip = value; }
        }
        public Animation jumpAnimation { get; set; }

        private float walkVelocity;

        private float gravity = 9.81f;
        private float jumpVelocity;
        private float beginPostitie;
        private int jumpHeight;

        private bool hasJumped;


        public Movement(Vector2 positie, Vector2 velocity)
        {
            this.positie = positie;
            heroFlip = SpriteEffects.None;
            this.jumpVelocity = velocity.Y;
            this.walkVelocity = velocity.X;
            jumpHeight = 90;
        }

        public Vector2 Walking(int richting)
        {
            if (richting > 0)
            {
                this.positie.X += walkVelocity;
                heroFlip = SpriteEffects.None;
            }
            else if (richting < 0)
            {
                this.positie.X -= walkVelocity;
                heroFlip = SpriteEffects.FlipHorizontally;
            }

            return this.positie;
        }

        public Vector2 Run(int richting, float runVelocity)
        {

            if (richting > 0)
            {
                this.positie.X += runVelocity;
                heroFlip = SpriteEffects.None;
            }
            else if (richting < 0)
            {
                this.positie.X -= runVelocity;
                heroFlip = SpriteEffects.FlipHorizontally;
            }
            return this.positie;
        }

        float defautVelocity = 0f; //backup van jumpVelocity, zorgt ervoor na elke jump terug op staandaard waard komen
        unsafe
        public Vector2 Jump(bool* jumpStatus, Animation jump, Animation land)
        {
            
            
                bool* x = jumpStatus;

                if (!*x)                        //voor elke jump eerste beginPositie opslaan, na jump komt de personage terug op zelfde x waarde, na volledig jump actie wordt die terug op false
                {
                    beginPostitie = this.positie.Y;
                    defautVelocity = jumpVelocity;
                }

                //controleer of de jump actie al gedaan is sinds vorige jump
                if (!this.hasJumped)        // als nog niet gesprongen
                {
                    *x = true; //Dit regel code zorgt voor dat de jump actie volledig kunnen afronden.
                    float top = beginPostitie - jumpHeight;

                    //Jump
                    this.positie.Y -= jumpVelocity;
                    jumpVelocity -= 2;
                    if (this.positie.Y < top) hasJumped = true; // als de top punt heeft bereikt

                }

                //Controleer of de persoange al in de lucht is
                if (hasJumped)
                {
                    //naar beneden vallen, als de personage het toppunt heeft bereikt
                    this.positie.Y += gravity;

                    //Controleer of de personage het beginpunt heeft bereikt
                    if (this.positie.Y > beginPostitie)
                    {
                        positie.Y = beginPostitie;
                        *x = false;
                        jumpVelocity = defautVelocity;
                        this.hasJumped = false;
                    }
                }
               
            
            
            return this.positie;
        } //idee: http://www.xnadevelopment.com/tutorials/thewizardjumping/thewizardjumping.shtml


    }


    
}
