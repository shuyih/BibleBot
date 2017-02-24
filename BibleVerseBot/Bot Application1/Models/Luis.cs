using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Models
{

    public class BibleLuis
    {
        public string query { get; set; }
        public Topscoringintent topScoringIntent { get; set; }
        public Intent[] intents { get; set; }
        public Entity[] entities { get; set; }
        public Dialog dialog { get; set; }
    }

    public class Topscoringintent
    {
        public string intent { get; set; }
        public float score { get; set; }
        public Action[] actions { get; set; }
    }

    public class Action
    {
        public bool triggered { get; set; }
        public string name { get; set; }
        public Parameter[] parameters { get; set; }
    }

    public class Parameter
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool required { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
    {
        public string entity { get; set; }
        public string type { get; set; }
        public Resolution resolution { get; set; }
    }

    public class Resolution
    {
    }

    public class Dialog
    {
        public string contextId { get; set; }
        public string status { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
        public Action1[] actions { get; set; }
    }

    public class Action1
    {
        public bool triggered { get; set; }
        public string name { get; set; }
        public Parameter1[] parameters { get; set; }
    }

    public class Parameter1
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool required { get; set; }
        public Value1[] value { get; set; }
    }

    public class Value1
    {
        public string entity { get; set; }
        public string type { get; set; }
        public Resolution1 resolution { get; set; }
    }

    public class Resolution1
    {
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }
        public Resolution2 resolution { get; set; }
    }

    public class Resolution2
    {
    }

}