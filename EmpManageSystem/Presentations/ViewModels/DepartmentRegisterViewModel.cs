///<summary>
/// リスト10-1 ViewModel
///</summary>
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Presentations.ViewModels;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class DepartmentRegisterViewModel
{
    /// <summary>
    /// 氏名
    /// </summary>
    [Display(Name = "部門")]
    [Required(ErrorMessage = "部門は入力必須です。")]
    public string? Name { get; set; } = string.Empty;


    // 部署のリスト
    public List<SelectListItem>? Departments { get; set; } = null;

    public override string ToString()
    {
        return $"Name={Name} ";
    }
}