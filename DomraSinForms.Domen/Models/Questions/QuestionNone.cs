﻿namespace DomraSinForms.Domen.Models.Questions;
public class QuestionNone : QuestionBase
{
    protected QuestionNone()
    {

    }
    public static QuestionBase Instance = new QuestionNone();
}
