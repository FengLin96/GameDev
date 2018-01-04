using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife.Class
{
    class Block:ICollide
    {
        public Texture2D BlockTexture { get; set; }
        public Vector2 Positie { get; set; }

        // collision variabelen
        private Rectangle collisionRectangle;

        private Color[] textureColorData;

        public Block (Texture2D texture, Vector2 pos)
        {
            BlockTexture = texture;
            Positie = pos;
            collisionRectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);

            textureColorData = new Color[texture.Height * texture.Width];
            texture.GetData<Color>(this.textureColorData);
        }

        public void Draw(SpriteBatch spritBatch)
        {
            spritBatch.Draw(BlockTexture, Positie, Color.AliceBlue);
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
