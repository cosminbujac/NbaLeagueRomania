using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities.validators
{
    class ActivePlayerValidator : IValidator<ActivePlayer>
    {
        public void validate(ActivePlayer e)
        {
            if (e.nrPuncteInscrise <= 0)
                throw new Exception("Invalid number of points!");
        }
    }
}
