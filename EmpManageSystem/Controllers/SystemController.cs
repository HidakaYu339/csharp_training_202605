///<summary>
///リスト10-8 InternalException(内部エラー)を処理するMiddleware演習２７
///</summary>
using Microsoft.AspNetCore.Mvc;
namespace EmpManageSystem.Presentations.Controllers;
/// <summary>
/// システム停止中画面用コントローラ
/// </summary>
public class SystemController : Controller
{
    [HttpGet]
    public IActionResult Maintenance()
    {
        return View();
    }
}