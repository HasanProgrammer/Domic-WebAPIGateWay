namespace Domic.Common.ClassConsts;

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
    public const string DownloadStorageUrl = "download/{file}";
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
    public const string SignUpStudentUrl        = "signup/student";
    public const string SignUpTeacherUrl        = "signup/teacher";
    public const string SignUpCompanyUrl        = "signup/company";
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

//Campaign
public partial class Route
{
    public const string BaseCampaignUrl             = "campaigns";
    public const string ReadOneCampaignUrl          = "{Id}";
    public const string ReadAllPaginatedCampaignUrl = "";
    public const string CreateCampaignUrl           = "";
    public const string ActiveCampaignUrl           = "active/{Id}";
    public const string InActiveCampaignUrl         = "inactive/{Id}";
    public const string UpdateCampaignUrl           = "";
    public const string DeleteCampaignUrl           = "{Id}";
}

//Season
public partial class Route
{
    public const string BaseSeasonUrl                 = "seasons";
    public const string ReadOneSeasonUrl              = "{Id}";
    public const string ReadAllPaginatedSeasonUrl     = "";
    public const string ReadAllSeasonBasedOnTermIdUrl = "based-on-term/{TermId}";
    public const string CreateSeasonUrl               = "";
    public const string ActiveSeasonUrl               = "active/{Id}";
    public const string InActiveSeasonUrl             = "inactive/{Id}";
    public const string UpdateSeasonUrl               = "";
    public const string DeleteSeasonUrl               = "{Id}";
}

//Video
public partial class Route
{
    public const string BaseVideoUrl             = "videos";
    public const string ReadOneVideoUrl          = "{Id}";
    public const string ReadAllPaginatedVideoUrl = "";
    public const string CreateVideoUrl           = "";
    public const string ActiveVideoUrl           = "active/{Id}";
    public const string InActiveVideoUrl         = "inactive/{Id}";
    public const string UpdateVideoUrl           = "";
    public const string DeleteVideoUrl           = "";
}

//TermComment ( CommentService | Command )
public partial class Route
{
    public const string BaseTermCommentUrl     = "term-comments";
    public const string CreateTermCommentUrl   = "";
    public const string ActiveTermCommentUrl   = "active/{Id}";
    public const string InActiveTermCommentUrl = "inactive/{Id}";
    public const string UpdateTermCommentUrl   = "";
    public const string DeleteTermCommentUrl   = "{Id}";
}

//TermCommentAnswer ( CommentService | Command )
public partial class Route
{
    public const string BaseTermCommentAnswerUrl     = "term-comment-answers";
    public const string CreateTermCommentAnswerUrl   = "";
    public const string ActiveTermCommentAnswerUrl   = "active/{Id}";
    public const string InActiveTermCommentAnswerUrl = "inactive/{Id}";
    public const string UpdateTermCommentAnswerUrl   = "";
    public const string DeleteTermCommentAnswerUrl   = "{Id}";
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

//Company
public partial class Route
{
    public const string BaseCompanyUrl              = "companies";
    public const string ReadOneCompanyUrl           = "{Id}";
    public const string ReadAllPaginatedCompanyUrl  = "";
    public const string CreateCompanyUrl            = "";
    public const string ActiveCompanyUrl            = "active/{Id}";
    public const string InActiveCompanyUrl          = "inactive/{Id}";
    public const string UpdateCompanyUrl            = "";
    public const string DeleteCompanyUrl            = "{Id}";
}

//Skill
public partial class Route
{
    public const string BaseSkillUrl              = "skills";
    public const string ReadOneSkillUrl           = "{Id}";
    public const string ReadAllPaginatedSkillUrl  = "";
    public const string CreateSkillUrl            = "";
    public const string ActiveSkillUrl            = "active/{Id}";
    public const string InActiveSkillUrl          = "inactive/{Id}";
    public const string UpdateSkillUrl            = "";
    public const string DeleteSkillUrl            = "{Id}";
}

//Stack
public partial class Route
{
    public const string BaseStackUrl              = "stacks";
    public const string ReadOneStackUrl           = "{Id}";
    public const string ReadAllPaginatedStackUrl  = "";
    public const string CreateStackUrl            = "";
    public const string ActiveStackUrl            = "active/{Id}";
    public const string InActiveStackUrl          = "inactive/{Id}";
    public const string UpdateStackUrl            = "";
    public const string DeleteStackUrl            = "{Id}";
}

//Stack
public partial class Route
{
    public const string BaseAnnouncementUrl              = "announcements";
    public const string ReadOneAnnouncementUrl           = "{Id}";
    public const string ReadAllPaginatedAnnouncementUrl  = "";
    public const string CreateAnnouncementUrl            = "";
    public const string ActiveAnnouncementUrl            = "active/{Id}";
    public const string InActiveAnnouncementUrl          = "inactive/{Id}";
    public const string UpdateAnnouncementUrl            = "";
    public const string DeleteAnnouncementUrl            = "{Id}";
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
    public const string BaseAggregateTermUrl                       = "aggregate-terms";
    public const string ReadOneAggregateTermUrl                    = "{Id}";
    public const string ReadAllPaginatedAggregateTermUrl           = "terms";
    public const string ReadAllPaginatedAggregateSeasonUrl         = "seasons";
    public const string ReadAllPaginatedAggregateBookUrl           = "books";
    public const string ReadAllPaginatedAggregateVideoUrl          = "videos";
    public const string ReadAllPaginatedAggregateCampaignUrl       = "campaigns";
    public const string ReadAllPaginatedAggregateCommentUrl        = "comments";
    public const string ReadOneAggregateCommentUrl                 = "comments/{Id}";
    public const string ReadAllPaginatedAggregateCommentAnswersUrl = "comments/{CommentId}/answers";
    public const string ReadOneAggregateCommentAnswerUrl           = "answers/{Id}";
}

//Fiancial
public partial class Route
{
    public const string BaseFinancialUrl = "financials";
    public const string GetCurrentUserCurrentBalence = "current-balence";
    public const string GetAllTransactionFinancialUrl = "transactions";
    public const string GetAllTransactionRequestFinancialUrl = "transaction-requests";
    public const string CreateFinancialUrl = "";
    public const string UpdateFinancialUrl = "";
    public const string CreateTransactionRequestFinancialUrl = "transaction-requests";
    public const string ChangeStatusTransactionRequestFinancialUrl = "transaction-requests";
    public const string DecreaseWalletFinancialUrl = "decrease-wallet";
}