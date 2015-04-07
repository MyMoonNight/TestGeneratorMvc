﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using DataLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class TestViewService : ITestViewService
    {
        private IUnitOfWork m_UnitOfWork;
        private ITestRepository m_TestRepository;

        public TestViewService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_TestRepository = m_UnitOfWork.GetRepository<ITestRepository>();
        }

        public List<ApiShowTest> GetTests()
        {
            return Mapper.Map<List<ApiShowTest>>(m_TestRepository.GetAll());
        }

        public List<ApiShowTest> GetTestsWithUsers()
        {
            return Mapper.Map<List<ApiShowTest>>(m_TestRepository.GetAllWithUsers());
        }

        public int GetTestCount()
        {
            return m_TestRepository.Count;
        }
    }
}