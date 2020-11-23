using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck
{
    public class Tokenizer
    {
        public enum Token
        {
            Plus,
            Minus,
            PRight,
            PLeft,
            Output,
            Input,
            LoopOpen,
            LoopClose
        }

        public static List<Token> Tokenize(string text)
        {
            List<Token> result = new List<Token>();
            
            foreach (char i in  text)
            {
                switch (i)
                {
                    case '+':
                        result.Add(Token.Plus);
                        break;
                    case '-':
                        result.Add(Token.Minus);
                        break;
                    case '>':
                        result.Add(Token.PRight);
                        break;
                    case '<':
                        result.Add(Token.PLeft);
                        break;
                    case '.':
                        result.Add(Token.Output);
                        break;
                    case ',':
                        result.Add(Token.Input);
                        break;
                    case '[':
                        result.Add(Token.LoopOpen);
                        break;
                    case ']':
                        result.Add(Token.LoopClose);
                        break;

                }
            }

            return result;
        }
    }
}
