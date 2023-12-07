﻿using SharpRISCV.Core.V2.LexicalAnalysis.Abstraction;
using SharpRISCV.Core.V2.LexicalToken.Abstraction;
using System.Text.RegularExpressions;

namespace SharpRISCV.Core.V2.LexicalAnalysis
{
    public abstract class LexerBase : ILexer
    {
        public string Text { get; protected set; } = string.Empty;
        protected LexerBase(string text)
        {
            Text = text;
            Text = Regex.Replace(Text, Pattern.Comment, string.Empty, RegexOptions.Multiline);
        }

        public virtual IEnumerable<IToken> Tokenize() => throw new NotImplementedException();

        public virtual IToken GetNextToken() => throw new NotImplementedException();
        public virtual void Reset() => throw new NotImplementedException();
    }
}
