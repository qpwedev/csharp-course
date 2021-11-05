using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace csharp {
    public class WordReader {
        StreamReader source;
        bool NewLineBefore;
        
        public WordReader(string inputFile){
            this.source = new StreamReader(inputFile);
            NewLineBefore = false;
        }

        public string readWord(){
            string word = "";
            int char_;
            
            while ((char_ = source.Read()) != -1) {
                if ((char_ == '\n' || char_ == '\t' || char_== ' ') && NewLineBefore){
                    if (char_ == '\n'){
                        NewLineBefore = false;
                        return "\n";
                    }
                    continue;
                } 
                NewLineBefore = (char_ == '\n') ? true : false;
                
                if (char_ != '\n' && char_ != '\t' && char_ != ' ')
                    word += (char) char_;
                else if (word != ""){
                    return word;
                }
            }

            return word;
        }
    }
}