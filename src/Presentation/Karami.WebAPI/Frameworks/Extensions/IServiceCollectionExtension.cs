//Scope  | PerRequest , One Object   | به ازای هر درخواست ؛ تنها یک شی از شی مورد نظر میسازد
//Trans  | PerRequest , Multi Object | به ازای هر درخواست ؛ هر بار که شی مورد نظر خواسته شود ، آن را میسازد
//Single | AllRequest , One Object   | برای هر بار درخواست تا موقعی که شی ساخته شده در حافظه باشد ؛ از همان استفاده می کند

namespace Karami.WebAPI.Frameworks.Extensions;

public static class IServiceCollectionExtension
{
    
}