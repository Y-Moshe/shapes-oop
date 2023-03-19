using Interfaces;

namespace Entities
{
  class HorizontalLine : BaseShape, IMathShape
  {
    #region Data-Memebers
    private int secondX;
    private int thickness;
    #endregion

    #region Ctors
    public HorizontalLine() { }

    public HorizontalLine(int x, int y, ConsoleColor color, int secondx, int thickness) : base(x, y, color)
    {
      SecondX = secondx;
      Thickness = thickness;
    }
    #endregion

    #region Property
    /// <summary>
    /// Represent the second X that the line sould be, the value sould be between 0-79!.
    /// </summary>
    public int SecondX
    {
      set
      {
        if (value < 0 || value > 79)
          throw new Exception("SecondX value must be between 0-79");
        secondX = value;
      }
      get
      {
        return secondX;
      }
    }

    /// <summary>
    /// Represent the thickness of the line, value must be between 1-3!.
    /// </summary>
    public int Thickness
    {
      set
      {
        if (value < 1 || value > 3)
          throw new Exception("Thickness value must be between 1-3");
        thickness = value;
      }
      get
      {
        return thickness;
      }
    }

    #endregion

    #region Methods
    public override string ToString()
    {
      return string.Format(base.ToString() + " {0} {1}", secondX, thickness);
    }
    /// <summary>
    /// Start drawing the horizontal line throw the console interface.
    /// </summary>
    public override void Draw()
    {
      if (CheckValidate() == false)
        InitWithRandomValues();
      Console.ForegroundColor = Color;
      if (X > secondX)
        Console.SetCursorPosition(secondX, Y);
      else
        Console.SetCursorPosition(X, Y);
      for (int i = 1; i <= thickness; i++)
      {
        Console.CursorLeft = X > secondX ? secondX : X;
        for (int j = 1; j <= GetPerimeter(); j++)
          Console.Write("*");
        Console.WriteLine();
      }
      Console.ResetColor();
    }

    /// <summary>
    /// Get the area of horizontal the line.
    /// </summary>
    /// <returns>0</returns>
    public double GetArea()
    {
      return 0;
    }

    /// <summary>
    /// Get the perimeter of the horizontal line.
    /// </summary>
    /// <returns>the length of the line.</returns>
    public double GetPerimeter()
    {
      return (X > secondX) ? X - secondX : secondX - X;
    }

    /// <summary>
    /// Fill all horizontal line with random values.
    /// </summary>
    public override void InitWithRandomValues()
    {
      base.InitWithRandomValues();
      secondX = rand.Next(0, 80); // random number between 0-79
      thickness = rand.Next(1, 4); // random number between 1-3
      if (CheckValidate() == false)
        InitWithRandomValues();
    }

    /// <summary>
    /// Show all details of the horizontal line in the console.
    /// </summary>
    public override void ShowDetails()
    {
      base.ShowDetails();
      Console.WriteLine("Shape Name: Horizontal Line.");
      Console.WriteLine("Second Point X: " + secondX);
      Console.WriteLine("Second Point Y: " + Y);
      Console.WriteLine("Area: 0");
      Console.WriteLine("Perimeter: " + GetPerimeter());
      Console.WriteLine("Thickness: " + thickness);
    }
    #endregion

    // private function.
    private bool CheckValidate()
    {
      // just to make the line seems like a real line.
      if (GetPerimeter() < 4)
        return false;
      if (X < secondX)
      {
        // because then it mean it will start write from X, so check if it is gonna write overflow-x.
        if ((X + GetPerimeter()) >= 80)
          return false;
      }
      else
      {
        // because then it mean it will start write from secondX, so check if it is gonna write overflow-x.
        if ((secondX + GetPerimeter()) >= 80)
          return false;
      }
      // check if its gonna write overflow-y
      if (thickness > 1)
      {
        if (Y + thickness >= 25)
          return false;
      }
      if (Y >= 0 && Y <= 9)
      {
        // check from where you gonna write, and check if its not gonna override the ShowDetails function.
        if ((X > secondX ? secondX : X) < 30)
          return false;
      }
      return true;
    }
  }
}