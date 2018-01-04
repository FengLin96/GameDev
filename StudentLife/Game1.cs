using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StudentLife.Class;
using System;
using System.Collections.Generic;

namespace StudentLife
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D heroTexture;
        Hero hoofdpersonage;
        Level level;
        Texture2D blockTexture;

        Texture2D backgroundImg;
        Rectangle backgroundRec;
        
        List<ICollide> collideObjecten;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
          
           

            backgroundRec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            
                        
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            heroTexture = Content.Load<Texture2D>("hoofdpersonage");
            hoofdpersonage = new Hero(heroTexture, new Vector2(100, 350));

            level = new Level();
            blockTexture = Content.Load<Texture2D>("castleHalf");
            level.Texture = blockTexture;

            collideObjecten = new List<ICollide>();
            

            //voeg alle blokken toe aan collideObjecten
            for (int i = 0; i < level.BlockArray.GetLength(0); i++)
            {
                for (int j = 0; j < level.BlockArray.GetLength(1); j++)
                {
                    collideObjecten.Add(level.BlockArray[i, j]);
                }
            }
            level.CreateWorld();

            backgroundImg = Content.Load<Texture2D>("city");
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hoofdpersonage.Update(gameTime);

            for (int i = 0; i < collideObjecten.Count; i++)
            {
                bool result = false;
                Rectangle recA = hoofdpersonage.GetCollisionRectangle();
                Color[] dataA = hoofdpersonage.GetTextureColorData();

                Color[] dataB = collideObjecten[i].GetTextureColorData();
                Rectangle recB = collideObjecten[i].GetCollisionRectangle();
                
                
                result = PixelCollision(recA,dataA,recB,dataB);
                if (result)
                {
                    Console.WriteLine("Collide");
                }
            }

            base.Update(gameTime);



        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImg, backgroundRec, Color.White);
            hoofdpersonage.Draw(spriteBatch);
            level.DrawWorld(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public bool PixelCollision(Rectangle collisionRecA, Color[] dataA, Rectangle collisionRecB, Color[] dataB) 
        {
            int top = Math.Max(collisionRecA.Top, collisionRecB.Top);
            int bottom = Math.Min(collisionRecA.Bottom, collisionRecB.Bottom);
            int left = Math.Max(collisionRecA.Left, collisionRecB.Left);
            int right = Math.Min(collisionRecA.Right, collisionRecB.Right);

            for (int i = top; i < bottom; i++)  //stel top = 0 bottom = 10 //0,1,2
            {
                for (int j = left; j < right; j++) // stel left = 0 right = 5 /0,1,2,3,4,5,0
                {                                               //width = 5
                    Color colorA = dataA[(i - collisionRecA.Top) + (j - collisionRecA.Left) * collisionRecA.Width]; //0,1,2,3,4,5,5,6,7,8,9,10,10,....... // 0 - width*height
                    Color colorB = dataB[(i - collisionRecB.Top) + (j - collisionRecB.Left) * collisionRecB.Width];

                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
