using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadCurrentUserBalence;

public class ReadCurrentUserBalenceQuery : IQuery<CurrentBalenceResponse>;