﻿namespace Domic.Common.ClassConsts;

public partial class Route
{
    public const string BaseHomeUrl = "api/v{version:apiVersion}/";
    public const string BaseBackOfficeUrl = "api/v{version:apiVersion}/admin/";
}

//Storage
public partial class Route
{
    public const string BaseStorageUrl = "storages";
    public const string UploadStorageUrl = "upload";
}

//User
public partial class Route
{
    public const string BaseUserUrl             = "users";
    public const string ReadOneUserUrl          = "{Id}";
    public const string ProfileUserUrl          = "current-profile";
    public const string ReadAllPaginatedUserUrl = "";
    public const string CreateUserUrl           = "";
    public const string UpdateUserUrl           = "";
    public const string ActiveUserUrl           = "active/{Id}";
    public const string InActiveUserUrl         = "inactive/{Id}";
    public const string SignInUserUrl           = "signin";
    public const string OtpGenerationUserUrl    = "otp-generation";
    public const string OtpVerificationUserUrl  = "otp-verification";
    public const string SignUpUserUrl           = "signup";
}

//Role
public partial class Route
{
    public const string BaseRoleUrl             = "roles";
    public const string ReadOneRoleUrl          = "{Id}";
    public const string ReadAllPaginatedRoleUrl = "";
    public const string CreateRoleUrl           = "";
    public const string UpdateRoleUrl           = "";
    public const string DeleteRoleUrl           = "{Id}";
}

//Permission
public partial class Route
{
    public const string BasePermissionUrl                         = "permissions";
    public const string ReadOnePermissionUrl                      = "{Id}";
    public const string ReadAllPaginatedPermissionUrl             = "";
    public const string ReadAllBasedOnRolesPaginatedPermissionUrl = "based-on-roles";
    public const string CreatePermissionUrl                       = "";
    public const string UpdatePermissionUrl                       = "";
    public const string DeletePermissionUrl                       = "{Id}";
}

//Category
public partial class Route
{
    public const string BaseCategoryUrl             = "categories";
    public const string ReadOneCategoryUrl          = "{Id}";
    public const string ReadAllPaginatedCategoryUrl = "";
    public const string CreateCategoryUrl           = "";
    public const string UpdateCategoryUrl           = "";
    public const string DeleteCategoryUrl           = "{Id}";
}

//Article
public partial class Route
{
    public const string BaseArticleUrl             = "articles";
    public const string ReadOneArticleUrl          = "{TargetId}";
    public const string ReadAllPaginatedArticleUrl = "";
    public const string CreateArticleUrl           = "";
    public const string UpdateArticleUrl           = "";
    public const string ActiveArticleUrl           = "active";
    public const string InActiveArticleUrl         = "inactive";
    public const string DeleteArticleUrl           = "";
}

//AggregateArticle
public partial class Route
{
    public const string BaseAggregateArticleUrl             = "aggregate-articles";
    public const string ReadOneAggregateArticleUrl          = "{Id}";
    public const string ReadAllPaginatedAggregateArticleUrl = "";
    public const string ReadAllPaginatedAggregateArticleCurrentUserUrl = "current-user";
}

//ArticleComment
public partial class Route
{
    public const string BaseArticleCommentUrl     = "article-comments";
    public const string CreateArticleCommentUrl   = "";
    public const string UpdateArticleCommentUrl   = "";
    public const string ActiveArticleCommentUrl   = "active";
    public const string InActiveArticleCommentUrl = "inactive";
    public const string DeleteArticleCommentUrl   = "";
}

//ArticleCommentAnswer
public partial class Route
{
    public const string BaseArticleCommentAnswerUrl     = "article-comment-answers";
    public const string CreateArticleCommentAnswerUrl   = "";
    public const string ActiveArticleCommentAnswerUrl   = "active";
    public const string InActiveArticleCommentAnswerUrl = "inactive";
    public const string DeleteArticleCommentAnswerUrl   = "";
}

//Term
public partial class Route
{
    public const string BaseTermUrl             = "terms";
    public const string ReadOneTermUrl          = "{Id}";
    public const string ReadAllPaginatedTermUrl = "";
    public const string CreateTermUrl           = "";
    public const string ActiveTermUrl           = "active/{Id}";
    public const string InActiveTermUrl         = "inactive/{Id}";
    public const string UpdateTermUrl           = "";
    public const string DeleteTermUrl           = "{Id}";
}

//Video
public partial class Route
{
    public const string BaseVideoUrl             = "videos";
    public const string ReadOneVideoUrl          = "{Id}";
    public const string ReadAllPaginatedVideoUrl = "";
    public const string CreateVideoUrl           = "";
    public const string ActiveVideoUrl           = "active";
    public const string InActiveVideoUrl         = "inactive";
    public const string UpdateVideoUrl           = "";
    public const string DeleteVideoUrl           = "";
}

//Ticket
public partial class Route
{
    public const string BaseTicketUrl             = "tickets";
    public const string ReadOneTicketUrl          = "{TicketId}";
    public const string ReadAllPaginatedTicketUrl = "";
    public const string CreateTicketUrl           = "";
    public const string CreateTicketCommentUrl    = "comments";
    public const string ActiveTicketUrl           = "active";
    public const string InActiveTicketUrl         = "inactive";
    public const string UpdateTicketUrl           = "";
    public const string DeleteTicketUrl           = "";
}

//AggregateTicket
public partial class Route
{
    public const string BaseAggregateTicketUrl             = "aggregate-tickets";
    public const string ReadOneAggregateTicketUrl          = "{TicketId}";
    public const string ReadAllPaginatedAggregateTicketUrl = "";
}

//AggregateTerm
public partial class Route
{
    public const string BaseAggregateTermUrl              = "aggregate-terms";
    public const string ReadOneAggregateTermUrl           = "{Id}";
    public const string ReadAllPaginatedAggregateTermUrl  = "terms";
    public const string ReadAllPaginatedAggregateVideoUrl = "videos";
}

//Fiancial
public partial class Route
{
    public const string BaseFinancialUrl = "financials";
    public const string GetAllTransactionRequestFinancialUrl = "transaction-requests";
    public const string CreateFinancialUrl = "";
    public const string UpdateFinancialUrl = "";
    public const string CreateTransactionRequestFinancialUrl = "transaction-requests";
    public const string ChangeStatusTransactionRequestFinancialUrl = "transaction-requests";
    public const string DecreaseWalletFinancialUrl = "decrease-wallet";
}