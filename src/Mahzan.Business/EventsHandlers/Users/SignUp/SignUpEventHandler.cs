using Mahzan.Business.Events.Users;
using Mahzan.Business.Results.Users;
using Mahzan.DataAccess.DTO.Users;
using Mahzan.DataAccess.Repositories.Users.SignUp;
using Mahzan.Models.Enums.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Users.SignUp
{
    public class SignUpEventHandler : ISignUpEventHandler
    {
        private readonly ISignUpRepository _signUpRepository;

        public SignUpEventHandler(
            ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }

        public async Task<Mahzan.Models.Entities.Users> HandleEvent(SignUpEvent signUpEvent)
        {

            Mahzan.Models.Entities.Users user = await _signUpRepository
                .HandleRepository(new SignUpDto
                {
                    Name = signUpEvent.Name,
                    Phone = signUpEvent.Phone,
                    Email = signUpEvent.Email,
                    UserName = signUpEvent.UserName,
                    Password = signUpEvent.Password
                });


            return user;
        }
    }
}
