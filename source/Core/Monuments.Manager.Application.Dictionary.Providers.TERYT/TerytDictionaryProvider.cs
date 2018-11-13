using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Monuments.Manager.Application.Dictionary.Providers.Contract;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt
{
    public class TerytDictionaryProvider : IDictionaryProvider
    {
        public Task<IReadOnlyList<Province>> GetProvincesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
