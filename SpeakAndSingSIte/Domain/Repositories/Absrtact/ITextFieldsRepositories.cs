using SiteSpeakAndSing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Repositories.Absrtact
{
    public interface ITextFieldsRepositories
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeliteTextField(Guid id);
    }
}
