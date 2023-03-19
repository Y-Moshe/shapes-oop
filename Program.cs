internal class Program
{
  private static void Main(string[] args)
  {
    ScreenSaver.EventInMiddle += delegate () { Console.Beep(); };
    ScreenSaver.Start();
  }
}