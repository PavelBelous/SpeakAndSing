using Microsoft.EntityFrameworkCore;
using SiteSpeakAndSing.Domain.Entities;
using SiteSpeakAndSing.Domain.Repositories.Absrtact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Repositories.EntityFramework
{
    public class EFTeachersRepositories : ITeacherRepositories
    {
        private readonly AppDbContext context;
        public EFTeachersRepositories(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Teacher> GetTeachers()
        {
            return context.Teachers;
        }

        public Teacher GetTeacherById(Guid id)
        {
            return context.Teachers.FirstOrDefault(x => x.Id == id);
        }

        public Teacher GetTeacherByCodeWord(string codeWord)
        {
            return context.Teachers.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public void SaveTeacher(Teacher entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTeacher(Guid id)
        {
            context.Teachers.Remove(new Teacher() { Id = id });
            context.SaveChanges();
        }
    }
}
