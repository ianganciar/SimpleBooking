using AutoMapper;
using B.SimpleBooking.Application.Services.ResultPattern;
using B.SimpleBooking.Application.Services.ResultPattern.CustomErrors;
using B.SimpleBooking.Application.Services.ResultPattern.ErrorMessages;
using D.SimpleBooking.Domain.Entities;
using D.SimpleBooking.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace B.SimpleBooking.Application.UseCases.Professionals.UpdateProfessional;
public class UpdateProfessionalHandler : IRequestHandler<UpdateProfessionalCommand, Result<int>>
{
    private readonly IProfessionalRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateProfessionalCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateProfessionalHandler(IProfessionalRepository repository, IUnitOfWork unitOfWork, IValidator<UpdateProfessionalCommand> validator, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(UpdateProfessionalCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = _validator.Validate(request);

        if (!validatorResult.IsValid)
        {
            return new ValidationError(validatorResult);
        }

        var hasProfessional = await _repository.GetByIdAsync(request.Id);

        if (hasProfessional is null)
        {
            return new NotFoundError(ErrorMessages.PROFESSIONAL_NOT_FOUND);
        }

        var professional = _mapper.Map<Professional>(request);

        await _repository.UpdateAsync(professional);
        await _unitOfWork.CommitAsync(cancellationToken);

        return professional.Id;
    }
}
