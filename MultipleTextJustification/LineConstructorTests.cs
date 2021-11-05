/* using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextJustificator;
using System.Text;

namespace LineConstructorTests {
    [TestClass]
    public class LineConstructorTests {
        [TestMethod]
        public void LineConstructor_EmptyInput_returnProccesedLine() {
            var lineConstructor = new LineConstructor(10, ' ');

            Assert.AreEqual("",lineConstructor.returnProccesedLine());
        }

        [TestMethod]
        public void LineConstructor_EmptyInput_returnLine() {
            var lineConstructor = new LineConstructor(10, ' ');

            Assert.AreEqual("", lineConstructor.returnLine());
        }

        [TestMethod]
        public void LineConstructor_OneWord() {
            var words = new[] { "The" };

            var lineConstructor = new LineConstructor(10, ' ');

            var output = "";

            foreach (var word in words) {
                if (lineConstructor.canAddNewWord(word.Length)) {
                    output += lineConstructor.returnProccesedLine();
                }
                lineConstructor.addWord(word);
            }
            var lastLine = lineConstructor.returnProccesedLine();
            if (lastLine != "") {
                output += lastLine;
            }

            var correctOutput = "The";
            Assert.AreEqual(correctOutput, output);
        }

        [TestMethod]
        public void LineConstructor_OneWordWithLengthOne() {
            var words = new[] { "The" };

            var lineConstructor = new LineConstructor(1, ' ');

            var output = "";

            foreach (var word in words) {
                if (lineConstructor.canAddNewWord(word.Length)) {
                    output += lineConstructor.returnProccesedLine();
                }
                lineConstructor.addWord(word);
            }
            var lastLine = lineConstructor.returnProccesedLine();
            if (lastLine != "") {
                output += lastLine;
            }

            var correctOutput = "The";
            Assert.AreEqual(correctOutput, output);
        }

        [TestMethod]
        public void LineConstructor_TwoWordsWithLengthOne() {
            var words = new[] { "The", "most" };

            var lineConstructor = new LineConstructor(1, ' ');

            var output = "";

            foreach (var word in words) {
                if (lineConstructor.canAddNewWord(word.Length)) {
                    output += lineConstructor.returnProccesedLine();
                }
                lineConstructor.addWord(word);
            }
            var lastLine = lineConstructor.returnProccesedLine();
            if (lastLine != "") {
                output += lastLine;
            }

            var correctOutput = "The most";
            Assert.AreEqual(correctOutput, output);
        }


        [TestMethod]
        public void LineConstructor_SimpleExampleWIth10Chars() {
            var words = new[] { "The", "rain", "in", "Spain", "falls", "mainly", "on", "the", "plain." };

            var lineConstructor = new LineConstructor(10, ' ');

            var output = "";

            foreach (var word in words) {
                if (lineConstructor.canAddNewWord(word.Length)) {
                    output += lineConstructor.returnProccesedLine();
                }
                lineConstructor.addWord(word);
            }
            var lastLine = lineConstructor.returnProccesedLine();
            if (lastLine != "") {
                output += lastLine;
            }

            var correctOutput = "TheraininSpain falls mainly on the plain.";
            Assert.AreEqual(correctOutput, output);
        }
    }
}

/**/