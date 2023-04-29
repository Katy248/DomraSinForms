using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomraSinForms.Application.Questions.Notifications;
public class QuestionsUpdateNotification : INotification
{
    public string FormId { get; set; }
}
