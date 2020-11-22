using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck
{
    class Tokenizer
    {
        enum Token
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

        List<Token> Tokenize(string text)
        {
            List<Token> result = new List<Token>();
        }
    }
}
