using System;
using System.Collections.Generic;
using System.Text;
using static Brainfuck.Tokenizer;

namespace Brainfuck
{
    public class Parser
    {
        public static RootAST Parse(List<Token> tokens)
        {
            RootAST result = new RootAST();

            RootAST currentLoop = result;
            foreach (var token in tokens)
            {
                switch (token)
                {
                    case Token.Plus:
                        currentLoop.Children.Add(new ExprAST(Token.Plus));
                        break;
                    case Token.Minus:
                        currentLoop.Children.Add(new ExprAST(Token.Minus));
                        break;
                    case Token.PRight:
                        currentLoop.Children.Add(new ExprAST(Token.PRight));
                        break;
                    case Token.PLeft:
                        currentLoop.Children.Add(new ExprAST(Token.PLeft));
                        break;
                    case Token.Output:
                        currentLoop.Children.Add(new ExprAST(Token.Output));
                        break;
                    case Token.Input:
                        currentLoop.Children.Add(new ExprAST(Token.Input));
                        break;
                    case Token.LoopOpen:
                        var loop = new LoopAST();
                        loop.Parent = currentLoop;
                        currentLoop.Children.Add(loop);
                        currentLoop = loop;
                        break;
                    case Token.LoopClose:
                        currentLoop = currentLoop.Parent;
                        break;
                }
            }

            return result;
        }
    }
}
