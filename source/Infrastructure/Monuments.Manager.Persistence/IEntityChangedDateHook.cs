using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence
{
    public interface IEntityChangedDateHook
    {
        void FillCreateDate(IEnumerable<BaseEntity> entities);
        void FillModifiedDate(IEnumerable<BaseEntity> entities);
    }
}
