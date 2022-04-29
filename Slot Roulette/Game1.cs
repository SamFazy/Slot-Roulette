﻿using Microsoft.Xna.Framework;
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
        int gameState;

        int timerSpin;

        MouseState previousMouseState;
        MouseState mouseState;
        Random generator = new Random();

        //Slot 1
        Texture2D slot1Texture;
        Rectangle slot1Rect;
        int slot1Colour;
        //Slot 1 Animation
        Texture2D slot1AnimationTexture;
        Rectangle slot1AnimationRect;

        //Slot 2
        Texture2D slot2Texture;
        Rectangle slot2Rect;
        int slot2Colour;
        //Slot 2 Animation
        Texture2D slot2AnimationTexture;
        Rectangle slot2AnimationRect;

        //Slot 3
        Texture2D slot3Texture;
        Rectangle slot3Rect;
        int slot3Colour;
        //Slot 3 Animation
        Texture2D slot3AnimationTexture;
        Rectangle slot3AnimationRect;


        int randomSpin;

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

            //Slot 2
            slot2Rect = new Rectangle(785, 380, 350, 350);
            slot2AnimationRect = new Rectangle(785, 380, 350, 350);

            //Slot 3
            slot3Rect = new Rectangle(1285, 380, 350, 350);
            slot3AnimationRect = new Rectangle(1285, 380, 350, 350);

            //Spin
            spinRect = new Rectangle(610, 800, 700, 200);

            //Timer
            timer = 8;
            gameState = BLACK;

            timerSpin = 10000;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Slot 1
            slot1Texture = Content.Load<Texture2D>("PLayer");
            slot1AnimationTexture = Content.Load<Texture2D>("PLayer");
            //Slot 2
            slot2Texture = Content.Load<Texture2D>("PLayer");
            slot2AnimationTexture = Content.Load<Texture2D>("PLayer");
            //Slot 3
            slot3Texture = Content.Load<Texture2D>("PLayer");
            slot3AnimationTexture = Content.Load<Texture2D>("PLayer");

            //Spin
            spinTexture = Content.Load<Texture2D>("PLayer");
        }

        protected override void Update(GameTime gameTime)
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            timerSpin++;
            timer--;
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

            

            // TODO: Add your update logic here

            if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                if (spinRect.Contains(mouseState.X, mouseState.Y))
                {

                    //Slot 1
                    randomSpin = generator.Next(1, 21);
                    slot1Colour = randomSpin;

                    //Slot 2
                    randomSpin = generator.Next(1, 21);
                    slot2Colour = randomSpin;

                    //Slot 3
                    randomSpin = generator.Next(1, 21);
                    slot3Colour = randomSpin;
                    
                    timerSpin = 0;

                    slot1Rect = new Rectangle(2850, 3800, 3500, 3500);
                    slot2Rect = new Rectangle(2850, 3800, 3500, 3500);
                    slot3Rect = new Rectangle(2850, 3800, 3500, 3500);

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
                _spriteBatch.Draw(slot1AnimationTexture, slot1AnimationRect, Color.Green);
                _spriteBatch.Draw(slot2AnimationTexture, slot2AnimationRect, Color.Green);
                _spriteBatch.Draw(slot3AnimationTexture, slot3AnimationRect, Color.Green);
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
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Green);
            }
            if (slot1Colour == 20)
            {
                _spriteBatch.Draw(slot1Texture, slot1Rect, Color.Green);
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
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Green);
            }
            if (slot2Colour == 20)
            {
                _spriteBatch.Draw(slot2Texture, slot2Rect, Color.Green);
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
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Green);
            }
            if (slot3Colour == 20)
            {
                _spriteBatch.Draw(slot3Texture, slot3Rect, Color.Green);
            }

            _spriteBatch.Draw(spinTexture, spinRect, Color.Yellow);

            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
