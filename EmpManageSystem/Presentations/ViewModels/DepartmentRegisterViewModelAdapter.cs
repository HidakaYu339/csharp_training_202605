using EmpManageSystem.Applications.Adapters;
using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Presentations.ViewModels;
/// <summary>
/// DepartmentRegisterViewModel(部門登録ViewModel)を
/// ドメインオブジェクト:Departmentに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">department</typeparam>
/// <typeparam name="TTarget">DepartmentRegisterForm</typeparam>
public class DepartmentRegisterViewModelAdapter : IRestorer<Department, DepartmentRegisterViewModel>
{
    /// <summary>
    /// EmployeeRegisterViewModelをドメインオブジェクト:Employeeに変換する
    /// </summary>
    /// <param name="target">EmployeeRegisterViewModel</param>
    /// <returns>ドメインオブジェクト:Employee</returns>
    public Department Restore(DepartmentRegisterViewModel target)
    {
        // Department(部署)を作成する
        var department = new Department(target.Name);

        return department;
    }
}