using Monuments.Manager.Application.Dictionary.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Factories
{
    public interface IDictionaryProviderFactory
    {
        IDictionaryProvider Create();
    }
}
