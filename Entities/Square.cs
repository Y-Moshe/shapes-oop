using Interfaces;

namespace Entities
{
  class Square : BaseShape, IMathShape
  {
    #region Data-Members.
    private int length; // מייצג את אורך הצלע.
    #endregion

    #region Ctors
    public Square() { }

    public Square(int x, int y, ConsoleColor color, int length) : base(x, y, color)
    {
      Length = length;
    }
    #endregion

    #region Property
    /// <summary>
    /// represents the length of the square, the value must be between 3-10!.
    /// </summary>
    public int Length
    {
      set
      {
        // Minimum value of length: 3 and Maximum: 10
        // check if the number between them
        if (value < 3 || value > 10)
          throw new Exception("the length of the square must be between 3-10");
        length = value;
      }
      get
      {
        return length;
      }
    }
    #endregion

    #region Methods
    public override string ToString()
    {
      return base.ToString() + " " + length;
    }
    /// <summary>
    /// Start drawing the square in the console interface.
    /// </summary>
    public override void Draw()
    {
      // go down to see description of this function.
      if (CheckValidate() == false)
        InitWithRandomValues();
      Console.ForegroundColor = Color;
      Console.SetCursorPosition(X, Y); // start drawing from this position.
      for (int i = 1; i <= length; i++)
      {
        Console.CursorLeft = X;
        for (int j = 1; j <= length; j++)
        {
          if (i == 1 || i == length)
            Console.Write("*");
          else if (j == 1 || j == length)
            Console.Write("*");
          else
            Console.Write(" ");
        }
        Console.WriteLine();
      }
      Console.ResetColor();
      // Set X and Y in the middle.
      X += Length / 2;
      Y += Length / 2;
    }
    // return double becase of circle
    /// <summary>
    /// Get the area of the square.
    /// </summary>
    /// <returns>The area as double.</returns>
    public double GetArea()
    {
      return Length * Length;
    }

    /// <summary>
    /// Get perimeter of the square.
    /// </summary>
    /// <returns>the perimeter as double.</returns>
    public double GetPerimeter()
    {
      return Length * 4;
    }

    /// <summary>
    /// Fill the square data with random values.
    /// </summary>
    public override void InitWithRandomValues()
    {
      base.InitWithRandomValues();
      length = rand.Next(3, 11); // random number between 3-10.
                                 // if somting wrong with the random values then do recusion to collect a new values.
      if (CheckValidate() == false)
        InitWithRandomValues();
    }

    /// <summary>
    /// showing all the details about the square throw the console.
    /// </summary>
    public override void ShowDetails()
    {
      base.ShowDetails();
      Console.WriteLine("Shape Name: Square");
      Console.WriteLine("Length: " + Length);
      Console.WriteLine("Area: " + GetArea());
      Console.WriteLine("Perimeter: " + GetPerimeter());
    }
    #endregion

    // private function.
    private bool CheckValidate()
    {
      // checking if the square is gonna be write overflow-x or overflow-y.
      if ((Y + Length) >= 25 || (X + Length) >= 80)
        return false;
      // if Y number is between 0-7 thats mean in the line of ShowDetails() function then check if the X value
      // is less than 20 (becase then it will override the ShowDetails messages)
      if (Y >= 0 && Y <= 7)
      {
        if (X < 20)
          return false;
      }
      return true;
    }
  }
}
