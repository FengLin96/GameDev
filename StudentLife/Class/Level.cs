using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife.Class
{
    class Level
    {
        public Texture2D texture;
        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,1,0,0,1,0,1},
            {0,0,1,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,1,0,0,0,0,0,0,0,0,1},
            {0,0,0,1,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1}
        };
        private Block[,] blockArray = new Block[6,13];
        
        public void CreateWorld()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if(tileArray[i,j] == 1)
                    {
                        blockArray[i, j] = new Block(texture, new Vector2(j*70,i*70));
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (blockArray[i, j] != null)
                    {
                        blockArray[i, j].Draw(spritebatch);
                    }
                }
            }
        }

    }
}
