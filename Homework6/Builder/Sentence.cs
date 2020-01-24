using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.Builder
{
    public class Sentence
    {
        public const short WITH_VOVELS = 1;
        public const short WITH_CONSONANTS = 2;
        public const short WITH_SYMBOLS = 4;
        public const short START_WITH_UCASE = 8;
        public const short END_WITH_POINT = 16;
        string VowelChars = "уеыаоэяиюё";
        string ConsonantChars = "йцкнгшщзхфвпрлджчсмтб";
        string SymbolChars = "ьъ";
        Random Rand = new Random();

        public string GetText(int Length, short Flags) 
        {
            string[] Sentences = new string[Length];
            int SentenceLenth;
            for (int i = 0; i < Length; i++)
            {
                SentenceLenth = Rand.Next(4, 10);
                Sentences[i] = GetSentence(SentenceLenth, Flags);
            }

            return String.Join(" ", Sentences);
        }
        public string GetSentence(int Length, short Flags)
        {
            string[] Words = new string[Length];
            bool LastWordIsShort = false;
            int WordLenth;
            for (int i = 0; i < Length; i++) 
            {
                WordLenth = LastWordIsShort ? Rand.Next(4, 10) : Rand.Next(1, 10);
                Words[i] = GetWord(WordLenth, 0);
            }

            return FormatString(String.Join(" ", Words), Flags);
        }
        public string GetWord(int Length, short Flags) 
        {
            bool 
                LastIsConsonant = false,
                LastIsSymbol = false,
                PreLastIsConsonant = false
                ;
            short flags;
            StringBuilder WordBuilder = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                flags = WITH_VOVELS;
                if (!(PreLastIsConsonant && LastIsConsonant) && !LastIsSymbol) 
                {
                    flags |=  WITH_CONSONANTS | WITH_SYMBOLS;
                }
                char NewChar = GetChar(flags);
                WordBuilder.Append(NewChar);
                PreLastIsConsonant = LastIsConsonant;
                LastIsConsonant = ConsonantChars.Contains(NewChar);
                LastIsSymbol = SymbolChars.Contains(NewChar);
            }

            return FormatString(WordBuilder.ToString(), Flags);
        }
        public char GetChar(short Flags) 
        {
            var Source = GetSource(Flags);
            return Source[Rand.Next(0, Source.Length)];
        }
         public char GetChar() 
        {
            return GetChar(WITH_VOVELS | WITH_CONSONANTS | WITH_SYMBOLS);
        }
        private string FormatString(string Input, short Flags) 
        {
            if ((Flags & END_WITH_POINT) == END_WITH_POINT)
            {
                Input += '.';
            }
            if ((Flags & START_WITH_UCASE) == START_WITH_UCASE)
            {
                Input = Input.Substring(0, 1).ToUpperInvariant() + Input.Substring(1);
            }

            return Input;
        }
        private string GetSource(short Flags)
        {
            StringBuilder SourceBuilder = new StringBuilder();
            if ((Flags & WITH_VOVELS) == WITH_VOVELS)
                SourceBuilder.Append(VowelChars);
            {
            }
            if ((Flags & WITH_CONSONANTS) == WITH_CONSONANTS)
            {
                SourceBuilder.Append(ConsonantChars);
            }
            if ((Flags & WITH_SYMBOLS) == WITH_SYMBOLS)
            {
                SourceBuilder.Append(SymbolChars);
            }

            return SourceBuilder.ToString();
        }
    }
}
