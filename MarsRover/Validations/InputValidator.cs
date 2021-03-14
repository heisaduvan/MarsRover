using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public static class InputValidator
    {
        public static bool CheckMapCoords(string input, out int upperRightX, out int upperRightY)
        {
            var mapCoords = input.Split(' ');

            upperRightX = 0;
            upperRightY = 0;

            if (mapCoords.Length < 2)
            {
                Console.WriteLine("Hatalı giriş yaptınız. Tekrar Deneyiniz.");
                return false;
            }

            bool isCorrectInputX = int.TryParse(mapCoords[0], out  upperRightX);
            bool isCorrectInputY = int.TryParse(mapCoords[1], out  upperRightY);

            if (!(isCorrectInputX && isCorrectInputY))
            {
                Console.WriteLine("Koordinat değerleri integer olabilir.");
                return false;
            }

            if(upperRightX < 0 || upperRightY < 0)
            {
                upperRightX = 0;
                upperRightY = 0;

                Console.WriteLine("Koordinat değerleri negatif olamaz.");
                return false;
            }

            return true;
        }

        public static bool CheckRoverCoordsAndDirection(string _input, out int x, out int y, out Direction direction)
        {
            direction = Direction.N;

            if (CheckMapCoords(_input,out x, out y))
            {
                var inputDirection = _input.Split(' ')[2];

                if(!Enum.TryParse(inputDirection, out direction))
                {
                    Console.WriteLine("Yön değeri geçersiz. Tekrar Deneyin");
                    return false;
                }
                return true;
            }

            return false;
        }

        public static bool CheckMoveCommands(string input)
        {
            var inputChars = input.ToCharArray();

            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Hareket komutu girmediniz.");
                return false;
            }

            foreach(char value in inputChars)
            {
                if(!Enum.TryParse(value.ToString(),out MoveCommand moveCommand))
                {
                    Console.WriteLine("Komut değeri geçersiz. Tekrar deneyin. Sadece L, R, M değerleri olabilir.");
                    return false;
                }
            }

            return true;
        }
    }
}
