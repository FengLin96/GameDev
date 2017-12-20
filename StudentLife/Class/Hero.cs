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
        private Rectangle showRect;
        private Animation walk,stand,run,jump,damaged,animation;
        public Vector2 VelocityX = new Vector2(2,0);
        public Bediening Bediening { get; set; }
        private SpriteEffects heroFlip = SpriteEffects.FlipHorizontally;

        public Hero(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;
            showRect = new Rectangle(0, 0, 43, 58);

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
            run.AddFrame(new Rectangle(117,106,59,54));
            run.AddFrame(new Rectangle(187,107,65,54));
            run.AddFrame(new Rectangle(264,108,68,54));
            run.AddFrame(new Rectangle(341,108,74,52));
            run.AddFrame(new Rectangle(423, 109, 82, 52));
            run.AddFrame(new Rectangle(513, 111, 85, 51));
            run.AddFrame(new Rectangle(11, 172, 96, 55));
            run.AddFrame(new Rectangle(122, 173, 103, 54));
            run.AddFrame(new Rectangle(240, 174, 105, 53));

            #endregion



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

        }
            
        public void Update(GameTime gametime)
        {
            Bediening.Update();
            if(Bediening.Left || Bediening.Right)
            {
                //animation.Update(gametime);
                run.Update(gametime);
            }
            if (Bediening.Left)
            {
                Run(-1);
            }
            if (Bediening.Right)
            {
                Run(1);
            }
   
        }

        public void Draw(SpriteBatch spritebatch)
        {
       // Rectangle destinationRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, animation.CurrentFrame.SourceRectangle.Width, animation.CurrentFrame.SourceRectangle.Height);
            Rectangle destinationRectangle2 = new Rectangle((int)Positie.X, (int)Positie.Y, run.CurrentFrame.SourceRectangle.Width, run.CurrentFrame.SourceRectangle.Height);
            
            spritebatch.Draw(texture: Texture, destinationRectangle: destinationRectangle2, sourceRectangle: run.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: new Vector2(0,0) , effects:heroFlip, layerDepth: 0f);
        
        }

    }
}
