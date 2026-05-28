using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmpManageSystem.Infrastructures.Entities;
/// <summary>
/// 部門テーブル(department)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("department")]
public class DepartmentEntity
{
    /// <summary>
    /// 部門Id(主キー)
    /// </summary> 
    [Key]
    [Column("id")]
    public int DeptId { get; set; }
    /// <summary>
    /// 部門名
    /// </summary> 

    [Column("name")]
    public string DeptName { get; set; } = string.Empty;
}