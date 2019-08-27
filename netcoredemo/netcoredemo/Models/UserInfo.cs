using System;
using System.ComponentModel.DataAnnotations;

namespace netcoredemo.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage ="用户名不能为空")]
        [StringLength(10,ErrorMessage ="用户名长度不能超过10位")]
        public string UserName { get; set; }
        [StringLength(6,ErrorMessage ="密码长度不能超过6位")]
        public string Password { get; set; }
    }
}
