/// <summary>
/// リスト9-1 Serviceインターフェイスとその実装
/// </summary>
using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Applications.Services;
/// <summary>
/// 社員登録サービスインターフェイス
/// </summary>
public interface IEmployeeRegisterService
{
    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    List<Department> GetDepartments();

    /// <summary>
    /// 指定された部署Idの部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    Department GetById(int id);

    /// <summary>
    /// 新しい従業員を登録する
    /// </summary>
    /// <param name="employee"></param>
    void Register(Employee employee);
}