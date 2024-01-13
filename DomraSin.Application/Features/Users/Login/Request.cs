using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomraSin.Application.Features.Users.Login;
internal record Request(string Email, string Password) : IRequest<Response>;
