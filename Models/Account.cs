﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class Account
    {
       /* public Account(int Id, string Password)
        {
            this.Id = Id;
            this.Password = Password;
        }

        public Account()
        {

        }*/

        [Key]
        public string Id { get; set; }

        public string Password { get; set; }
        [JsonIgnore]
        public virtual User Users { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        [JsonIgnore]
        public virtual ICollection<RequestItem> RequestItems { get; set; }
    }
}
