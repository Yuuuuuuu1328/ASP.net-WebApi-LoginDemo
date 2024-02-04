using MySql.Data.MySqlClient;
using System.Data;

namespace CodeUin.Dapper
{
    public class DataBaseConfig
    {
        private static string MySqlConnectionString = @"Data Source=127.0.0.1;Initial Catalog=yuu;Charset=utf8mb4;User ID=root;Password=123456;";

        public static IDbConnection GetMySqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = MySqlConnectionString;
            }
            IDbConnection conn = new MySqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
    }
}
/*这段 C# 代码定义了一个名为 `DataBaseConfig` 的类，用于配置和获取 MySQL 数据库连接。
 它位于命名空间 `CodeUin.Dapper` 下，并引入了两个 NuGet 包：`MySql.Data.MySqlClient` 用于与 MySQL 数据库进行交互，
 `System.Data` 包含了一些与数据库连接和操作相关的基类。

类中主要包含：

1. 私有静态字段 MySqlConnectionString：存储了一个字符串类型的 MySQL 数据库连接字符串，
包括数据库服务器地址（`Data Source`）、数据库名称（`Initial Catalog`）、字符集（`Charset`）、用户名（`User ID`）和密码（`Password`）。

2. 公共静态方法 GetMySqlConnection：
   - 方法接收一个可选的字符串参数 `sqlConnectionString`，如果不提供或为空，则使用类内部定义的默认连接字符串 `MySqlConnectionString`。
   - 方法创建一个新的 `MySqlConnection` 对象，该对象继承自 `IDbConnection` 接口，这是 ADO.NET 中用于与数据库建立连接的基本对象。
   - 然后打开数据库连接。
   - 最后返回已打开的 `MySqlConnection` 对象。

这个类的目的在于提供一个便捷的方式来获取到已经打开的 MySQL 数据库连接，简化了数据库操作的初始化过程。
在实际项目中，可以方便地在任何需要连接数据库的地方调用 `DataBaseConfig.GetMySqlConnection()` 方法获取连接，并执行 SQL 查询或其他数据库操作。*/