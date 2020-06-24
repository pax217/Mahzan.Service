using Mahzan.Business.Events.Companies.CreateCompany;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Companies.CreateCompany
{
    public interface ICreateCompanyEventHandler
    {
        Task Handle(CreateCompanyEvent createCompanyEvent);
    }
}
