using System;

namespace Data.Entities
{
    public class MultipleChoice
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public MultipleChoice()
        {
            Id = Guid.NewGuid();
        }
    }
}