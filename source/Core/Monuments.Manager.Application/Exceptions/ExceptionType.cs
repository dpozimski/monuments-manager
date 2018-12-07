using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public enum ExceptionType
    {
        AuthenticationFail,
        CannotDeleteCurrentUser,
        DictionaryParentValueNotFound,
        EntityNotFound,
        RecoveryKeyValidationFailed,
        UserAlreadyExists,
        CannotSendEmail,
        CannotPromoteYourself,
        UserAlreadyPromoted
    }
}
