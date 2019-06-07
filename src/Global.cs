﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maquina
{
    public static class Global
    {
        static Global()
        {
            ResourceXml = "platformresources.xml";
            PreferencesXml = "preferences.xml";
            LocaleDefinitionXml = "locale.xml";
            ContentRootDirectory = "Content";
            LocalesDirectory = "locales";
            DefaultLocale = "en-US";

            Scale = 1f;
            Fonts = new Dictionary<string, SpriteFont>();
            BGM = new Dictionary<string, Song>();
        }

        private static Version _version = Assembly.GetExecutingAssembly().GetName().Version;
        private static DateTime _buildDate = new DateTime(2000, 1, 1)
            .AddDays(_version.Build)
            .AddSeconds(_version.Revision * 2);

        // General Information
        public static readonly string Name = "Maquina";
        public static readonly string BuildDate = String.Format("{0} {1}",
            _buildDate.ToShortDateString(), _buildDate.ToShortTimeString());
        public static readonly int APIVersion = 0;

        // Resources
        public static string ResourceXml { get; set; }
        public static string PreferencesXml { get; set; }
        public static string LocaleDefinitionXml { get; set; }
        public static string ContentRootDirectory { get; set; }
        public static string LocalesDirectory { get; set; }
        public static string DefaultLocale { get; set; }

        // App-wide properties
        public static float Scale { get; set; }
        public static Dictionary<string, SpriteFont> Fonts { get; set; }
        public static Dictionary<string, Song> BGM { get; set; }
        public static Dictionary<string, SoundEffect> SFX { get; set; }
        public static Dictionary<string, Texture2D> Textures { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static Game Game { get; set; }

        // Managers
        public static SceneManager SceneManager { get; set; }
        public static AudioManager AudioManager { get; set; }
        public static InputManager InputManager { get; set; }
        public static LocaleManager LocaleManager { get; set; }
        public static PreferencesManager PreferencesManager { get; set; }
        public static WindowManager WindowManager { get; set; }
    }
}
