using Microsoft.AspNetCore.Mvc;
using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.AdminPanel;

[Route(Route.BaseUrl + Route.BaseAggregateVideoUrl)]
public class BaseAggregateVideoController : ControllerBase;