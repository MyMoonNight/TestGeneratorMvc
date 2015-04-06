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
    public class TestExportViewService : ITestExportViewService
    {
        private IUnitOfWork m_UnitOfWork;
        private ITestRepository m_TestRepository;
        private ITestExportRepository m_TestExportRepository;

        public TestExportViewService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_TestRepository = m_UnitOfWork.GetRepository<ITestRepository>();
            m_TestExportRepository = m_UnitOfWork.GetRepository<ITestExportRepository>();
        }

        public List<ApiShowTestWithTestExport> GetTestExportsForTests()
        {
            return Mapper.Map<List<ApiShowTestWithTestExport>>(m_TestRepository.GetAllWithTestExport());
        }

        public List<ApiShowTestExportWithTestInfo> GetTestExportsWithTestInfo()
        {
            return Mapper.Map<List<ApiShowTestExportWithTestInfo>>(m_TestExportRepository.GetAllWithTest());
        }
    }
}
