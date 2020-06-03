using SiteSpeakAndSing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Repositories.Absrtact
{
    public interface ITeacherRepositories
    {
        IQueryable<Teacher> GetTeachers();
        Teacher GetTeacherById(Guid id);
        Teacher GetTeacherByCodeWord(string codeWord);
        void SaveTeacher(Teacher entity);
        void DeleteTeacher(Guid id);
    }
}
