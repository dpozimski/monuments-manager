using System;
using System.Collections.Generic;
using System.Text;
using Monuments.Manager.Domain.Entities;

namespace Monuments.Manager.Persistence
{
    public class EntityChangedDateHook : IEntityChangedDateHook
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public EntityChangedDateHook(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public void FillCreateDate(IEnumerable<BaseEntity> entities)
        {
            foreach(var entity in entities)
            {
                entity.CreatedDate = _dateTimeProvider.GetCurrent();
            }
        }

        public void FillModifiedDate(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ModifiedDate = _dateTimeProvider.GetCurrent();
            }
        }
    }
}
