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
        private Animation animation,stappen,stand,run,jump,damaged;
        public Vector2 VelocityX = new Vector2(2,0);
        public Bediening Bediening { get; set; }
        private SpriteEffects heroFlip = SpriteEffects.FlipHorizontally;

        public Hero(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;
            showRect = new Rectangle(0, 0, 43, 58);

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

        }
            
        public void Update(GameTime gametime)
        {
            Bediening.Update();
            if(Bediening.Left || Bediening.Right)
            {
                stappen.Update(gametime);
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
            
        Rectangle destinationRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, stappen.CurrentFrame.SourceRectangle.Width, stappen.CurrentFrame.SourceRectangle.Height);
        spritebatch.Draw(texture: Texture, destinationRectangle: destinationRectangle, sourceRectangle: stappen.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: new Vector2(0,0) , effects:heroFlip, layerDepth: 0f);
        }

    }
}
