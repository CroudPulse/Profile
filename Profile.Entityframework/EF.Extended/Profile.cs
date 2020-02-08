using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Profile.Entityframework.EF
{

    [MetadataType(typeof(UserProfileMetadata))]
    public partial class Profile
    {
        internal sealed class UserProfileMetadata
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public string ProfileId { get; set; }
        }
    }
}
