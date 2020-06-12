using Mahzan.Business.Events.Users;
using Mahzan.Business.Results.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Users.SignUp
{
    public interface ISignUpEventHandler
    {
        Task<Models.Entities.Users> HandleEvent(SignUpEvent signUpEvent); 
    }
}
