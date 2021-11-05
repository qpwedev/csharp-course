using System;

namespace csharp {
    class Program {
        static void Main(string[] args){
            
            if (args.Length != 3) {
                Console.WriteLine("Argument Error");
                return;
            }

            int maxCharOnLine = 0;
            bool isNumerical = int.TryParse(args[2], out maxCharOnLine);

            if (!isNumerical || maxCharOnLine <= 0){
                Console.WriteLine("Argument Error");
                return;
            }

            var Justificator = new TextJustificator(args[0], args[1], maxCharOnLine);
            Justificator.justificateText();
        }
    }
}