using Maquina.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina
{
    public class WindowManager : IDisposable
    {
        public WindowManager()
        {
            Windows = new EventDictionary<string, Window>();
            Windows.ItemAdded += Windows_ItemAdded;
            Windows.ItemRemoved += Windows_ItemRemoved;
            Windows.DictionaryCleared += Windows_DictionaryCleared;
            FocusedWindow = new EmptyWindow();
        }

        private void Windows_ItemAdded(string key, Window window)
        {
            // Load content when scene is added
            window.LoadContent();
        }

        private void Windows_ItemRemoved(string key, Window window)
        {
            // Unload content when scene is removed
            window.Unload();
        }

        private void Windows_DictionaryCleared()
        {
            // Unload content of every window
            foreach (Window window in Windows.Values)
            {
                window.Unload();
            }
        }

        public EventDictionary<string, Window> Windows { get; private set; }
        public Window FocusedWindow { get; set; }

        public void Draw(GameTime gameTime)
        {
            for (int i = Windows.Count - 1; i >= 0; i--)
            {
                Windows[Windows.Keys.ElementAt(i)].Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = Windows.Count - 1; i >= 0; i--)
            {
                Windows[Windows.Keys.ElementAt(i)].Update(gameTime);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Windows.Clear();
            }
        }
    }
}
