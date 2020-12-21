using Data.Entities;
using System;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IQuestionRepository : IDisposable
    {
        IEnumerable<Question> GetAll();
        void InsertAll(List<Question> questions);
        void DeleteAll();
        void DeleteQuestion(Question question);
        //void UpdateQuestion(Question question);
        Question PreviewQuestion(Question question);
        void Save();
    }
}