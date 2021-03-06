﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife.Class
{
    public class Bediening
    {
       
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Down { get; set; }
        public bool Jump { get; set; }
        
        public bool Run { get; set; }
        public bool isKeyNotDown { get; set; }
        public void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            Array x = stateKey.GetPressedKeys();
            if (x.Length == 0)
            {
                isKeyNotDown = true;
            }
            else
            {
                isKeyNotDown = false;
            }

            if (stateKey.IsKeyDown(Keys.A))
            {
                Left = true;
            }
            else
            {
                Left = false;
            }
            
            if(stateKey.IsKeyDown(Keys.D))
            {
                Right = true;
            }
            else
            {
                Right = false;
            }

            if(stateKey.IsKeyDown(Keys.S))
            {
                Down = true;
            }
            else
            {
                Down = false;
            }

            if (stateKey.IsKeyDown(Keys.W))
            {
                Jump = true;
            }
            else
            {
                Jump = false;
            }

            if (stateKey.IsKeyDown(Keys.LeftShift))
            {
                Run = true;
            }
            else
            {
                Run = false;
            }

        }



    }

  

}
