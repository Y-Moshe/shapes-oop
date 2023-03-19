using Entities;

delegate void MiddleHandler();

abstract class ScreenSaver
{
  public static event MiddleHandler EventInMiddle;

  public static void Start()
  {
    Random rand = new Random();
    BaseShape[] shapes = {
      new Square(),
      new Rectangle(),
      new Circle(),
      new HorizontalLine(),
      new VerticalLine()
    };

    try
    {
      do
      {
        int computerChose = rand.Next(shapes.Length);
        BaseShape currentShape = shapes[computerChose];
        currentShape.InitWithRandomValues();
        currentShape.Draw();
        Thread.Sleep(500);
        currentShape.ShowDetails();
        Thread.Sleep(500);

        // 11 || 13 because 25/2 is not intger, so just check if it close by Y.
        if (currentShape.X == 40 && (currentShape.Y == 13 || currentShape.Y == 11))
          EventInMiddle?.Invoke();

        Console.Clear();
      } while (!Console.KeyAvailable); // if the user click some button stop the loop.
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
}
