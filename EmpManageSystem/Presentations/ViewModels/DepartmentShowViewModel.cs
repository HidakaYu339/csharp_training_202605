using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Presentations.ViewModels;
/// <summary>
/// 部門一覧ViewModelクラス
/// </summary>
public class DepartmentShowViewModel
{
    /// <summary>
    /// 部門
    /// </summary>
    [Display(Name = "部門")]
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// 部署のリストをSelectListItemのリストに変換してプロパティに設定する
    /// </summary>
    /// <param name="departments"></param>
    public void SetDepartments(List<Department> departments)
    {
        // SelectListItemのリストを作成
        var selectItems = new List<SelectListItem>();
        foreach (var dept in departments)
        {
            if (dept.Id.HasValue)
            {
                var item = new SelectListItem();
                item.Value = dept.Id.Value.ToString();
                item.Text = string.IsNullOrEmpty(dept.Name) ? "(名称未設定)" : dept.Name;
                selectItems.Add(item);
            }
        }
        Departments = selectItems;
    }


    // 部署のリスト
    public List<SelectListItem>? Departments { get; set; } = null;

    public override string ToString()
    {
        return $"Name={Name} ";
    }
}