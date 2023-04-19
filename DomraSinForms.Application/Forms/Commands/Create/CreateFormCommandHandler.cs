﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomraSinForms.Domen.Models;
using Forms.Mvc.Data;
using MediatR;

namespace DomraSinForms.Application.Forms.Commands.Create;
public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, Form>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateFormCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Form> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        var form = _mapper.Map<Form>(request);

        await _context.AddAsync(form, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return form;
    }
}
