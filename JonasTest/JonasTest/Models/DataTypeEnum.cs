using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JonasTest.Models
{
    public enum DataTypeEnum
    {
        [Display(Name = "Text")]
        String = 1,
        Numeric = 2,
        [Display(Name = "Boolean(true/false)")]
        Boolean = 3,
        [Display(Name = "Date/Time")]
        DateTime = 4,
        [Display(Name = "Multiple choice")]
        MultipleChoiceQuestions = 5
    }
}