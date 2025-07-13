using MediatR;

namespace PdfGeneratorService.Application.Abstractions;

public abstract class CommandBase<TResponse> : IRequest<TResponse>
{
}