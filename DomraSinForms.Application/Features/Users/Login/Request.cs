using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomraSinForms.Application.Features.Users.Login;
public record Request(string Email, string Password) : IRequest<Response?>;
