using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Game
{
    public class GEventLocation
    {
        public static BaseClasses.СEventLocation EventLocation;

        public static void init()
        {
            EventLocation = new СEventLocation();
        }
    }
}