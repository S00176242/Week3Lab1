using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week3Lab1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        string message = "Message to Fade";
        byte alpha = 255;
        private string timeMessage;
        string[] messages = new string[] { "Item 1", "Item 2", "Item 3", "Item 4" };
        byte[] alphas = new byte[] { 255, 255, 255, 255 };
        int currentSelectedMessage = 0;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("fade");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            int seconds = gameTime.ElapsedGameTime.Milliseconds;
            if (alpha > 0)
                alpha -= (byte)(seconds/8);
            else if (alpha <= 255)
                alpha += (byte)(seconds/8);
              
            timeMessage = "Time Elapsed" + gameTime.TotalGameTime.Seconds.ToString();
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            Color Messagecolor = new Color((byte)255, (byte)255, (byte)255, alpha--);
            spriteBatch.DrawString(font, timeMessage, new Vector2(20, 20), Color.White);
            spriteBatch.DrawString(font, message, new Vector2(100, 100), Messagecolor);
            Vector2 startPosition = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            foreach (var item in messages)
            {
                spriteBatch.DrawString(font, item, startPosition, Color.White);
                float textHeight = font.MeasureString(item).Y;
                startPosition += new Vector2(0, textHeight + 10);
            }
           
            Vector2 messageSize = font.MeasureString(messages[0]);
            
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
