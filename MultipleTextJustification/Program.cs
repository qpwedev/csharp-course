using System;

namespace csharp {
    class Program {
        static void Main(string[] args){
            
            if (args.Length < 3) {
                Console.WriteLine("Argument Error");
                return;
            }

            int maxCharOnLine = 0;
            bool isNumerical = int.TryParse(args[args.Length-1], out maxCharOnLine);

            if (!isNumerical || maxCharOnLine <= 0){
                Console.WriteLine("Argument Error");
                return;
            }
            
            char spaceSymbol = ' ';
            string newlineSymbol = "";
            string[] files;
            if (args[0] == "--highlight-spaces"){
                spaceSymbol = '.';
                newlineSymbol = "<-";
                files = new ArraySegment<string>(args,1,args.Length-3).ToArray();
            }
            else{
                files = new ArraySegment<string>(args,0,args.Length-2).ToArray();
            }

            var Justificator = new TextJustificator(files, args[args.Length-2], maxCharOnLine, newlineSymbol, spaceSymbol);
            Justificator.justificateText();
        }
    }
}