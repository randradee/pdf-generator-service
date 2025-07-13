using MediatR;

namespace PdfGeneratorService.Application.Abstractions;

public abstract class QueryBase<TResponse> : IRequest<TResponse>
{
}