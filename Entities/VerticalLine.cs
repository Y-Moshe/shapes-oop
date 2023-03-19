using Interfaces;

namespace Entities
{
  class VerticalLine : BaseShape, IMathShape
  {
    #region Data-Memebers
    private int secondY;
    private int thickness;
    #endregion

    #region Ctors
    public VerticalLine() { }

    public VerticalLine(int x, int y, ConsoleColor color, int secondy, int thickness) : base(x, y, color)
    {
      SecondY = secondy;
      Thickness = thickness;
    }
    #endregion

    #region Property
    /// <summary>
    /// Represent the second Y that the line sould be, the value must be between 0-24!.
    /// </summary>
    public int SecondY
    {
      set
      {
        if (value < 0 || value > 25)
          throw new Exception("SecondY value must be between 0-25");
        secondY = value;
      }
      get
      {
        return secondY;
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
      return string.Format(base.ToString() + " {0} {1}", secondY, thickness);
    }
    /// <summary>
    /// Start drawing the vertical line throw the console interface.
    /// </summary>
    public override void Draw()
    {
      if (CheckValidate() == false)
        InitWithRandomValues();
      Console.ForegroundColor = Color;
      if (Y > secondY)
        Console.SetCursorPosition(X, secondY);
      else
        Console.SetCursorPosition(X, Y);
      for (int i = 1; i <= GetPerimeter(); i++)
      {
        Console.CursorLeft = X;
        for (int j = 1; j <= thickness; j++)
          Console.Write("*");
        Console.WriteLine();
      }
      Console.ResetColor();
    }

    /// <summary>
    /// Get the area of the vertical line.
    /// </summary>
    /// <returns>0</returns>
    public double GetArea()
    {
      return 0;
    }

    /// <summary>
    /// Get the perimeter of the vertical line.
    /// </summary>
    /// <returns>the length of the line.</returns>
    public double GetPerimeter()
    {
      return (Y > secondY) ? Y - secondY : secondY - Y;
    }

    /// <summary>
    /// Fill all vertical line with random values.
    /// </summary>
    public override void InitWithRandomValues()
    {
      base.InitWithRandomValues();
      secondY = rand.Next(0, 25); // random number between 0-24
      thickness = rand.Next(1, 4); // random number between 1-3
      if (CheckValidate() == false)
        InitWithRandomValues();
    }

    /// <summary>
    /// Show all details of the vertical line in the console.
    /// </summary>
    public override void ShowDetails()
    {
      base.ShowDetails();
      Console.WriteLine("Shape Name: Vertical Line");
      Console.WriteLine("Second Point Y: " + secondY);
      Console.WriteLine("Second Point X: " + X);
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
      if (Y < secondY)
      {
        // thats mean its gonna start write from Y, check if its gonna be write overflow-y
        if ((Y + GetPerimeter()) >= 25)
          return false;
      }
      else
      {
        // thats mean its gonna start write from secondY, check if its gonna be write overflow-y
        if (secondY + GetPerimeter() >= 25)
          return false;
      }
      // check if thickness is more than 1 becase then need to check if its gonna be write overflow-x
      if (thickness > 1)
      {
        if (X + thickness >= 80)
          return false;
      }
      // get from where its gonna start writing
      int num = Y < secondY ? Y : secondY;
      // then check if it is between 0-9 (in ShowDetails function message)
      if (num >= 0 && num <= 9)
      {
        // then check if its gonna be override ShowDetails function messages.
        if (X < 30)
          return false;
      }
      return true;
    }
  }
}
