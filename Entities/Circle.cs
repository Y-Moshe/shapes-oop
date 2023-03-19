using Interfaces;

namespace Entities
{
  class Circle : BaseShape, IMathShape
  {
    #region Data-Members
    private int radius;
    #endregion

    #region Property
    // Property
    /// <summary>
    /// Represent the radius of the circle, the value must be between 2-5!.
    /// </summary>
    public int Radius
    {
      set
      {
        if (value < 2 || value > 5)
          throw new Exception("Radius must be between 2-5!");
        radius = value;
      }
      get
      {
        return radius;
      }
    }
    #endregion

    #region Ctors
    public Circle() { }

    public Circle(int x, int y, ConsoleColor color, int radius) : base(x, y, color)
    {
      Radius = radius;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
      return base.ToString() + " " + radius;
    }
    /// <summary>
    /// Start drawing the cirle throw the console interface.
    /// </summary>
    public override void Draw()
    {
      if (CheckValidate() == false)
        InitWithRandomValues();
      Console.ForegroundColor = Color;
      Console.SetCursorPosition(X, Y);
      // code from internet.
      double thickness = 0.4;
      double rIn = radius - thickness, rOut = radius + thickness;
      for (double y = radius; y >= -radius; --y)
      {
        Console.CursorLeft = X;
        for (double x = -radius; x < rOut; x += 0.5)
        {
          double value = x * x + y * y;
          if (value >= rIn * rIn && value <= rOut * rOut)
            Console.Write("*");
          else
            Console.Write(" ");
        }
        Console.WriteLine();
      }
      Console.ResetColor();
      // Set X and Y in the middle.
      X += Radius * 2;
      Y += Radius;
    }

    /// <summary>
    /// Get the area of the circle.
    /// </summary>
    /// <returns>the area as double with 3 leading zero.</returns>
    public double GetArea()
    {
      return Math.Round((Math.PI * radius * radius), 3);
    }

    /// <summary>
    /// Get perimeter of the circle.
    /// </summary>
    /// <returns>the perimeter as double with 3 leading zero.</returns>
    public double GetPerimeter()
    {
      return Math.Round((Math.PI * 2 * radius), 3);
    }

    /// <summary>
    /// Fill all circle data with random values.
    /// </summary>
    public override void InitWithRandomValues()
    {
      base.InitWithRandomValues();
      radius = rand.Next(2, 6); // random number between 2-5
                                // if somting wrong with the random values then do recusion to collect new values.
      if (CheckValidate() == false)
        InitWithRandomValues();
    }

    /// <summary>
    /// Show all details of circle in the console.
    /// </summary>
    public override void ShowDetails()
    {
      base.ShowDetails();
      Console.WriteLine("Shape Name: Circle");
      Console.WriteLine("Radius: " + Radius);
      Console.WriteLine("Area: " + GetArea());
      Console.WriteLine("Perimeter: " + GetPerimeter());
    }
    #endregion

    // private function
    private bool CheckValidate()
    {
      // checking if the square is gonna be write overflow-x or overflow-y
      if ((Y + 4 * Radius) >= 25 || (X + 4 * Radius) >= 80)
        return false;
      // to make the circle be in middle because else it will be overflow-x
      if (X > 65 || X < 10)
        return false;
      // if Y number is between 0-7 thats mean in the line of ShowDetails() function then check if the X value
      // is less than 20 (because then it will override the ShowDetails messages)
      if (Y >= 0 && Y <= 7)
      {
        if (X < 20)
          return false;
      }
      return true;
    }
  }
}
