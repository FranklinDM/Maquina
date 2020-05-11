﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.Entities
{
    public abstract class Animation : IAnimation, IDisposable
    {
        public Animation(ISprite target, float speed)
        {
            Target = target;
            Speed = speed;
        }

        public float Speed { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsRepeating { get; set; }
        public ISprite Target { get; private set; }

        public event EventHandler AnimationFinished;
        public event EventHandler AnimationStarted;

        protected virtual void OnAnimationStarted()
        {
            if (AnimationStarted != null)
            {
                AnimationStarted(this, EventArgs.Empty);
            }
        }
        protected virtual void OnAnimationFinished()
        {
            if (AnimationFinished != null)
            {
                AnimationFinished(this, EventArgs.Empty);
            }
            Dispose();
        }

        public void Start()
        {
            if (IsRunning)
            {
                IsRunning = false;
                return;
            }
            IsRunning = true;
            OnAnimationStarted();

            AnimationManager.Add(this);
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public abstract void Update();

        // IDisposable implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                IsRunning = false;
                IsRepeating = false;
                AnimationManager.Remove(this);
            }
        }
    }
}