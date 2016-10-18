using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpdCalculator
{
    public class Program
    {
        private double realIpd;

        private double virtualIpd;

        private double distanceFromScreen;

        private double desiredVirtualDistance;

        private double addedDistance;

        private double angle;

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            Console.WriteLine("Inter-pupillary distance calculator for virtual reality games (3D Vision etc).");
            Console.WriteLine("Use same unit of measurement for all distance entered. (q for quit)");

            realIpd = ReadDouble("Inter-pupillary distance");
            distanceFromScreen = ReadDouble("Distance from screen");

            while (true)
            {
                desiredVirtualDistance = ReadDouble("Desired virtual distance");
                addedDistance = desiredVirtualDistance - distanceFromScreen;
                angle = GetRectangleTriangleAngle(realIpd / 2f, desiredVirtualDistance);
                virtualIpd = GetRectangleTriangleWidth(addedDistance, angle) * 2f;

                Console.WriteLine("Ipd on screen: " + virtualIpd);
            }
        }

        private double GetRectangleTriangleAngle(double width, double height)
        {
            return Math.Atan(height / width);
        }

        private double GetRectangleTriangleWidth(double height, double angle)
        {
            return height / Math.Tan(angle);
        }

        private double ReadDouble(string text)
        {
            double doubleValue;
            string input;
            do
            {
                Console.WriteLine(text);
                input = Console.ReadLine();
                if (input.ToLowerInvariant().StartsWith("q"))
                {
                    Environment.Exit(0);
                }
            } while (!double.TryParse(input, out doubleValue));
            return doubleValue;
        }
    }
}
