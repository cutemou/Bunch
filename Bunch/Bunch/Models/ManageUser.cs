using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bunch.Models
{
    public class ManageUser
    {
        [Required] //必要欄位
        public string Id { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 1)]
        [Display(Name = "名稱")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }
}