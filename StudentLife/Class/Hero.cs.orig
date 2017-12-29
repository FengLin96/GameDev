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
        private Vector2 positie;

        public Vector2 Positie
        {
            get { return positie; }
            set { positie = value; }
        }

        private Texture2D Texture { get; set;}
<<<<<<< HEAD
        private Animation walk,stand,run,jump,damaged,animation;
=======
        private Rectangle showRect;
        private Animation animation,stappen,stand,run,jump,damaged;
        public Vector2 VelocityX = new Vector2(2,0);
>>>>>>> 5da7f96f0143b9caf6b9193d6a9f6ae12d814cac
        public Bediening Bediening { get; set; }
        private SpriteEffects heroFlip;
        private enum richting :int { naarLinks = -1, naarRechts = 1};
        private Movement beweging;
        public Hero(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;
            beweging = new Movement(this.positie, new Vector2(5, 30));
            heroFlip = beweging.Heroflip;
            #region frames stappen
            walk = new Animation();
            walk.AddFrame(new Rectangle(242, 20, 33, 51));
            walk.AddFrame(new Rectangle(287, 21, 25, 50));
            walk.AddFrame(new Rectangle(327, 20, 26, 50));
            walk.AddFrame(new Rectangle(369, 20, 24, 51));
            walk.AddFrame(new Rectangle(413, 19, 21, 52));
            walk.AddFrame(new Rectangle(451, 18, 23, 53));

<<<<<<< HEAD
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

            jump.AantalBewegingenPerSeconde = 1;
            #endregion
=======
            #region frames stappen
            stappen = new Animation();
            stappen.AddFrame(new Rectangle(242, 20, 33, 51));
            stappen.AddFrame(new Rectangle(287, 21, 25, 50));
            stappen.AddFrame(new Rectangle(327, 20, 26, 51));
            stappen.AddFrame(new Rectangle(368, 20, 25, 51));
            stappen.AddFrame(new Rectangle(412, 19, 22, 52));
            stappen.AddFrame(new Rectangle(450, 18, 43, 53));
            #endregion

            #region frames run
            run = new Animation();
           // run.AddFrame(new Rectangle )
            #endregion

            stappen.AantalBewegingenPerSeconde = 8;
        }
        
        
        private void Run(int richting)
        {
            if (richting<0)
            {
                Positie -= VelocityX;
                heroFlip = SpriteEffects.FlipHorizontally;
            }
            if (richting>0)
            {
                Positie += VelocityX;
                heroFlip = SpriteEffects.None;
            }
>>>>>>> 5da7f96f0143b9caf6b9193d6a9f6ae12d814cac

        }
        bool hasJumped = false;
        public void Update(GameTime gametime)
        {
            Bediening.Update();
            animation.Update(gametime);
            
            if (Bediening.isKeyNotDown)
            {
<<<<<<< HEAD
                animation = stand;
=======
                stappen.Update(gametime);
>>>>>>> 5da7f96f0143b9caf6b9193d6a9f6ae12d814cac
            }
            
            if (Bediening.Left)
            {
                animation = walk;
                this.positie = beweging.Walking((int)richting.naarLinks);
            }
            if (Bediening.Right)
            {
                animation = walk;
                this.positie = beweging.Walking((int)richting.naarRechts);
            }
            if (Bediening.Run && Bediening.Left)
            {
                animation = run;
                this.positie = beweging.Run((int)richting.naarLinks, 6f);
            }
            if (Bediening.Run && Bediening.Right)
            {
                animation = run;
                this.positie = beweging.Run((int)richting.naarRechts, 6f);
            }

            if (Bediening.Jump||hasJumped)
            {
                animation = jump;
                unsafe
                {
                   fixed( bool* y = &this.hasJumped)
                   this.positie = beweging.Jump(y, jump, jump);
                }
            }
            heroFlip = beweging.Heroflip;
        }
        public void Draw(SpriteBatch spritebatch)
        {
<<<<<<< HEAD
            Rectangle destinationRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, animation.CurrentFrame.SourceRectangle.Width, animation.CurrentFrame.SourceRectangle.Height);

            spritebatch.Draw(texture: Texture, destinationRectangle: destinationRectangle, sourceRectangle: animation.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: new Vector2(0, 0), effects: heroFlip, layerDepth: 0f);


=======
            
        Rectangle destinationRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, stappen.CurrentFrame.SourceRectangle.Width, stappen.CurrentFrame.SourceRectangle.Height);
        spritebatch.Draw(texture: Texture, destinationRectangle: destinationRectangle, sourceRectangle: stappen.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: new Vector2(0,0) , effects:heroFlip, layerDepth: 0f);
>>>>>>> 5da7f96f0143b9caf6b9193d6a9f6ae12d814cac
        }

       
    }
}
