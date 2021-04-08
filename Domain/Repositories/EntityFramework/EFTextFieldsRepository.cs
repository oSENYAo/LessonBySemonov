using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }
       
        public IQueryable<TextField> GetTextField()
        {
            return context.TextField;
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextField.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid Id)
        {
            return context.TextField.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteTextField(Guid Id)
        {
            context.TextField.Remove(new TextField() { Id = Id });
            context.SaveChanges();
        }

    }
}
