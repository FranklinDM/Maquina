﻿using Maquina.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.UI
{
    public partial class FadeOverlay
    {
        Image FadeImage;

        private void InitializeComponent()
        {
            FadeImage = new Image("Background");
            FadeImage.IgnoreDisplayScale = true;
            FadeImage.Sprite = FadeBackground;
            FadeImage.Bounds = Bounds;

            Application.Display.ResolutionChanged += (sender, e) =>
            {
                FadeImage.Bounds = ((DisplayManager)sender).WindowBounds;
            };

            FadeInAnimation = new FadeInAnimation(FadeImage, FadeSpeed);
            FadeInAnimation.AnimationFinished += (sender, e) =>
            {
                FadeOutAnimation.Start();
            };

            FadeOutAnimation = new FadeOutAnimation(FadeImage, FadeSpeed);
            FadeOutAnimation.AnimationFinished += (sender, e) =>
            {
                Application.Scenes.Overlays.Remove(this);
            };

            FadeInAnimation.Start();

            Entities.Add(FadeImage);
        }
    }
}
