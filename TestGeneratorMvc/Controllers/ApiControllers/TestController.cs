﻿using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using nonintanon.Security;

namespace TestGeneratorMvc.Controllers.ApiControllers
{
    [System.Web.Http.Authorize(Roles = "Trainer, Admin")]
    public class TestController : ApiController
    {
        private ITestCreateService m_TestCreateService;
        private ITestViewService m_TestViewService;
        private IQuestionViewService m_QuestionViewService;

        public TestController()
        {
            m_TestCreateService = DependencyResolver.Current.GetService<ITestCreateService>();
            m_TestViewService = DependencyResolver.Current.GetService<ITestViewService>();
            m_QuestionViewService = DependencyResolver.Current.GetService<IQuestionViewService>();
        }

        public List<ApiShowTest> GetTests()
        {
            return m_TestViewService.GetTests();
        }

        public List<ApiShowTestWithOwner> GetTestsWithOwner()
        {
            return m_TestViewService.GetTestsWithOwner();
        }

        public int GetTestsCount()
        {
            return m_TestViewService.GetTestsCount();
        }

        public List<ApiShowQuestionForTestView> GetQuestionsForTest(Guid testId)
        {
            return m_QuestionViewService.GetQuestionsForTest(testId);
        }

        public List<ApiShowQuestionForTestCreate> GetQuestionsForTestCreate()
        {
            return m_TestCreateService.GetQuestionsForTestCreate();
        }

        [System.Web.Http.HttpPost]
        public string AddTest(ApiCreateTest test)
        {
            test.OwnerId = WebSecurity.GetUserId(User.Identity.Name);
            return m_TestCreateService.AddTest(test);
        }
    }
}
