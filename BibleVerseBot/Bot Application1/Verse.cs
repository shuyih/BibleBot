using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1
{

        public class VerseModel
        {
            public string reference { get; set; }
            public Passage[] verses { get; set; }
            public string text { get; set; }
            public string translation_id { get; set; }
            public string translation_name { get; set; }
            public string translation_note { get; set; }
        }

        public class Passage
        {
            public string book_id { get; set; }
            public string book_name { get; set; }
            public int chapter { get; set; }
            public int verse { get; set; }
            public string text { get; set; }
        }

    
}