using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<PagedResponse<List<Transaction?>>> GetTransactionByPeriodAsync(GetTransactionsByPeriodRequest getTransactionsByPeriodRequest);
        Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest getTransactionByIdRequest);
        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest createTransactionRequest);
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest updateTransactionRequest);
        Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest deleteTransactionRequest);
    }
}
