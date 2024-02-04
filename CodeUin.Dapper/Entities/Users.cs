namespace CodeUin.Dapper.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Users : BaseModel
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string userAccount { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string userPassword { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string userBirthday { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string userIDNumber { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string userPhone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string userEmail { get; set; }

        /// <summary>
        /// 用户权限
        /// </summary>
        public int userPermissionId { get; set; }
    }
}