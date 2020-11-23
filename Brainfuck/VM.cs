using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Brainfuck.Tokenizer;

namespace Brainfuck
{
    class ExtendedList
    {
        private List<byte> positives = new List<byte>(Enumerable.Range(0, 65536).Select(x => (byte)0));
        private List<byte> negatives = new List<byte>(Enumerable.Range(0, 65536).Select(x => (byte)0));
        public byte this[int index]
        {
            get { return index >= 0 ? positives[index] : negatives[1 - index]; }
            set { if (index >= 0) { positives[index] = value; } else { negatives[0 - index] = value; } }
        }

    }
    public static class VM
    {

        public static void Execute(string program)
        {
            var tokens = Tokenize(program);
            var ast = Parser.Parse(tokens);

            ExtendedList memory = new ExtendedList();
            int memoryPointer = 0;

            bool finished = false;
            List<(RootAST Node, int Instruction)> loopStack = new List<(RootAST, int)>();
            loopStack.Add((ast, 0));
            while (!finished)
            {
                var currentLoop = loopStack[^1]; 
                for (var i = currentLoop.Instruction; i < currentLoop.Node.Children.Count; i++)
                {
                    if (currentLoop.Node.Children[i].GetType() == typeof(ExprAST))
                    {
                        var currExpr = currentLoop.Node.Children[i] as ExprAST;

                        switch (currExpr.Type)
                        {
                            case Token.Plus:
                                memory[memoryPointer] += 1;
                                break;
                            case Token.Minus:
                                memory[memoryPointer] -= 1;
                                break;
                            case Token.PRight:
                                memoryPointer += 1;
                                break;
                            case Token.PLeft:
                                memoryPointer -= 1;
                                break;
                            case Token.Output:
                                Console.Write((char) memory[memoryPointer]);
                                break;
                            case Token.Input:
                                memory[memoryPointer] = (byte)Console.Read();
                                break;
                        }
                        continue;
                    }
                    else
                    {
                        if (memory[memoryPointer] == 0)
                        {
                            continue;
                        }

                        var currExpr = currentLoop.Node.Children[i] as LoopAST;

                        loopStack[^1] = (loopStack[^1].Node, i);
                        loopStack.Add((currExpr, 0));
                        break;
                    }
                }

                if (loopStack.Count > 1)
                {
                    if (memory[memoryPointer] != 0)
                    {
                        loopStack[^1] = (loopStack[^1].Node, 0);
                        continue;
                    }
                    
                    loopStack.RemoveAt(loopStack.Count - 1);
                    currentLoop = loopStack[^1];
                }
                else
                {
                    finished = true;
                }
            }
        }
    }
}
