using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CodeUin.Dapper
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        public async Task Delete(int Id, string deleteSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetMySqlConnection())
            {
                await conn.ExecuteAsync(deleteSql, new { Id });
            }
        }

        public async Task<T> Detail(int Id, string detailSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetMySqlConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<T>(detailSql, new { Id });
            }
        }

        public async Task<List<T>> ExecQuerySP(string SPName)
        {
            using (IDbConnection conn = DataBaseConfig.GetMySqlConnection())
            {
                return await Task.Run(() => conn.Query<T>(SPName, null, null, true, null, CommandType.StoredProcedure).ToList());
            }
        }

        public async Task<int> Insert(T entity, string insertSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetMySqlConnection())
            {
                return await conn.ExecuteAsync(insertSql, entity);
            }
        }

        public async Task<List<T>> Select(string selectSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetMySqlConnection())
            {
                return await Task.Run(() => conn.Query<T>(selectSql).ToList());
            }
            /*使用Task.Run方法在另一个线程上执行查询操作，以避免阻塞主线程。
             * 这个方法调用conn.Query<T>(selectSql)来执行SQL查询语句，并返回一个查询结果的集合。
             * 然后调用.ToList()方法将结果转换为列表。*/
        }

        public async Task Update(T entity, string updateSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetMySqlConnection())
            {
                await conn.ExecuteAsync(updateSql, entity);
            }
            /**********************************************
             * 使用using语句确保在操作完成后正确关闭和释放数据库连接。
IDbConnection conn: 声明一个IDbConnection类型的变量conn，这代表数据库连接。
DataBaseConfig.GetMySqlConnection(): 调用DataBaseConfig类的GetMySqlConnection方法来获取一个MySQL数据库连接。
await: 等待异步操作完成。在这种情况下，它等待数据库更新操作完成。
conn.ExecuteAsync(updateSql, entity): 调用ExecuteAsync方法来执行SQL更新语句。这个方法需要两个参数：更新的SQL语句和实体对象（包含更新的数据）。********************************/
        }
    }
}

/*这段 C# 代码定义了一个名为 `RepositoryBase<T>` 的类，它实现了前面提到的 `IRepositoryBase<T>` 接口。
 * 这个类位于 `CodeUin.Dapper` 命名空间下，并引入了 `Dapper`、`System.Collections.Generic`、`System.Data`、`System.Linq` 和 `System.Threading.Tasks` 等命名空间，用于支持数据库操作和异步编程。

`RepositoryBase<T>` 类中的每个方法都对应 `IRepositoryBase<T>` 接口中声明的方法，
它们都使用了 `Dapper` 库来进行高效的数据库操作。以下是每个方法的详细说明：

1. **Delete**：
   - 通过传入的主键值 `Id` 和删除 SQL 语句 `deleteSql`，异步执行删除操作。
使用 `DataBaseConfig.GetMySqlConnection()` 获取数据库连接，并通过 `conn.ExecuteAsync` 执行删除操作。

2. **Detail**：
   - 根据主键值 `Id` 和详情查询 SQL 语句 `detailSql`，异步执行查询单个实体的操作。
同样获取数据库连接，然后使用 `conn.QueryFirstOrDefaultAsync<T>` 执行查询并返回结果。

3. **ExecQuerySP**：
   - 异步执行存储过程并返回结果集。传入存储过程名称 `SPName`，
通过 `conn.Query<T>` 执行存储过程，并使用 `ToList` 将结果转换为 `List<T>` 类型。

4. **Insert**：
   - 将实体 `entity` 插入数据库，使用传入的插入 SQL 语句 `insertSql`。获取数据库连接，
通过 `conn.ExecuteAsync` 执行插入操作，并返回受影响的行数。

5. **Select**：
   - 根据传入的查询 SQL 语句 `selectSql`，异步执行查询并返回结果集。
获取数据库连接，使用 `conn.Query<T>` 执行查询并将结果转换为 `List<T>` 类型。

6. **Update**：
   - 更新实体 `entity` 在数据库中的记录，使用传入的更新 SQL 语句 `updateSql`。
获取数据库连接，通过 `conn.ExecuteAsync` 执行更新操作。

在这段代码中，每个方法都使用了 `using` 语句来确保数据库连接在操作完成后正确关闭和释放资源。
此外，所有数据库操作都被封装为异步方法，以适应高并发场景下的非阻塞式编程模型。*/