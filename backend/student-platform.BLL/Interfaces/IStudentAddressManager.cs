﻿using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Interfaces
{
    public interface IStudentAddressManager
    {
        Task<List<StudentAddressModels>> GetAll();
        Task<StudentAddressModels> GetById(int id);
        Task Create(StudentAddressModels studentAddressModel);
        Task Update(int id, StudentAddressModels studentAddressModel);
        Task Delete(int id);
    }
}
