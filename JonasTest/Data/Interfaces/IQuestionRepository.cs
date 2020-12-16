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
        void Save();
    }
}