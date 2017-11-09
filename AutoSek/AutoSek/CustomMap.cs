using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace AutoSek
{
    public class CustomMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }

        public CustomMap()
        {

            RouteCoordinates = new List<Position>();
        }

        public List<CustomPin> CustomPins { get; set; }

    }

   

}
