using System;
using System.Collections.Generic;
using System.Text;
using Monuments.Manager.Common;
using Monuments.Manager.Domain.Entities;

namespace Monuments.Manager.Persistence
{
    public class EntityChangedUserContextHook : IEntityChangedUserContextHook
    {
        private readonly IApplicationContext _applicationContext;

        public EntityChangedUserContextHook(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void FillCreatedByUserContext(IEnumerable<BaseEntity> entities)
        {
            foreach(var entity in entities)
            {
                entity.CreatedBy = _applicationContext.UserId.ToString();
            }
        }

        public void FillModifiedByUserContext(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedBy = _applicationContext.UserId.ToString();
            }
        }
    }
}
