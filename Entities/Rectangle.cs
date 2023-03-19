using Interfaces;

namespace Entities
{
  class Rectangle : BaseShape, IMathShape
  {
    #region Data-Members
    private int width;
    private int height;
    #endregion

    #region Ctors
    public Rectangle() { }

    public Rectangle(int x, int y, ConsoleColor color, int width, int height) : base(x, y, color)
    {
      Width = width;
      Height = height;
    }
    #endregion

    #region Propertry
    /// <summary>
    /// Represent the width of the rectangle, the value must be between 5-50!.
    /// </summary>
    public int Width
    {
      set
      {
        // checking if it is currect value.
        if (value < 5 || value > 50)
          throw new Exception("Width must be between 5-50");
        width = value;
      }
      get
      {
        return width;
      }
    }

    /// <summary>
    /// Represent the height of the rectangle, the value must be between 5-15!.
    /// </summary>
    public int Height
    {
      set
      {
        // checking if it is currect value.
        if (value < 5 || value > 15)
          throw new Exception("Height must be between 5-15");
        height = value;
      }
      get
      {
        return height;
      }
    }
    #endregion

    #region Methods
    public override string ToString()
    {
      return string.Format(base.ToString() + " {0} {1}", width, height);
    }
    /// <summary>
    /// Start drawing the rectangle throw the console interface.
    /// </summary>
    public override void Draw()
    {
      // go down to see description of this function.
      if (CheckValidate() == false)
        InitWithRandomValues();
      Console.ForegroundColor = Color;
      Console.SetCursorPosition(X, Y);
      for (int i = 1; i <= Height; i++)
      {
        Console.CursorLeft = X;
        for (int j = 1; j <= Width; j++)
        {
          if (i == 1 || i == Height)
            Console.Write("*");
          else if (j == 1 || j == Width)
            Console.Write("*");
          else
            Console.Write(" ");
        }
        Console.WriteLine();
      }
      Console.ResetColor();
      // Set X and Y in the middle.
      X += Width / 2;
      Y += Height / 2;
    }

    /// <summary>
    /// Get the area of the rectangle.
    /// </summary>
    /// <returns>the area as double.</returns>
    public double GetArea()
    {
      return Width * Height;
    }

    /// <summary>
    /// Get perimeter of the rectangle.
    /// </summary>
    /// <returns>the perimeter as double.</returns>
    public double GetPerimeter()
    {
      return (Width + Height) * 2;
    }

    /// <summary>
    /// Fill all the rectangle data with random values.
    /// </summary>
    public override void InitWithRandomValues()
    {
      base.InitWithRandomValues();
      width = rand.Next(5, 51); // random number between 5-50.
      height = rand.Next(5, 16); // random number between 5-15.
                                 // checking if somting wrong.
      if (CheckValidate() == false)
        InitWithRandomValues();
    }

    public override void ShowDetails()
    {
      base.ShowDetails();
      Console.WriteLine("Shape Name: Rectangle");
      Console.WriteLine("Width: " + width);
      Console.WriteLine("Height: " + height);
      Console.WriteLine("Area: " + GetArea());
      Console.WriteLine("Perimeter: " + GetPerimeter());
    }
    #endregion

    // private function.
    private bool CheckValidate()
    {
      // checking if the rectangle is gonna be write overflow-x or overflow-y.
      if ((Y + height) >= 25 || (X + width) >= 80)
        return false;
      // if Y number is between 0-8 thats mean in the line of ShowDetails() function then check if the X value.
      // is less than 23 (because then it will override the ShowDetails messages).
      if (Y >= 0 && Y <= 8)
      {
        if (X < 23)
          return false;
      }
      return true;
    }
  }
}
