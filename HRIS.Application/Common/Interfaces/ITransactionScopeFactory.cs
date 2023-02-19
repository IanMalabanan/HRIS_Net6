using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace HRIS.Application.Common.Interfaces
{
    public interface ITransactionScopeFactory
    {
        TransactionScope Create();
    }
}
