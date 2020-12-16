using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonasTest.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public int QuestionnaireType { get; set; }
        public string Question { get; set; }
    }
}