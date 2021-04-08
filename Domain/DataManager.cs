using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Domain.Repositories.EntityFramework;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFieldsRepository { get; set; }
        public IServiceItemRepository ServiceItemRepository { get; set; }
        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemRepository serviceItemRepository)
        {
            this.TextFieldsRepository = textFieldsRepository;
            this.ServiceItemRepository = serviceItemRepository;
        }
    }
}
