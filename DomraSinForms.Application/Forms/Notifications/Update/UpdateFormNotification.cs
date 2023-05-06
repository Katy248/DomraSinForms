using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomraSinForms.Application.Forms.Notifications.Update;
public class UpdateFormNotification : INotification
{
    public string FormId { get; set; }
}
