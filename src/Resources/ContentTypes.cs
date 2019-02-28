﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maquina.Resources
{
    // <Content>
    // Used for loading primary content resources
    [XmlRoot("Content")]
    public class ResourceContent : IContent
    {
        // key, resource location
        public List<FontParameters> Fonts { get; set; }
        public List<ResourceParameters> BGM { get; set; }
        public List<ResourceParameters> SFX { get; set; }
        public List<ResourceParameters> Textures { get; set; }

        public object LoadContent(ResourceType resourceType, Game game)
        {
            switch (resourceType)
            {
                case ResourceType.Fonts:
                    Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
                    for (int i = 0; i < Fonts.Count; i++)
                    {
                        FontParameters item = Fonts[i];
                        fonts[item.Name] = game.Content.Load<SpriteFont>(item.Location);
                        fonts[item.Name].Spacing = item.Spacing;
                        fonts[item.Name].LineSpacing = item.LineSpacing;
                    }
                    return fonts;
                case ResourceType.BGM:
                    Dictionary<string, Song> songs = new Dictionary<string, Song>();
                    for (int i = 0; i < BGM.Count; i++)
                    {
                        ResourceParameters item = BGM[i];
                        songs[item.Name] = game.Content.Load<Song>(item.Location);
                    }
                    return songs;
                case ResourceType.SFX:
                    Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
                    for (int i = 0; i < SFX.Count; i++)
                    {
                        ResourceParameters item = SFX[i];
                        sounds[item.Name] = game.Content.Load<SoundEffect>(item.Location);
                    }
                    return sounds;
                case ResourceType.Textures:
                    Dictionary<string, Texture2D> tex = new Dictionary<string, Texture2D>();
                    for (int i = 0; i < Textures.Count; i++)
                    {
                        ResourceParameters item = Textures[i];
                        tex[item.Name] = game.Content.Load<Texture2D>(item.Location);
                    }
                    return tex;
            }
            return null;
        }
    }
    public enum ResourceType
    {
        Fonts,
        BGM,
        SFX,
        Textures
    }
    public class FontParameters : ResourceParameters
    {
        [XmlAttribute]
        public int LineSpacing { get; set; }
        [XmlAttribute]
        public float Spacing { get; set; }
    }
    public class ResourceParameters
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Location { get; set; }
    }
    
    // <LocaleDefinition>
    [XmlRoot("LocaleDefinition")]
    public class LocaleDefinition : IContent
    {
        public string LanguageName { get; set; }
        public string LanguageCode { get; set; }
        public List<string> Authors { get; set; }
    }

    // <StringBundle>
    // Used for loading localized string resources
    [XmlRoot("StringBundle")]
    public class StringBundle : IContent
    {
        public List<StringParameters> Strings { get; set; }
    }
    public class StringParameters
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Content { get; set; }
    }
}