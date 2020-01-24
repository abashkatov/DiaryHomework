using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.Entity
{
    [Serializable]
    public class DiaryEntry
    {
        public int Num { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public int Priority { get; set; }
        public DiaryEntry() 
        {
            Createdon = DateTime.Now;
        }
        public Object this[string Field]
        {
            get
            {
                switch (Field)
                {
                    case "Title":
                        return Title;
                    case "Description":
                        return Description;
                    case "Createdon":
                        return Createdon;
                    case "Priority":
                        return Priority;
                    case "Num":
                        return Num;
                    default:
                        return null;
                }
            }
        }
    }
}
