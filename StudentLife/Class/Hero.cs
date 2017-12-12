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
        private Animation animation;
        public Vector2 VelocityX = new Vector2(2,0);
        public Bediening Bediening { get; set; }
        private SpriteEffects heroFlip = SpriteEffects.FlipHorizontally;

        public Hero(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;
            showRect = new Rectangle(0, 0, 43, 58);
            animation = new Animation();
            animation.AddFrame(new Rectangle(234, 16, 43, 58));
            animation.AddFrame(new Rectangle(277, 16, 43, 58));
            animation.AddFrame(new Rectangle(320, 16, 43, 58));
            animation.AddFrame(new Rectangle(363, 16, 43, 58));
            animation.AddFrame(new Rectangle(406, 16, 43, 58));
            animation.AddFrame(new Rectangle(440, 16, 43, 58));
            animation.AantalBewegingenPerSeconde = 8;
        }

        public void Update(GameTime gametime)
        {
            Bediening.Update();
            if(Bediening.Left || Bediening.Right)
            {
                animation.Update(gametime);
            }
            if (Bediening.Left)
            {
                Positie -= VelocityX;
                heroFlip = SpriteEffects.FlipHorizontally;
            }
            if (Bediening.Right)
            {
                Positie += VelocityX;
                heroFlip = SpriteEffects.None;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
           // spritebatch.Draw(Texture, Positie, animation.CurrentFrame.SourceRectangle, Color.AliceBlue);
            spritebatch.Draw(texture: Texture, destinationRectangle: new Rectangle((int)Positie.X,(int) Positie.Y, 43,58), sourceRectangle: animation.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: new Vector2(0,0) , effects:heroFlip, layerDepth: 0f);
        }

    }
}
