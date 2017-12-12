﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife.Class
{
    class Animation
    {
        private List<AnimationFrame> frames;
        public AnimationFrame CurrentFrame { get; set; }
        public int AantalBewegingenPerSeconde { get; set; }
        private int counter = 0;
        private double x = 0;
        public double Offset { get; set; }
        private int _totalWidth = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            AantalBewegingenPerSeconde = 1; 
        }

        // Voeg nieuwe rectangle toe naar frames
        // Offset = breedte van 1 frame
        // Bereken de totaal breedte van een afbeelding
        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame newFrame = new AnimationFrame();
            newFrame.SourceRectangle = rectangle;

            frames.Add(newFrame);
            CurrentFrame = frames[0];
            Offset = CurrentFrame.SourceRectangle.Width;
            foreach(AnimationFrame f in frames)
            {
                _totalWidth += f.SourceRectangle.Width;
            }
        }

        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);
            x += temp;
            System.Console.WriteLine("SourceRectanle.with = " + CurrentFrame.SourceRectangle.Width);
            System.Console.WriteLine("gameTime in sec " + (double)gameTime.ElapsedGameTime.Milliseconds / 1000);
            System.Console.WriteLine("temp is " + temp);
            System.Console.WriteLine("x = " + x);
            System.Console.WriteLine("AantaleBewegingenPerSec " + AantalBewegingenPerSeconde);
            System.Console.WriteLine("SourceRectangle.Width / AantalBewegingenPerSeconde = " + CurrentFrame.SourceRectangle.Width / AantalBewegingenPerSeconde);
            if (x >= CurrentFrame.SourceRectangle.Width / AantalBewegingenPerSeconde) // aantalbewegingPerSec = hoeveel keer sneller wil je gaan?
            {
                x = 0;
                counter++;
                if (counter >=frames.Count)
                {
                    counter = 0;
                }
                CurrentFrame = frames[counter];
                Offset += CurrentFrame.SourceRectangle.Width;
            }
            if (Offset >= _totalWidth)
                Offset = 0;
        }
    }
}