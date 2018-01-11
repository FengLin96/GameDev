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
        private Texture2D texture;
        
        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        private int kolom = 13;
        private int rij = 18;

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,1,0,1,0,0,1,0,1},
            {0,0,1,0,0,1,0,0,0,0,0,0,1},
            {0,0,0,1,0,1,0,0,0,0,0,0,1},
            {0,0,0,1,0,1,0,0,0,0,0,0,1},
            {0,0,0,0,1,1,0,0,0,0,0,0,1},
            {0,0,0,0,1,1,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,0,0,0,1},

        };
        private Block[,] blockArray;

        public Block[,] BlockArray
        {
            get { return blockArray; }
         
        }

        public Level()
        {
            blockArray = new Block[rij, kolom];
        }
        
        public void CreateWorld()
        {
            for (int i = 0; i < rij; i++)
            {
                for (int j = 0; j < kolom; j++)
                {
                    if(tileArray[i,j] == 1)
                    {
                        blockArray[i, j] = new Block(texture, new Vector2(j*70,i*19));
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int i = 0; i < rij; i++)
            {
                for (int j = 0; j < kolom; j++)
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
