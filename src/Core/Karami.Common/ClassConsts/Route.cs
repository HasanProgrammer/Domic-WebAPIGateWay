namespace Karami.Common.ClassConsts;

public partial class Route
{
    public const string BaseUrl = "api/v{version:apiVersion}/";
}

//User
public partial class Route
{
    public const string BaseUserUrl             = "user";
    public const string ReadOneUserUrl          = "read-one";
    public const string ReadAllPaginatedUserUrl = "read-all-paginated";
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
    public const string BaseRoleUrl             = "role";
    public const string ReadOneRoleUrl          = "read-one";
    public const string ReadAllPaginatedRoleUrl = "read-all-paginated";
    public const string CreateRoleUrl           = "create";
    public const string UpdateRoleUrl           = "update";
    public const string DeleteRoleUrl           = "delete";
}

//Permission
public partial class Route
{
    public const string BasePermissionUrl             = "permission";
    public const string ReadOnePermissionUrl          = "read-one";
    public const string ReadAllPaginatedPermissionUrl = "read-all-paginated";
    public const string CreatePermissionUrl           = "create";
    public const string UpdatePermissionUrl           = "update";
    public const string DeletePermissionUrl           = "delete";
}

//Category
public partial class Route
{
    public const string BaseCategoryUrl             = "category";
    public const string ReadOneCategoryUrl          = "read-one";
    public const string ReadAllPaginatedCategoryUrl = "read-all-paginated";
    public const string CreateCategoryUrl           = "create";
    public const string UpdateCategoryUrl           = "update";
    public const string DeleteCategoryUrl           = "delete";
}

//Article
public partial class Route
{
    public const string BaseArticleUrl             = "article";
    public const string ReadOneArticleUrl          = "read-one";
    public const string ReadAllPaginatedArticleUrl = "read-all-paginated";
    public const string CreateArticleUrl           = "create";
    public const string UpdateArticleUrl           = "update";
    public const string ActiveArticleUrl           = "active";
    public const string InActiveArticleUrl         = "inactive";
    public const string DeleteArticleUrl           = "delete";
}

//AggregateArticle
public partial class Route
{
    public const string BaseAggregateArticleUrl             = "aggregate-article";
    public const string ReadOneAggregateArticleUrl          = "read-one";
    public const string ReadAllPaginatedAggregateArticleUrl = "read-all-paginated";
}

//ArticleComment
public partial class Route
{
    public const string BaseArticleCommentUrl     = "article-comment";
    public const string CreateArticleCommentUrl   = "create";
    public const string UpdateArticleCommentUrl   = "update";
    public const string ActiveArticleCommentUrl   = "active";
    public const string InActiveArticleCommentUrl = "inactive";
    public const string DeleteArticleCommentUrl   = "delete";
}

//ArticleCommentAnswer
public partial class Route
{
    public const string BaseArticleCommentAnswerUrl     = "article-comment-answer";
    public const string CreateArticleCommentAnswerUrl   = "create";
    public const string ActiveArticleCommentAnswerUrl   = "active";
    public const string InActiveArticleCommentAnswerUrl = "inactive";
    public const string DeleteArticleCommentAnswerUrl   = "delete";
}