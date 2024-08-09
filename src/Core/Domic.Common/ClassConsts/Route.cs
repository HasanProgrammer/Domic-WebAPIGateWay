namespace Domic.Common.ClassConsts;

public partial class Route
{
    public const string BaseUrl = "api/v{version:apiVersion}/";
}

//User
public partial class Route
{
    public const string BaseUserUrl             = "users";
    public const string ReadOneUserUrl          = "{UserId}";
    public const string ReadAllPaginatedUserUrl = "";
    public const string CreateUserUrl           = "create";
    public const string UpdateUserUrl           = "update";
    public const string ActiveUserUrl           = "active";
    public const string InActiveUserUrl         = "inactive";
    public const string RevokeUrl               = "revoke";
    public const string SignInUserUrl           = "signin";
}

//Role
public partial class Route
{
    public const string BaseRoleUrl             = "roles";
    public const string ReadOneRoleUrl          = "{RoleId}";
    public const string ReadAllPaginatedRoleUrl = "";
    public const string CreateRoleUrl           = "create";
    public const string UpdateRoleUrl           = "update";
    public const string DeleteRoleUrl           = "delete";
}

//Permission
public partial class Route
{
    public const string BasePermissionUrl             = "permissions";
    public const string ReadOnePermissionUrl          = "{PermissionId}";
    public const string ReadAllPaginatedPermissionUrl = "";
    public const string CreatePermissionUrl           = "create";
    public const string UpdatePermissionUrl           = "update";
    public const string DeletePermissionUrl           = "delete";
}

//Category
public partial class Route
{
    public const string BaseCategoryUrl             = "categories";
    public const string ReadOneCategoryUrl          = "{CategoryId}";
    public const string ReadAllPaginatedCategoryUrl = "";
    public const string CreateCategoryUrl           = "create";
    public const string UpdateCategoryUrl           = "update";
    public const string DeleteCategoryUrl           = "delete";
}

//Article
public partial class Route
{
    public const string BaseArticleUrl             = "articles";
    public const string ReadOneArticleUrl          = "{TargetId}";
    public const string ReadAllPaginatedArticleUrl = "";
    public const string CreateArticleUrl           = "create";
    public const string UpdateArticleUrl           = "update";
    public const string ActiveArticleUrl           = "active";
    public const string InActiveArticleUrl         = "inactive";
    public const string DeleteArticleUrl           = "delete";
}

//AggregateArticle
public partial class Route
{
    public const string BaseAggregateArticleUrl             = "aggregate-articles";
    public const string ReadOneAggregateArticleUrl          = "";
    public const string ReadAllPaginatedAggregateArticleUrl = "";
}

//ArticleComment
public partial class Route
{
    public const string BaseArticleCommentUrl     = "article-comments";
    public const string CreateArticleCommentUrl   = "create";
    public const string UpdateArticleCommentUrl   = "update";
    public const string ActiveArticleCommentUrl   = "active";
    public const string InActiveArticleCommentUrl = "inactive";
    public const string DeleteArticleCommentUrl   = "delete";
}

//ArticleCommentAnswer
public partial class Route
{
    public const string BaseArticleCommentAnswerUrl     = "article-comment-answers";
    public const string CreateArticleCommentAnswerUrl   = "create";
    public const string ActiveArticleCommentAnswerUrl   = "active";
    public const string InActiveArticleCommentAnswerUrl = "inactive";
    public const string DeleteArticleCommentAnswerUrl   = "delete";
}

//Term
public partial class Route
{
    public const string BaseTermUrl             = "terms";
    public const string ReadOneTermUrl          = "{TermId}";
    public const string ReadAllPaginatedTermUrl = "";
    public const string CreateTermUrl           = "create";
    public const string ActiveTermUrl           = "active";
    public const string InActiveTermUrl         = "inactive";
    public const string UpdateTermUrl           = "update";
    public const string DeleteTermUrl           = "delete";
}

//Video
public partial class Route
{
    public const string BaseVideoUrl             = "videos";
    public const string ReadOneVideoUrl          = "{VideoId}";
    public const string ReadAllPaginatedVideoUrl = "";
    public const string CreateVideoUrl           = "create";
    public const string ActiveVideoUrl           = "active";
    public const string InActiveVideoUrl         = "inactive";
    public const string UpdateVideoUrl           = "update";
    public const string DeleteVideoUrl           = "delete";
}

//Ticket
public partial class Route
{
    public const string BaseTicketUrl             = "tickets";
    public const string ReadOneTicketUrl          = "{TicketId}";
    public const string ReadAllPaginatedTicketUrl = "";
    public const string CreateTicketUrl           = "create";
    public const string ActiveTicketUrl           = "active";
    public const string InActiveTicketUrl         = "inactive";
    public const string UpdateTicketUrl           = "update";
    public const string DeleteTicketUrl           = "delete";
}

//AggregateTerm
public partial class Route
{
    public const string BaseAggregateTermUrl              = "aggregate-terms";
    public const string ReadOneAggregateTermUrl           = "";
    public const string ReadAllPaginatedAggregateTermUrl  = "terms";
    public const string ReadAllPaginatedAggregateVideoUrl = "videos";
}