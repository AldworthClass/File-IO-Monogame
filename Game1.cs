using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace File_IO_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont textFont;

        MouseState mouseState;

        StreamWriter _writer;
        List<string> words;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            words = new List<string>();
            base.Initialize();
            LoadScores();
            
        }

        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textFont = Content.Load<SpriteFont>("TextFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                SaveScores();
                Exit();
            }
            // TODO: Add your update logic here
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                words.Add("TEST");

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            Vector2 wordLocation = new Vector2(10, 10);
            foreach (string word in words)
            {
                _spriteBatch.DrawString(textFont, word + "", wordLocation , Color.Black);
                wordLocation.Y += 42;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void LoadScores()
        {
            if (File.Exists(@"Scores.txt"))
            {
                //Read file contents here              
                foreach (string line in File.ReadLines(@"Scores.txt", Encoding.UTF8))
                {
                    words.Add(line);
                }
            }
            else
            {
                File.CreateText(@"Scores.txt");
            }
        }

        public void SaveScores()
        {
            StreamWriter writer = new StreamWriter("Scores1.txt");
            foreach (string word in words)
                writer.WriteLine(word);
            writer.Close(); 
        }

    }
}