using AutoMapper;
using B.SimpleBooking.Application.Services.ResultPattern;
using B.SimpleBooking.Application.Services.ResultPattern.CustomErrors;
using B.SimpleBooking.Application.Services.ResultPattern.ErrorMessages;
using D.SimpleBooking.Domain.Entities;
using D.SimpleBooking.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace B.SimpleBooking.Application.UseCases.Professionals.CreateProfessional;
public class CreateProfessionalHandler : IRequestHandler<CreateProfessionalCommand, Result<Unit>>
{
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateProfessionalCommand> _validator;
    public CreateProfessionalHandler(IProfessionalRepository professionalRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<CreateProfessionalCommand> validator)
    {
        _professionalRepository = professionalRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Unit>> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = _validator.Validate(request);

        var hasprofessional = await _professionalRepository.HasProfessionalAsync(request.Email.Value, request.Phone);

        if (hasprofessional)
        {
            return new ConflictError(ErrorMessages.PROFESSIONAL_ALREADY_EXISTS);
        }

        if (!validatorResult.IsValid)
        {
            return new ValidationError(validatorResult);
        }

        var professional = _mapper.Map<Professional>(request);

        await _professionalRepository.CreateAsync(professional);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}
