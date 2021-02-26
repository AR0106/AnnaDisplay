using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace AnnaDisplay.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new AnnaDisplay.App(), args);
            host.Run();
        }
    }
}
