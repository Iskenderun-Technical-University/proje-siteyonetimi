using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Models.Residences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;

namespace ResidenceManagement.Application.Features.Commands.Residences.AddResidence
{
    public class AddResidenceCommand : ResidenceAddDto, IRequest<AddResidenceResponse>
    {
    }
}