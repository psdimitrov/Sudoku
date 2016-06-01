namespace Sudoku.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using IDrawable = Interfaces.IDrawable;
    using IUpdateable = Interfaces.IUpdateable;

    public class Button : IDrawable, IUpdateable
    {
        public Button(Texture2D image, Texture2D imageHighlighted, Vector2 position)
        {
            this.Image = image;
            this.ImageHighlighted = imageHighlighted;
            this.Position = position;
        }

        public bool IsHighlighted { get; set; }

        public Texture2D Image { get; }

        public Texture2D ImageHighlighted { get; }

        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.IsHighlighted ? this.ImageHighlighted : this.Image, this.Position);
        }

        public void Update(GameTime gameTime)
        {            
        }
    }
}
