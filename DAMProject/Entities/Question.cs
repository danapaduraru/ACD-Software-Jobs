﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string Quest { get; set; }
        public Helper.QuestionType QuestionType { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        public Helper.CorrectAnswer CorrectAnswer{ get; set;}
        public string TextAnswer { get; set; }
        public bool Cancelled { get; set; }

    }
}