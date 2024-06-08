using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.AdminPanel;

[Route(Route.BaseUrl + Route.BaseArticleCommentUrl)]
public class BaseArticleCommentController : ControllerBase;