using Mahzan.Api.Paging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.ViewModels.Employees.GetEmployees
{
    public class GetEmployeesViewModel
    {

        public PagedList<Models.EntitiesExtensions.EmployeesExtension> employees { get; set; }

        public Paging.Paging paging { get; set; }
    }
}
