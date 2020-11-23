using System;
using System.Collections.Generic;
using Xunit;
using static Brainfuck.Tokenizer;

namespace Brainfuck.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void BasicParse()
        {
            var input = "+-,.[]<>";
            List<Token> expected = new List<Token>(new Token[] { Token.Plus, Token.Minus, Token.Input, Token.Output, Token.LoopOpen, Token.LoopClose, Token.PLeft, Token.PRight });

            Assert.Equal(expected, Tokenizer.Tokenize(input));

            input = "++--";
            expected = new List<Token>(new Token[] { Token.Plus, Token.Plus, Token.Minus, Token.Minus });

            Assert.Equal(expected, Tokenizer.Tokenize(input));
        }

        [Fact]
        public void IgnoreUselessParse()
        {
            var input = "+-,.[]<>abcd;:efg";
            List<Token> expected = new List<Token>(new Token[] { Token.Plus, Token.Minus, Token.Input, Token.Output, Token.LoopOpen, Token.LoopClose, Token.PLeft, Token.PRight });

            Assert.Equal(expected, Tokenizer.Tokenize(input));

            input = "++rawr123--";
            expected = new List<Token>(new Token[] { Token.Plus, Token.Plus, Token.Minus, Token.Minus });

            Assert.Equal(expected, Tokenizer.Tokenize(input));
        }
    }
}
