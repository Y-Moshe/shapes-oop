namespace Entities
{
  abstract class BaseShape
  {
    private static int ID = 1; // default ID start from 1
    #region Data-Members
    public int id;
    private int x;
    private int y;
    protected Random rand = new Random();
    public ConsoleColor Color;
    #endregion

    #region Ctors
    public BaseShape()
    {
      id = ID++;
    }

    public BaseShape(int x, int y, ConsoleColor color) : this()
    {
      X = x;
      Y = y;
      Color = color;
    }
    #endregion

    #region Properties
    /// <summary>
    /// represents the horizontal position of the shape, value must be between 0-79!.
    /// </summary>
    public int X
    {
      set
      {
        // Check if the X value is more than 79 or less than 0 because then its out of the console.
        if (value < 0 || value > 79)
          throw new Exception("X must be between 0-79");
        x = value;
      }
      get
      {
        return x;
      }
    }

    /// <summary>
    /// represents the vertical position of the shape, the value must be between 0-24!.
    /// </summary>
    public int Y
    {
      set
      {
        // Check if the Y value is more than 24 or less than 0 because then its out of the console.
        if (value < 0 || value > 24)
          throw new Exception("Y must be between 0-24");
        y = value;
      }
      get
      {
        return y;
      }
    }
    #endregion

    #region Methods
    public override int GetHashCode()
    {
      return id;
    }

    public override bool Equals(object obj)
    {
      return GetHashCode() == obj.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format("{0} {1} {2}", x, y, Color);
    }
    /// <summary>
    /// Fill all data with random values.
    /// </summary>
    public virtual void InitWithRandomValues()
    {
      // insert random intger number to X and Y
      x = rand.Next(0, 80); // number between 0-79
      y = rand.Next(0, 25); // number between 0-24
      Color = (ConsoleColor)rand.Next(1, 16);
    }

    /// <summary>
    /// Show all the details about the current shape.
    /// </summary>
    public virtual void ShowDetails()
    {
      // SetCursorPosition to make it write in TOP LEFT(0, 0)
      Console.SetCursorPosition(0, 0);
      Console.WriteLine("X: " + x);
      Console.WriteLine("Y: " + y);
      Console.WriteLine("Color: " + Color);
    }

    /// <summary>
    /// Start drawing the current shape in the console interface.
    /// </summary>
    public abstract void Draw();
    #endregion
  }
}
