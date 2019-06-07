using Maquina.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.UI
{
    public abstract class Window
    {
        public Window(string windowTitle = "Untitled Window")
        {
            Title = windowTitle;
            // Create local references to global properties
            SceneManager = Global.SceneManager;
            InputManager = Global.InputManager;
            Game = Global.Game;
            SpriteBatch = Global.SpriteBatch;
            Fonts = Global.Fonts;
            // Initialize element containers
            Children = new Dictionary<string, GenericElement>();
            WindowDecorations = new Dictionary<string, GenericElement>()
            {
                // TODO: Add other titlebar elements
                { "background", new Image("bg") {
                    OnUpdate = (element) =>
                    {
                        // TODO: continually adjust window bg size
                    }
                }},
            };
        }

        // Convenient aliases to global props
        protected SceneManager SceneManager { get; private set; }
        protected InputManager InputManager { get; private set; }
        protected Game Game { get; private set; }
        protected SpriteBatch SpriteBatch { get; private set; }
        protected Dictionary<string, SpriteFont> Fonts { get; private set; }
        // Properties
        public string Title { get; private set; }
        public bool IsFocused { get; set; }
        public Visibility Visibility { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 Dimensions { get; set; }
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(Location.ToPoint(), Dimensions.ToPoint());
            }
        }
        // TODO: Decide whether to allow on-the-fly modification of window decoration
        public Dictionary<string, GenericElement> WindowDecorations { get; set; } // private set;
        public Dictionary<string, GenericElement> Children { get; set; }
        public Point WindowCenter
        {
            get
            {
                return Bounds.Center;
            }
        }
        // Fields
        private bool IsFirstUpdateDone = false;

        public virtual void LoadContent()
        {
#if HAS_CONSOLE && LOG_VERBOSE
            Console.WriteLine("Loading content from window in: {0}", Title);
#endif
        }

        public virtual void Draw(GameTime gameTime)
        {
            // Sprite batch for window decorations
            SpriteBatch.Begin(SpriteSortMode.BackToFront);
            DrawElements(gameTime, WindowDecorations);
            SpriteBatch.End();
            // Separate sprite batch for window content
            SpriteBatch.Begin(SpriteSortMode.BackToFront);
            DrawElements(gameTime, Children);
            SpriteBatch.End();
        }

        public virtual void DrawElements(GameTime gameTime, IDictionary<string, GenericElement> elements)
        {
            DrawElements(gameTime, elements.Values);
        }

        public virtual void DrawElements(GameTime gameTime, IEnumerable<GenericElement> elements)
        {
            if (IsFirstUpdateDone)
            {
                // Draw elements in the Object array
                for (int i = 0; i < elements.Count(); i++)
                {
                    try
                    {
                        elements.ElementAt(i).Draw(gameTime);
                    }
                    catch (NullReferenceException)
                    {
                        // Suppress errors
                    }
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!IsFirstUpdateDone)
            {
                IsFirstUpdateDone = true;
            }
            // TODO: Handle window movement and resize events
        }

        public virtual void Unload()
        {
#if HAS_CONSOLE && LOG_VERBOSE
            Console.WriteLine("Unloading from window: {0}", Title);
#endif
            DisposeElements(WindowDecorations);
            DisposeElements(Children);
        }

        public virtual void DisposeElements(IDictionary<string, GenericElement> elements)
        {
            DisposeElements(elements.Values);
        }

        public virtual void DisposeElements(IEnumerable<GenericElement> elements)
        {
            for (int i = 0; i < elements.Count(); i++)
            {
                elements.ElementAt(i).Dispose();
            }
        }
    }
}
