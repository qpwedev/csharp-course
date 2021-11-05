using System;
using System.IO;

namespace csharp{
    public class TextJustificator{

        string[] inputFiles;
        string outputFile;
        int maxCharOnLine;
        string newlineSymbol;
        char spaceSymbol;

        public int MaxCharOnLine{ 
            set { maxCharOnLine = value; }
            get { return maxCharOnLine; }
        }

        public TextJustificator(string[] inputFiles, string outputFile, int maxCharOnLine, string newlineSymbol, char spaceSymbol){
            this.inputFiles = inputFiles;
            this.outputFile = outputFile;
            this.MaxCharOnLine = maxCharOnLine;
            this.newlineSymbol = newlineSymbol;
            this.spaceSymbol = spaceSymbol;
        }
        
        public void justificateText(){
            var LineConstructor = new LineConstructor(MaxCharOnLine, spaceSymbol);
    
            try {
                using var OutputFile = new StreamWriter(outputFile);
                string word;
                bool paragraph = false;
                var WordReader = new WordReader();

                foreach (var file in inputFiles){
                    if (!File.Exists(file)){ continue; }
                    WordReader.setSource(file);

                    while ((word = WordReader.readWord())!= ""){
                        if (word == "\n"){
                            var line = LineConstructor.returnLine();
                            if (line != ""){
                                if (paragraph)
                                    OutputFile.WriteLine(newlineSymbol+'\n'+line+newlineSymbol);
                                else
                                    OutputFile.WriteLine(line+newlineSymbol);
                                paragraph = true;
                            }
                            continue;
                        }

                        if (!LineConstructor.canAddNewWord(word.Length)){
                            if (paragraph){
                                if (LineConstructor.WordCount != 0){
                                    OutputFile.WriteLine(newlineSymbol+'\n'+LineConstructor.returnProccesedLine()+newlineSymbol);
                                    paragraph = false;
                                }
                            } 
                            else{
                                if (LineConstructor.WordCount != 0){
                                    OutputFile.WriteLine(LineConstructor.returnProccesedLine()+newlineSymbol);
                                }
                            }
                        }

                        LineConstructor.addWord(word);
                    }
                }
                
                if (LineConstructor.WordCount != 0){
                    if (paragraph)
                        OutputFile.WriteLine(newlineSymbol+'\n'+LineConstructor.returnLine()+newlineSymbol);
                    else 
                        OutputFile.WriteLine(LineConstructor.returnLine()+newlineSymbol);
                }
            } 
            catch {
                Console.WriteLine("File Error");
            }  
        }
    }
}