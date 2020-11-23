using System.Collections.Generic;
using Xunit;
using static Brainfuck.Parser;
using static Brainfuck.Tokenizer;

namespace Brainfuck.Tests
{
    public class ParserTests
    {
        [Fact]
        public void BasicParse()
        {
            var input = "+++-[-]";
            var tokens = Tokenizer.Tokenize(input);
            RootAST expected = new RootAST
            {
                Children = new List<RootAST>(new RootAST[] {
                new ExprAST(Token.Plus),
                new ExprAST(Token.Plus),
                new ExprAST(Token.Plus),
                new ExprAST(Token.Minus),
                new LoopAST(new List<RootAST>(new RootAST[] { new ExprAST(Token.Minus) }))
            })
            };

            Assert.Equal(expected, Parser.Parse(tokens));
        }

        [Fact]
        public void ASTComparsion()
        {
            var left = new ExprAST(Token.Plus);
            var right = new ExprAST(Token.Plus);
            Assert.Equal(left, right);

            var left1 = new RootAST(new List<RootAST>(new RootAST[] { new ExprAST(Token.Plus), new LoopAST(new List<RootAST>(new RootAST[] { new ExprAST(Token.Plus) })) }));
            var right1 = new RootAST(new List<RootAST>(new RootAST[] { new ExprAST(Token.Plus), new LoopAST(new List<RootAST>(new RootAST[] { new ExprAST(Token.Plus) })) }));
            Assert.Equal(left1, right1);

            Assert.NotEqual(left, left1);
        }
    }
}
