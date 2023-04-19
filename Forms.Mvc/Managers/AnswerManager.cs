using DomraSinForms.Domen.Models;
using Forms.Mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Forms.Mvc.Managers;

public class AnswerManager
{
    private readonly ApplicationDbContext _context;

    public AnswerManager(ApplicationDbContext context)
    {
        _context = context;
    }

   /* public async Task<IEnumerable<Answer>> GenerateAnswers(string formId)
    {
        var form = await _context.Forms.Include(f => f.Questions).FirstAsync(f => f.Id == formId);
        var result = new FormAnswers { Answers = new(), Form = form };
        foreach (var question in form.Questions)
        {
            //result.Answers.Add(new Answer { Question = question, QuestionText = question.Text });
        }
        return result.Answers;
    }*/
}
