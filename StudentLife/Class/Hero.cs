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
    class Hero:ICollide
    { 
        private Vector2 positie;

        public Vector2 Positie
        {
            get { return positie; }
            set { positie = value; }
        }

        private Texture2D Texture { get; set;}
        private Animation walk,stand,run,jump,animation;

        private Bediening bediening;
        public Bediening Bediening
        {
            get { return bediening; }
            set { bediening = value; }
        }

        //public Bediening Bediening { get; set; }
        private SpriteEffects heroFlip;
        private enum richting :int { naarLinks = -1, naarRechts = 1};
        private Movement beweging;

        //Collosion variabelen
        private Rectangle collisionRectangle;
        private Color[] textureColorData;

        public Hero(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;
            bediening = new Bediening();
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

            collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, animation.CurrentFrame.SourceRectangle.Width,animation.CurrentFrame.SourceRectangle.Height);
            textureColorData = new Color[this.Texture.Height * this.Texture.Width];
            Texture.GetData<Color>(textureColorData);


        }

        bool hasJumped = false;
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

            collisionRectangle.X = (int)positie.X;
            collisionRectangle.Y = (int)positie.Y;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, animation.CurrentFrame.SourceRectangle.Width, animation.CurrentFrame.SourceRectangle.Height);

            spritebatch.Draw(texture: Texture, destinationRectangle: destinationRectangle, sourceRectangle: animation.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: new Vector2(0, 0), effects: heroFlip, layerDepth: 0f);
        }

        public Rectangle GetCollisionRectangle()
        {
            return collisionRectangle;
        }

        public Color[] GetTextureColorData()
        {
            return textureColorData;
        }
    }
}
