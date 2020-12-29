using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities
{
    enum Tip
    {
        Participant,
        Rezerva
    }
    class ActivePlayer:Entity<Tuple<long,long>>
    {
        public long idJucator { get; set; }
        public long idMeci { get; set; }
        public int nrPuncteInscrise { get; set; }
        public Tip tip { get; set; }

        public ActivePlayer(long idJucator, long idMeci, int nrPuncteInscrise, Tip tip)
        {
            this.idJucator = idJucator;
            this.idMeci = idMeci;
            this.nrPuncteInscrise = nrPuncteInscrise;
            this.tip = tip;
        }
    }
}
