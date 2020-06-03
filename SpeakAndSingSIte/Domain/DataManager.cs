using SiteSpeakAndSing.Domain.Repositories.Absrtact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain
{
    public class DataManager
    {
        public ITextFieldsRepositories TextFields { get; set; }
        public IServiceItemsRepositories ServiceItems { get; set; }
        public ITeacherRepositories Teachers { get; set; }

        public DataManager(ITextFieldsRepositories textFields, IServiceItemsRepositories serviceItems, ITeacherRepositories teachers)
        {
            TextFields = textFields;
            ServiceItems = serviceItems;
            Teachers = teachers;
        }
    }
}
