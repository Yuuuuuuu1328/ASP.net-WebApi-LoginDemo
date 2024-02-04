using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeUin.Dapper
{
    public interface IRepositoryBase<T>
    {
        Task<int> Insert(T entity, string insertSql);

        Task Update(T entity, string updateSql);

        Task Delete(int Id, string deleteSql);

        Task<List<T>> Select(string selectSql);

        Task<T> Detail(int Id, string detailSql);
    }
}

/*  这段 C# 代码定义了一个名为 `IRepositoryBase<T>` 的泛型接口，位于 `CodeUin.Dapper` 命名空间下。
 *  这个接口主要用于定义一系列针对实体 `T` 的基本 CRUD（创建 Create、更新 Update、删除 Delete 和查询 Retrieve）操作，
 *  这些操作都是异步的，通过 `Task` 对象返回结果。

接口的方法如下：

1. **Insert(T entity, string insertSql)**：
   - 输入参数：一个类型为 `T` 的实体对象 `entity` 和一个自定义的插入 SQL 语句字符串 `insertSql`。
   - 返回值：一个 `Task<int>`，表示插入操作完成后返回的受影响行数（通常用于判断插入是否成功）。

2. **Update(T entity, string updateSql)**：
   - 输入参数：一个类型为 `T` 的实体对象 `entity` 和一个自定义的更新 SQL 语句字符串 `updateSql`。
   - 返回值：一个 `Task`，表示更新操作完成后返回的受影响行数。

3. **Delete(int Id, string deleteSql)**：
   - 输入参数：一个整数类型的主键值 `Id` 和一个自定义的删除 SQL 语句字符串 `deleteSql`。
   - 返回值：一个 `Task`，表示删除操作完成后返回的受影响行数。

4. **Select(string selectSql)**：
   - 输入参数：一个自定义的选择（查询）SQL 语句字符串 `selectSql`。
   - 返回值：一个 `Task<List<T>>`，表示查询操作完成后返回的结果集，结果集是一个由类型 `T` 的对象构成的列表。

5. **Detail(int Id, string detailSql)**：
   - 输入参数：一个整数类型的主键值 `Id` 和一个自定义的详情查询 SQL 语句字符串 `detailSql`。
   - 返回值：一个 `Task<T>`，表示根据主键查询单条记录的操作结果，返回的是一个类型为 `T` 的实体对象。

通过这个接口，你可以定义和实现各种数据库操作的具体逻辑，适用于多种数据访问技术，如 Dapper 等轻量级 ORM。
在实现类中，开发者需要根据传入的 SQL 语句以及实体对象执行对应的数据库操作。
由于所有的方法都是异步的，它们适合于高并发环境下的数据库操作，可以有效地防止阻塞线程。*/