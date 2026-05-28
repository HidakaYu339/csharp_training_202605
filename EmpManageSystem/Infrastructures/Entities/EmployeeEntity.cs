using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmpManageSystem.Infrastructures.Entities;
/// <summary>
/// 社員テーブル(employee)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("employee")]
public class EmployeeEntity
{
    /// <summary>
    /// 社員Id(主キー)
    /// </summary>
    [Key]
    [Column("id")]
    public int EmpId { get; set; }
    [Column("name")]
    /// <summary>
    /// 社員名
    /// </summary>
    public string EmpName { get; set; } = string.Empty;
    /// <summary>
    /// 所属部門Id(外部キー)
    /// </summary>

    [Column("dept_id")]
    public int? DeptId { get; set; }
}