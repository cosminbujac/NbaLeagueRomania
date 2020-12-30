using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities.validators
{
    class BasicValidator<E> : IValidator<E> 
    {
        public void validate(E e)
        {
            return;
        }
    }
}
