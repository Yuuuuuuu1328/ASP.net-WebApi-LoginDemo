using System;
using System.ComponentModel.DataAnnotations;

namespace CodeUin.WebApi.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }

   
        public string userAccount { get; set; }
   
        public string userPassword { get; set; }

        public string userName { get; set; }

 
        public DateTime userBirthday { get; set; }

    
        public string userIDNumber { get; set; }
  
        public string userPhone { get; set; }
   
        public string userEmail { get; set; }
}

    public class UserLoginModel
    {
        [Required(ErrorMessage = "请输入账号")]
        public string userAccount { get; set; }

        [Required(ErrorMessage = "请输入邮箱")]
        public string userEmail { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        public string userPassword { get; set; }
    }

    public class UserRegisterModel
    {
        [Required(ErrorMessage = "请输入账号")]
        [MaxLength(length: 13, ErrorMessage = "账号最大长度不能超过13")]
        [MinLength(length: 6, ErrorMessage = "账号最小长度不能小于6")]
        public string userAccount { get; set; }

        [Required(ErrorMessage = "请输入个人姓名")]
        [MaxLength(length: 28, ErrorMessage = "个人姓名最大长度不能超过28")]
        [MinLength(length: 1, ErrorMessage = "个人姓名不可为空")]
        public string userName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [MaxLength(length: 20, ErrorMessage = "密码最大长度不能超过20")]
        [MinLength(length: 6, ErrorMessage = "密码最小长度不能小于6")]
        public string userPassword { get; set; }

        [Required(ErrorMessage = "请输入邮箱")]
        [EmailAddress(ErrorMessage = "请输入正确的邮箱地址")]
        public string userEmail { get; set; }
    }
}
