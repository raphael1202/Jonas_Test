using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }

        [NotMapped]
        public string TypeDesc { get; set; }

        [NotMapped]
        public List<MultipleChoice> MultipleChoice { get; set; }

        public Question()
        {
            Id = Guid.NewGuid();
        }

        public void SetChoices(List<MultipleChoice> choices)
        {
            MultipleChoice = choices;
        }

        public void SetTypeDesc(string typeDesc)
        {
            TypeDesc = typeDesc;
        }
    }
}