using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:部門のCRUD操作インターフェイス
/// </summary>
public interface IDepartmentRepository
{
    /// <summary>
    /// すべての部門を取得する
    /// </summary>
    /// <returns>部門のリスト</returns>
    List<Department> FindAll();

    /// <summary>
    /// 指定された部門Idの部門を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns>取得して部署</returns>
    Department? FindById(int id);

    /// <summary>
    /// 部門を永続化する
    /// </summary>
    /// <param name="department">永続化対象の従業員</param>
    void Create(Department department);
}