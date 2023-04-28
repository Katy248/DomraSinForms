using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands.UpdateTextQuestion;
public class UpdateTextQuestionCommandHandler : IRequestHandler<UpdateTextQuestionCommand, TextQuestion>
{
    private readonly ApplicationDbContext _context;

    public UpdateTextQuestionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<TextQuestion> Handle(UpdateTextQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.TextQuestions.FindAsync(request.Id, cancellationToken);

        if (question is null)
            return null;

        question.QuestionText = request.QuestionText;
        question.IsRequired = request.IsRequired;
        question.Index = request.Index;
        question.Type = request.Type;

        _context.Update(question);
        await _context.SaveChangesAsync(cancellationToken);

        return question;
    }
}
