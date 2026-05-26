///<summary>
/// リスト10-3 従業員登録コントローラ
///</summary>
using Microsoft.AspNetCore.Mvc;
using EmpManageSystem.Applications.Services;
using EmpManageSystem.Presentations.ViewModels;
using EmpManageSystem.Applications.Domains;
namespace EmpManageSystem.Presentations.Controllers;
/// <summary>
/// 部門登録コントローラ
/// </summary>
[Route("DepartmentRegister")]
public class DepartmentRegisterController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<DepartmentRegisterController> _logger;
    /// <summary>
    /// 部門登録サービスインターフェイス
    /// </summary>
    private readonly IDepartmentRegisterService _departmentRegisterService;
    /// <summary>
    /// 部門登録ViewModelをEmployeeに変換するアダプター
    /// </summary>
    private readonly DepartmentRegisterViewModelAdapter _adapter;
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly TempDataStore<DepartmentRegisterViewModel> _dpaDataStore;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public DepartmentRegisterController(
     ILogger<DepartmentRegisterController> logger, IDepartmentRegisterService departmentRegisterService,
     DepartmentRegisterViewModelAdapter departmentRegisterViewModelAdapter, TempDataStore<DepartmentRegisterViewModel> dpaDataStore)
    {
        _logger = logger;
        _departmentRegisterService = departmentRegisterService;
        _adapter = departmentRegisterViewModelAdapter;
        _dpaDataStore = dpaDataStore;
    }

    /// <summary>
    /// 部門登録(入力)画面表示 アクションメソッド
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        DepartmentRegisterViewModel? viewModel = null;
        // [戻る]ボタンへの対応
        // TempDataからDepartmentRegisterViewModelを取得する
        viewModel = _dpaDataStore.Load(this);
        if (viewModel == null)
        {
            // 部門登録ViewModelを生成する
            viewModel = new DepartmentRegisterViewModel();
        }
        // 部署一覧を取得してViewModelに設定する(SelectListItem形式)
        PopulateDepartments(viewModel);
        // viewModelをviewに渡して画面表示する
        return View(viewModel);
    }

    /// <summary>
    /// 入力画面の[完了]ボタンクリックアクションメソッド
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [HttpPost("Confirm")]
    public IActionResult Confirm(DepartmentRegisterViewModel viewModel)
    {
        // バリデーションチェック
        if (!ModelState.IsValid) // バリデーションエラーあり
        {
            // 部署一覧を取得してViewModelに設定する(SelectListItem形式)
            PopulateDepartments(viewModel);
            // 入力画面の表示
            return View("Enter", viewModel);
        }


        // 確認画面を表示する
        return View(viewModel);
    }

    /// <summary>
    /// 確認画面の[登録]ボタンクリックアクションメソッド
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost("Regiter")]
    public IActionResult Register(DepartmentRegisterViewModel viewModel)
    {
        // DepartmentRegisterViewModelをシリアライズして、TempDataに保存する
        _dpaDataStore.Save(this, viewModel);
        // 登録処理GETアクションメソッドにリダイレクトする
        return RedirectToAction("Complete");
    }

    /// <summary>
    /// アクションメソッド:Regiter()のリダイレクト先
    /// PRGパターン
    /// </summary>
    /// <returns></returns>
    [HttpGet("Complete")]
    public IActionResult Complete()
    {
        DepartmentRegisterViewModel? viewModel = null;
        // TempDataからDepartmentRegisterViewModelを取得する
        viewModel = _dpaDataStore.Load(this);
        if (viewModel == null)
        {
            // データが存在しない場合、入力画面にリダイレクト
            return RedirectToAction("Enter");
        }
        // EmployeeRegisterFormをドメインモデル:Employeeに変換する
        var department = _adapter.Restore(viewModel!);
        // 新しい部門を登録する
        _departmentRegisterService.Register(department);
        return View(viewModel);
    }

    /// <summary>
    /// 確認画面の[戻る]ボタンクリックアクションメソッド
    /// </summary>
    /// <returns></returns> 
    [HttpPost("Back")]
    public IActionResult Back(DepartmentRegisterViewModel viewModel)
    {
        _logger.LogInformation("[戻る]ボタンクリック:{0}", viewModel!.ToString());
        // EmployeeRegisterViewModelをシリアライズして、TempDataに保存する
        _dpaDataStore.Save(this, viewModel);
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
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