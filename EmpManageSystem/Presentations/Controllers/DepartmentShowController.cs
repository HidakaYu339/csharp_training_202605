using Microsoft.AspNetCore.Mvc;
using EmpManageSystem.Applications.Services;
using EmpManageSystem.Presentations.ViewModels;
using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Presentations.Controllers;
/// <summary>
/// 部門登録コントローラ
/// </summary>
[Route("DepartmentShow")]
public class DepartmentShowController : Controller
{
    /// <summary>
    /// ロガー
    /// <summary>
    private readonly ILogger<DepartmentShowController> _logger;
    /// 部門登録サービスインターフェイス（部門登録のサービスの中で一覧取得してて、それをそのまま活用してる）
    /// </summary>
    private readonly IDepartmentRegisterService _departmentRegisterService;
    /// <summary>
    /// 部門表示ViewModelをDepartmentに変換するアダプター
    /// </summary>
    private readonly DepartmentShowViewModelAdapter _adapter;
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly TempDataStore<DepartmentShowViewModel> _dpaDataStore;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public DepartmentShowController(
     ILogger<DepartmentShowController> logger, IDepartmentRegisterService departmentRegisterService,
     DepartmentShowViewModelAdapter departmentShowViewModelAdapter, TempDataStore<DepartmentShowViewModel> dpaDataStore)
    {
        _logger = logger;
        _departmentRegisterService = departmentRegisterService;
        _adapter = departmentShowViewModelAdapter;
        _dpaDataStore = dpaDataStore;
    }

    /// <summary>
    /// 部門登録(入力)画面表示 アクションメソッド
    /// </summary>
    /// <returns></returns>
    [HttpGet("ShowData")]
    public IActionResult Show()
    {
        var list = new List<DepartmentShowViewModel>();

        return View(list);
    }





    private void PopulateDepartments(DepartmentRegisterViewModel viewModel)
    {
        // 部門登録サービスから部門一覧を取得する
        var departments = _departmentRegisterService.GetDepartments();
        // 部署一覧をDepartmentRegisterViewModelに登録する
        viewModel.SetDepartments(departments);
        _logger.LogInformation("部署リストを設定");
    }

}