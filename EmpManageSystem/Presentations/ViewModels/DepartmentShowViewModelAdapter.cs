using EmpManageSystem.Applications.Adapters;
using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Presentations.ViewModels;
/// <summary>
/// DepartmentRegisterViewModel(部門登録ViewModel)を
/// ドメインオブジェクト:Departmentに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">department</typeparam>
/// <typeparam name="TTarget">DepartmentRegisterForm</typeparam>
public class DepartmentShowViewModelAdapter : IRestorer<Department, DepartmentShowViewModel>
{
    /// <summary>
    /// DepartmentShowViewModelをドメインオブジェクト:Departmentに変換する
    /// </summary>
    /// <param name="target">DepartmentShowViewModel</param>
    /// <returns>ドメインオブジェクト:Department</returns>
    public Department Restore(DepartmentShowViewModel target)
    {
        // Department(部署)を作成する
        var department = new Department(target.Name);

        return department;
    }
}