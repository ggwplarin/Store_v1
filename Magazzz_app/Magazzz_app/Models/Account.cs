using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Magazzz_app.Models
{
    public class Account
    {
        [Key]
        public int account_id { get; init; }
        [Required(ErrorMessage = "Поле электронной почты должно быть заполнено")]
        public string account_email { get; init; }
        [Required(ErrorMessage = "Поле пароля должно быть заполнено")]
        [DataType(DataType.Password)]
        public string account_password { get; init; }
    }
}
