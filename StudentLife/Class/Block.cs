using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife.Class
{
    class Block
    {
        public Texture2D BlockTexture { get; set; }
        public Vector2 Positie { get; set; }
        
        public Block (Texture2D texture, Vector2 pos)
        {
            BlockTexture = texture;
            Positie = pos;
        }

        public void Draw(SpriteBatch spritBatch)
        {
            spritBatch.Draw(BlockTexture, Positie, Color.AliceBlue);
        }
    }
}
