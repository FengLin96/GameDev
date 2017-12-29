using Microsoft.Xna.Framework;
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
            AantalBewegingenPerSeconde = 10; 
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
            double temp = CurrentFrame.SourceRectangle.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000); // ik wil per sec zoveeel pixel(currentFrame.SourceRectangle.width) naar rechts schuiven
            x += temp;

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
