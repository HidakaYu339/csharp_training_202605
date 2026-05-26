using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

}
