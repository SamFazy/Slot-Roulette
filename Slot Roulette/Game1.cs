using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Slot_Roulette
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        int timer;
        const int BLACK = 1, RED = 2, GREEN = 3;
        const int VISIBLE = 1, INVISIBLE = 2;
        int gameState;
        int gameState2;
        int timerSpin;
        int winnerFlash;

        MouseState previousMouseState;
        MouseState mouseState;
        Random generator = new Random();

        //Slot 1
        Texture2D slot1Texture;
        Rectangle slot1Rect;
        int slot1Colour;
        bool slot1Red;
        bool slot1Black;
        bool slot1Green;
        //Slot 1 Animation
        Texture2D slot1AnimationTexture;
        Rectangle slot1AnimationRect;
        //Slot 1 Border
        Texture2D slot1BorderTexture;
        Rectangle slot1BorderRect;

        //Slot 2
        Texture2D slot2Texture;
        Rectangle slot2Rect;
        int slot2Colour;
        bool slot2Red;
        bool slot2Black;
        bool slot2Green;
        //Slot 2 Animation
        Texture2D slot2AnimationTexture;
        Rectangle slot2AnimationRect;
        //Slot 2 Border
        Texture2D slot2BorderTexture;
        Rectangle slot2BorderRect;

        //Slot 3
        Texture2D slot3Texture;
        Rectangle slot3Rect;
        int slot3Colour;
        bool slot3Red;
        bool slot3Black;
        bool slot3Green;
        //Slot 3 Animation
        Texture2D slot3AnimationTexture;
        Rectangle slot3AnimationRect;
        //Slot 3 Border
        Texture2D slot3BorderTexture;
        Rectangle slot3BorderRect;

        //Winner
        Texture2D winnerTexture;
        Rectangle winnerRect;

        //Background
        Texture2D backgroundTexture;
        Rectangle backgroundRect;


        int randomSpin;

        bool win;

        //Spin
        Texture2D spinTexture;
        Rectangle spinRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Window Size
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            //Slot 1
            slot1Rect = new Rectangle(285, 380, 350, 350);
            slot1AnimationRect = new Rectangle(285, 380, 350, 350);
            //Border
            slot1BorderRect = new Rectangle(280, 375, 360, 360);

            //Slot 2
            slot2Rect = new Rectangle(785, 380, 350, 350);
            slot2AnimationRect = new Rectangle(785, 380, 350, 350);
            //Border
            slot2BorderRect = new Rectangle(780, 375, 360, 360);

            //Slot 3
            slot3Rect = new Rectangle(1285, 380, 350, 350);
            slot3AnimationRect = new Rectangle(1285, 380, 350, 350);
            //Border
            slot3BorderRect = new Rectangle(1280, 375, 360, 360);

            //Background
            backgroundRect = new Rectangle(0, 0, 1920, 1080);

            //Spin
            spinRect = new Rectangle(610, 800, 700, 150);

            //Winner
            winnerRect = new Rectangle(610, 80, 700, 300);

            //Timer
            timer = 8;
            gameState = BLACK;

            timerSpin = 10000;

            gameState2 = VISIBLE;
            winnerFlash = 8;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Slot 1
            slot1Texture = Content.Load<Texture2D>("PLayer");
            slot1AnimationTexture = Content.Load<Texture2D>("PLayer");
            //Border
            slot1BorderTexture = Content.Load<Texture2D>("Border");

            //Slot 2
            slot2Texture = Content.Load<Texture2D>("PLayer");
            slot2AnimationTexture = Content.Load<Texture2D>("PLayer");
            //Border
            slot2BorderTexture = Content.Load<Texture2D>("Border");

            //Slot 3
            slot3Texture = Content.Load<Texture2D>("PLayer");
            slot3AnimationTexture = Content.Load<Texture2D>("PLayer");
            //Border
            slot3BorderTexture = Content.Load<Texture2D>("Border");

            //Background
            backgroundTexture = Content.Load<Texture2D>("glow_background");

            //Winner
            winnerTexture = Content.Load<Texture2D>("Winner2");

            //Spin
            spinTexture = Content.Load<Texture2D>("Spin");
        }

        protected override void Update(GameTime gameTime)
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            timerSpin++;
            timer--;
            winnerFlash--;

            if(timer == 0)
            {
                timer = 8;

                if (gameState == BLACK)
                {
                    gameState = RED;
                }
                else if (gameState == RED)
                {
                    gameState = GREEN;
                }
                else if (gameState == GREEN)
                {
                    gameState = BLACK;
                }
            }

            if (winnerFlash == 0)
            {
                winnerFlash = 15;

                if (gameState2 == VISIBLE)
                {
                    gameState2 = INVISIBLE;
                }
                else if (gameState2 == INVISIBLE)
                {
                    gameState2 = VISIBLE;
                }

            }



            // TODO: Add your update logic here

            if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                if (spinRect.Contains(mouseState.X, mouseState.Y))
                {
                    slot1Red = false;
                    slot1Black = false;
                    slot1Black = false;

                    slot2Red = false;
                    slot2Black = false;
                    slot2Green = false;

                    slot3Red = false;
                    slot3Black = false;
                    slot3Green = false;

                    win = false;

                    //Slot 1
                    randomSpin = generator.Next(1, 21);
                    slot1Colour = randomSpin;

                    if (randomSpin == 1 || randomSpin == 2 || randomSpin == 3 || randomSpin == 4 || randomSpin == 5 || randomSpin == 6 || randomSpin == 7 || randomSpin == 8 || randomSpin == 9)
                    {
                        slot1Red = true;
                    }

                    if (randomSpin == 10 || randomSpin == 11 || randomSpin == 12 || randomSpin == 13 || randomSpin == 14 || randomSpin == 15 || randomSpin == 16 || randomSpin == 17 || randomSpin == 18)
                    {
                        slot1Black = true;
                    }
                    if (randomSpin == 19 || randomSpin == 20)
                    {
                        slot1Green = true;
                    }


                    //Slot 2
                    randomSpin = generator.Next(1, 21);
                    slot2Colour = randomSpin;

                    if (randomSpin == 1 || randomSpin == 2 || randomSpin == 3 || randomSpin == 4 || randomSpin == 5 || randomSpin == 6 || randomSpin == 7 || randomSpin == 8 || randomSpin == 9)
                    {
                        slot2Red = true;
                    }
                    if (randomSpin == 10 || randomSpin == 11 || randomSpin == 12 || randomSpin == 13 || randomSpin == 14 || randomSpin == 15 || randomSpin == 16 || randomSpin == 17 || randomSpin == 18)
                    {
                        slot2Black = true;
                    }

                    if (randomSpin == 19 || randomSpin == 20)
                    {
                        slot2Green = true;
                    }

                    //Slot 3
                    randomSpin = generator.Next(1, 21);
                    slot3Colour = randomSpin;

                    if (randomSpin == 1 || randomSpin == 2 || randomSpin == 3 || randomSpin == 4 || randomSpin == 5 || randomSpin == 6 || randomSpin == 7 || randomSpin == 8 || randomSpin == 9)
                    {
                        slot3Red = true;
                    }
                    if (randomSpin == 10 || randomSpin == 11 || randomSpin == 12 || randomSpin == 13 || randomSpin == 14 || randomSpin == 15 || randomSpin == 16 || randomSpin == 17 || randomSpin == 18)
                    {
                        slot3Black = true;
                    }

                    if (randomSpin == 19 || randomSpin == 20)
                    {
                        slot3Green = true;
                    }

                    timerSpin = 0;

                    slot1Rect = new Rectangle(2850, 3800, 3500, 3500);
                    slot2Rect = new Rectangle(2850, 3800, 3500, 3500);
                    slot3Rect = new Rectangle(2850, 3800, 3500, 3500);

                    //Win and Loss Detection
                    if (slot1Black == true && slot2Black == true && slot3Red == true)
                    {

                    }
                    else if (slot1Black == true && slot2Red == true && slot3Red == true)
                    {

                    }
                    else if (slot1Black == true && slot2Red == true && slot3Black == true)
                    {

                    }
                    else if (slot1Red == true && slot2Red == true && slot3Black == true)
                    {

                    }
                    else if (slot1Red == true && slot2Black == true && slot3Black == true)
                    {

                    }
                    else if (slot1Red == true && slot2Black == true && slot3Red == true)
                    {

                    }
                    else
                    {
                        win = true;
                    }

                }

                
            }

            if (timerSpin == 20)
            {
                slot1Rect = new Rectangle(285, 380, 350, 350);
            }
            if (timerSpin == 120)
            {
                slot2Rect = new Rectangle(785, 380, 350, 350);
            }
            if (timerSpin == 220)
            {
                slot3Rect = new Rectangle(1285, 380, 350, 350);
            }

            
            

            base.Update(gameTime);

            

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, backgroundRect, Color.White);

            //Slot Borders
            _spriteBatch.Draw(slot1BorderTexture, slot1BorderRect, Color.White);
            _spriteBatch.Draw(slot2BorderTexture, slot2BorderRect, Color.White);
            _spriteBatch.Draw(slot3BorderTexture, slot3BorderRect, Color.White);

            if (gameState == BLACK)
            {
                _spriteBatch.Draw(slot1AnimationTexture, slot1AnimationRect, Color.Black);
                _spriteBatch.Draw(slot2AnimationTexture, slot2AnimationRect, Color.Black);
                _spriteBatch.Draw(slot3AnimationTexture, slot3AnimationRect, Color.Black);
            }

            if (gameState == RED)
            {
                _spriteBatch.Draw(slot1AnimationTexture, slot1AnimationRect, Color.Red);
                _spriteBatch.Draw(slot2AnimationTexture, slot2AnimationRect, Color.Red);
                _spriteBatch.Draw(slot3AnimationTexture, slot3AnimationRect, Color.Red);
            }

            if (gameState == GREEN)
            {
                _spriteBatch.Draw(slot1AnimationTexture, slot1AnimationRect, Color.ForestGreen);
                _spriteBatch.Draw(slot2AnimationTexture, slot2AnimationRect, Color.ForestGreen);
                _spriteBatch.Draw(slot3AnimationTexture, slot3AnimationRect, Color.ForestGreen);
            }


            //Winner
            if (win == true)
            {

                if (timerSpin > 219)
                {

                    if (gameState2 == VISIBLE)
                    {
                        _spriteBatch.Draw(winnerTexture, winnerRect, Color.White);
                    }

                    if (gameState2 == INVISIBLE)
                    {
                        _spriteBatch.Draw(winnerTexture, new Rectangle(2850, 3800, 3500, 3500), Color.White);
                    }

                }

            }
          

            //Slot 1

            //Slot 1 Red
            if (slot1Colour == 1)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 2)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 3)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 4)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 5)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 6)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 7)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 8)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            if (slot1Colour == 9)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Red);
            }
            

            //Slot 1 Black
            if (slot1Colour == 10)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 11)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 12)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 13)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 14)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 15)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 16)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 17)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }
            if (slot1Colour == 18)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Black);
            }

            //Slot 1 Green
            if (slot1Colour == 19)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.ForestGreen);
            }
            if (slot1Colour == 20)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.ForestGreen);
            }

            //Slot 2

            //Slot 2 Red
            if (slot2Colour == 1)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 2)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 3)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 4)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 5)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 6)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 7)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 8)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }
            if (slot2Colour == 9)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Red);
            }

            //Slot 2 Black
            if (slot2Colour == 10)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 11)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 12)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 13)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 14)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 15)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 16)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 17)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }
            if (slot2Colour == 18)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Black);
            }

            //Slot 2 Green
            if (slot2Colour == 19)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.ForestGreen);
            }
            if (slot2Colour == 20)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.ForestGreen);
            }

            //Slot 3

            //Slot 3 Red
            if (slot3Colour == 1)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 2)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 3)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 4)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 5)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 6)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 7)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 8)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }
            if (slot3Colour == 9)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Red);
            }

            //Slot 3 Black
            if (slot3Colour == 10)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 11)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 12)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 13)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 14)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 15)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 16)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 17)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }
            if (slot3Colour == 18)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Black);
            }

            //Slot 3 Green
            if (slot3Colour == 19)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.ForestGreen);
            }
            if (slot3Colour == 20)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.ForestGreen);
            }



            _spriteBatch.Draw(spinTexture, spinRect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
