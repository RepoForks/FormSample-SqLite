using System;
using SQLite.Net.Attributes;

namespace FormSample
{

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class Agent
    {
		[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgencyName { get; set; }
        public string Phone { get; set; }
        
    }

    public class Contractor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInformation { get; set; }
    }
}

