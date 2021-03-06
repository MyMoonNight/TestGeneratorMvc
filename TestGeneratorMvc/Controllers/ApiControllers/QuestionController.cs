﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using nonintanon.Security;

namespace TestGeneratorMvc.Controllers.ApiControllers
{
    [System.Web.Http.Authorize(Roles="Trainer, Admin")]
    public class QuestionController : ApiController
    {
        private IQuestionCreateService m_QuestionCreateService;
        private IQuestionViewService m_QuestionViewService;
        private IQuestionImportService m_QuestionImportService;
        private IAnswerService m_AnswerService;

        public QuestionController()
        {
            m_QuestionCreateService = DependencyResolver.Current.GetService<IQuestionCreateService>();
            m_QuestionViewService = DependencyResolver.Current.GetService<IQuestionViewService>();
            m_QuestionImportService = DependencyResolver.Current.GetService<IQuestionImportService>();
            m_AnswerService = DependencyResolver.Current.GetService<IAnswerService>();
        }

        public List<ApiShowQuestion> GetQuestions()
        {
            return m_QuestionViewService.GetQuestions();
        }

        public List<ApiShowQuestionWithUser> GetQuestionsWithUser()
        {
            return m_QuestionViewService.GetQuestionsWithUser();
        }

        public int GetQuestionsCount()
        {
            return m_QuestionViewService.GetQuestionsCount();
        }

        public List<ApiShowAnswerWithValue> GetAnswersForQuestionWithRightValues(Guid questionId)
        {
            return m_AnswerService.GetAnswersForQuestionWithRightValues(questionId);
        }

        [System.Web.Http.HttpPost]
        public string AddQuestion(ApiCreateQuestion question)
        {
            question.OwnerId = WebSecurity.GetUserId(User.Identity.Name);
            return m_QuestionCreateService.AddQuestion(question);
        }
    }
}
