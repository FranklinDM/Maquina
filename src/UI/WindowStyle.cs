using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.UI
{
    [Serializable]
    public struct WindowStyle
    {
        private Color backgroundColor;
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }
        private Color borderColor;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }
        private Color fontColor;
        public Color FontColor
        {
            get { return fontColor; }
            set { fontColor = value; }
        }
        private int borderWidth;
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        private static WindowStyle Default
        {
            get
            {
                return new WindowStyle(Color.DarkSlateGray, Color.Black, Color.White, 2);
            }
        }

        public WindowStyle(Color backgroundColor, Color borderColor, Color fontColor)
        {
            this.backgroundColor = backgroundColor;
            this.borderColor = borderColor;
            this.fontColor = fontColor;
            this.borderWidth = 2;
        }

        public WindowStyle(Color backgroundColor, Color borderColor, Color fontColor, int borderWidth)
        {
            this.backgroundColor = backgroundColor;
            this.borderColor = borderColor;
            this.fontColor = fontColor;
            this.borderWidth = borderWidth;
        }

        public override string ToString()
        {
            return string.Format("{{BackgroundColor:{0} BorderColor:{1} FontColor:{2} BorderWidth:{3}}}",
                BackgroundColor.ToString(), BorderColor.ToString(),
                FontColor.ToString(), BorderWidth.ToString());
        }
    }
}
