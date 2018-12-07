using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence
{
    public interface IEntityChangedUserContextHook
    {
        void FillCreatedByUserContext(IEnumerable<BaseEntity> entities);
        void FillModifiedByUserContext(IEnumerable<BaseEntity> entities);
    }
}
