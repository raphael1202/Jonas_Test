using System;
using System.Collections.Generic;
using System.Linq;
using Data.Context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private JonasContext _context;

        public QuestionRepository()
        {
            _context = new JonasContext();
        }

        public void DeleteAll()
        {
            _context.Questions.RemoveRange(GetAll());
            _context.MultipleChoices.RemoveRange(GetAllMultiple());
        }

        public IEnumerable<Question> GetAll()
        {
            var questions = _context.Questions.ToList();

            foreach(var question in questions.Where(q => q.Type == 5))
            {
                var choices = _context.MultipleChoices.Where(c => c.QuestionId == question.Id);
                question.SetChoices(choices.ToList());
            }

            return questions;
        }

        public IEnumerable<MultipleChoice> GetAllMultiple()
        {
            var multiples = _context.MultipleChoices.ToList();

            return multiples;
        }

        public void InsertAll(List<Question> questions)
        {
            DeleteAll();

            foreach (var question in questions)
            {
                _context.Questions.Add(question);
                Save();

                if (question.MultipleChoice != null)
                    foreach (var multiple in question.MultipleChoice)
                    {
                        multiple.QuestionId = question.Id;
                        multiple.Question = question;
                        _context.MultipleChoices.Add(multiple);
                        Save();
                    }
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}