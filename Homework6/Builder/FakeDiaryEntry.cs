using Homework6.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.Builder
{
    public class FakeDiaryEntry
    {
        private int LastIndex = 0;
        Random Rand = new Random();
        public FakeDiaryEntry(Sentence sentenceBuilder) {
            SentenceBuilder = sentenceBuilder;
        }

        public Sentence SentenceBuilder { get; }

        public DiaryEntry Builder() 
        {
            DiaryEntry entry = new DiaryEntry();
            entry.Num = ++LastIndex;
            entry.Title = SentenceBuilder.GetSentence(Rand.Next(1, 4), Sentence.START_WITH_UCASE);
            entry.Description = SentenceBuilder.GetText(Rand.Next(2, 6), Sentence.START_WITH_UCASE | Sentence.END_WITH_POINT);
            entry.Createdon = DateTime.Now.AddDays(-Rand.Next(0, 10)).AddHours(-Rand.Next(0, 10)).AddMinutes(-Rand.Next(0, 10)).AddSeconds(-Rand.Next(0, 10)).AddMilliseconds(-Rand.Next(0, 10));
            entry.Priority = Rand.Next(1, 20);

            return entry;
        }
        
    }
}
