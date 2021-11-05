using System;
using System.IO;

namespace csharp{
    public class TextJustificator{

        string inputFile;
        string outputFile;
        int maxCharOnLine;

        public int MaxCharOnLine{ 
            set { maxCharOnLine = value; }
            get { return maxCharOnLine; }
        }

        public TextJustificator(string inputFile, string outputFile, int maxCharOnLine){
            this.inputFile = inputFile;
            this.outputFile = outputFile;
            this.MaxCharOnLine = maxCharOnLine;
        }
        
        public void justificateText(){
            var LineConstructor = new LineConstructor(MaxCharOnLine);
            
            try {
                var WordReader = new WordReader(inputFile);
                using var OutputFile = new StreamWriter(outputFile);

                string word;
                bool paragraph = false;
                while ((word = WordReader.readWord())!= ""){
                    if (word == "\n"){
                        var line = LineConstructor.returnLine();
                        if (line != ""){
                            if (paragraph)
                                OutputFile.WriteLine('\n'+line);
                            else
                                OutputFile.WriteLine(line);
                            paragraph = true;
                        }
                        continue;
                    }

                    if (!LineConstructor.canAddNewWord(word.Length)){
                        if (paragraph){
                            if (LineConstructor.WordCount != 0){
                                OutputFile.WriteLine('\n'+LineConstructor.returnProccesedLine());
                                paragraph = false;
                            }
                        } 
                        else{
                            if (LineConstructor.WordCount != 0){
                                OutputFile.WriteLine(LineConstructor.returnProccesedLine());
                            }
                        }
                    }

                    LineConstructor.addWord(word);
                }
                if (LineConstructor.WordCount != 0){
                    if (paragraph)
                        OutputFile.WriteLine('\n'+LineConstructor.returnLine());
                    else 
                        OutputFile.WriteLine(LineConstructor.returnLine());
                }
                
            } 
            catch {
                Console.WriteLine("File Error");
            }  
        }
    }
}