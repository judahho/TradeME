using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace TradeME
{
    public enum UIScreen { MainMenu, Market, Stock }
    public class UI
    {
        public static Vector2 Screen { get { return new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()); } }

        public Panel masterPanel = new Panel(null, new Rectangle(0, 0, UI.Screen.X, UI.Screen.Y));

        public UI(UIScreen screen)
        {
            switch (screen)
            {
                case UIScreen.MainMenu:
                    throw new NotImplementedException();
                case UIScreen.Market:
                    throw new NotImplementedException();
                case UIScreen.Stock:
                    masterPanel.texts.Add(new Text("Stock", new Vector2()));
                    masterPanel.panels.Add(new Graph(masterPanel, Program.game.activeStock, new Rectangle(10, 10, 200, 100)));
                    break;
                default:
                    throw new Exception("Invalid UIScreen");
            }
        }

        public void Update()
        {
            masterPanel.Draw();
        }
    }

    public struct Text
    {
        public string text;
        public Vector2 position;
        public int fontSize;
        public Color color;

        public Text (string txt)
        {
            this.text = txt;
            this.position = new Vector2(0, 0);
            this.fontSize = 10;
            this.color = Color.Black;
        }
        public Text(string txt, Vector2 pos) : this(txt)
        {
            this.position = pos;
        }
        public Text(string txt, Vector2 pos, int font) : this(txt, pos)
        {
            this.fontSize = font;
        }
        public Text(string txt, Vector2 pos, int font, Color col) : this(txt, pos, font)
        {
            this.color = col;
        }
    }
    public struct Button
    {
        public Text text;
        public Rectangle rect;
        public Color color;
        public Action action;
    }
    public class Panel
    {
        public Panel? parent;
        public Rectangle rectangle;
        public Color color;

        public List<Text> texts;
        public List<Button> buttons;
        public List<Panel> panels;

        public Vector2 position { get
            {
                Vector2 pos = new Vector2(rectangle.X, rectangle.Y);
                if (parent != null) { pos += parent.position; }
                return pos;
            } }

        public Panel(Panel? parent, Rectangle rect)
        {
            this.parent = parent;
            this.rectangle = rect;
            this.color = Color.White;

            this.texts = new List<Text>();
            this.buttons = new List<Button>();
            this.panels = new List<Panel>();
        }
        public Panel(Panel? parent, Rectangle rect, Color color) : this(parent, rect)
        {
            this.color = color;
        }

        public virtual void Draw()
        {
            foreach (Button button in buttons)
            {

            }
            foreach (Text text in texts)
            {
                Raylib.DrawText(text.text, (int)(this.rectangle.X + text.position.X), (int)(this.rectangle.X + text.position.Y), text.fontSize, text.color);
            }
            foreach (Panel panel in panels) { panel.Draw(); }
        }
    }
}
