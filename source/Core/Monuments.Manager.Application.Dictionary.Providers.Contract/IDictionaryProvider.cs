using Monuments.Manager.Application.Dictionary.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Dictionary.Providers
{
    public interface IDictionaryProvider
    {
        Task<IReadOnlyList<Province>> GetProvincesAsync();
    }
}
