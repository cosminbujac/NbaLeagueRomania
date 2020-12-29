using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities
{
    class Student : Entity<long>
    {
        protected string Nume { get; set; }
        protected string Scoala { get; set; }

        public Student(string nume, string scoala)
        {
            Nume = nume;
            Scoala = scoala;
        }
    }

}
