using Data.Entities;
using Data.Repositories;
using JonasTest.Models;
using JonasTest.Utils;
using JonasTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace JonasTest.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionnaireController()
        {
            _questionRepository = new QuestionRepository();
        }

        // GET: Questionnaire
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListView()
        {
            try
            {
                var savedQuestions = _questionRepository.GetAll();

                foreach (var item in savedQuestions)
                {
                    item.SetTypeDesc(GetTypeDesc(item.Type));
                }

                ViewBag.Questions = savedQuestions;

                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        private string GetTypeDesc(int type)
        {
            var description = Extensions.GetEnumDisplayName((DataTypeEnum)type);
            return description;
        }

        [HttpPost]
        public JsonResult Questionnaire(List<Question> questions)
        {
            try
            {
                _questionRepository.InsertAll(questions);
                return Json(new { msg = "Questions saved" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
        }

        public JsonResult DeleteQuestion(Question question)
        {
            try
            {
                _questionRepository.DeleteQuestion(question);
                return Json(new { msg = "Question deleted" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult PreviewQuestion(Question data)
        {
            try
            {
                var question = _questionRepository.PreviewQuestion(data);
                ViewBag.Text = question.Text;

                if (question.Type == 5)
                {
                    IEnumerable<MultipleChoice> choices;
                    choices = _questionRepository.GetAllMultiple();

                    ViewBag.Choices = choices;
                }

                return PartialView(question);
            }
            catch (Exception ex)
            {
                return PartialView(new { msg = ex.Message });
            }
        }
    }
}