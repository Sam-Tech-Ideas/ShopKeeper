namespace ShopkeeperProject.Model;

public sealed record AppResponse<T>(
    string Message,
    int Code,
    bool IsSuccess,
    T? Data = default)
{
    public static T? Default = default;

    public int StatusCode { get; internal set; }
}