using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Profile.Entityframework.EF
{
    public partial class Profile
    {
        public string ProfileId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string AvatarLarge { get; set; }
        public string AvatarMedium { get; set; }
        public string AvatarThumbnail { get; set; }
    }
}
