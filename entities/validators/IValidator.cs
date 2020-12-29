using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities.validators
{
    interface IValidator<E>
    {
        void validate(E e);
    }
}
