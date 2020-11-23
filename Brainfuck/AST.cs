using System;
using System.Collections.Generic;
using System.Linq;

namespace Brainfuck
{
    public class RootAST : IEquatable<RootAST>
    {
        public List<RootAST> Children;
        public RootAST Parent;

        public RootAST()
        {
            Children = new List<RootAST>();
        }

        public RootAST(List<RootAST> children)
        {
            Children = children ?? throw new ArgumentNullException(nameof(children));
        }

        public RootAST(List<RootAST> children, RootAST parent) : this(children)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RootAST);
        }

        public bool Equals(RootAST other)
        {
            return other != null &&
                  Children.SequenceEqual(other.Children);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Children, Parent);
        }

        public static bool operator ==(RootAST left, RootAST right)
        {
            return EqualityComparer<RootAST>.Default.Equals(left, right);
        }

        public static bool operator !=(RootAST left, RootAST right)
        {
            return !(left == right);
        }
    }

    public class ExprAST : RootAST, IEquatable<ExprAST>
    {
        public Tokenizer.Token Type;

        public ExprAST(Tokenizer.Token type) : base()
        {
            Type = type;
        }

        public ExprAST(List<RootAST> children) : base(children)
        {

        }

        public ExprAST(Tokenizer.Token type, List<RootAST> children) : base(children)
        {
            Type = type;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ExprAST);
        }

        public bool Equals(ExprAST other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Type == other.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Type);
        }

        public static bool operator ==(ExprAST left, ExprAST right)
        {
            return EqualityComparer<ExprAST>.Default.Equals(left, right);
        }

        public static bool operator !=(ExprAST left, ExprAST right)
        {
            return !(left == right);
        }
    }
    public class LoopAST : RootAST, IEquatable<LoopAST>
    {
        public LoopAST() : base()
        {

        }
        public LoopAST(List<RootAST> children) : base(children)
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LoopAST);
        }

        public bool Equals(LoopAST other)
        {
            return other != null &&
                   base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(LoopAST left, LoopAST right)
        {
            return EqualityComparer<LoopAST>.Default.Equals(left, right);
        }

        public static bool operator !=(LoopAST left, LoopAST right)
        {
            return !(left == right);
        }
    }
}
