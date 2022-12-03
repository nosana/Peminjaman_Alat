using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class AccountRole
    {
      /*  public AccountRole(int AccountId, int RoleId)
        {
            this.AccountId = AccountId;
            this.RoleId = RoleId;
        }

        public AccountRole()
        {

        }*/

        
        public string AccountId { get; set; }
        
        public int RoleId { get; set; }

        [JsonIgnore]
        public virtual Account Accounts { get; set; }
        [JsonIgnore]
        public virtual Role Roles { get; set; }
    }
}
