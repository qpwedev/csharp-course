using System;
using System.Collections.Generic;

namespace csharp{
    public class LineConstructor{
        List<string> wordsList;
        int charCount;
        int wordCount;
        int maxCharOnLine;
        char spaceSymbol;

        public LineConstructor(int maxCharOnLine, char spaceSymbol){
            this.maxCharOnLine = maxCharOnLine;
            this.spaceSymbol = spaceSymbol;
            wordsList = new List<string>();
            WordCount = 0;
            charCount = 0;
        }
    
        int SpaceCount{ 
            get { return (WordCount <= 1 ? 0 : WordCount-1); }
        }

        public int WordCount{
            get { return wordCount; }
            set { wordCount = value; }
        }

        public int MaxCharOnLine{ 
            set { maxCharOnLine = value; }
            get { return maxCharOnLine; }
        }

        public int ActualLineLength{ 
            get { return charCount + SpaceCount; }
        }

        void resetForNewLine(){
            wordsList.Clear();
            charCount = 0;
            wordCount = 0;
        }

        public bool canAddNewWord(int length){
            if (WordCount == 0 && length <= MaxCharOnLine) return true;
            if (ActualLineLength + length + 1 <= MaxCharOnLine) return true;
            return false;
        }

        public string returnLine(){
            var line = String.Join(spaceSymbol, wordsList.ToArray());
            resetForNewLine();
            return line;
        }

        public string returnProccesedLine(){
            string preparedLine;
            if (ActualLineLength >= MaxCharOnLine || SpaceCount == 0) {
                return returnLine();
            }
            
            var defaultSpacesCount = (MaxCharOnLine - ActualLineLength) / SpaceCount;
            var extraSpacesCount = (MaxCharOnLine - ActualLineLength) % SpaceCount;

            for (int i = 0; i < extraSpacesCount; ++i) {
                wordsList[i] += spaceSymbol;
            }

            var defaultSpaces = new string(spaceSymbol, defaultSpacesCount+1);
            preparedLine = String.Join(defaultSpaces, wordsList.ToArray());
            resetForNewLine();
            return preparedLine;
        }

        public void addWord(string word) { 
            ++WordCount;
            charCount += word.Length;
            wordsList.Add(word); 
        } 
    }
}