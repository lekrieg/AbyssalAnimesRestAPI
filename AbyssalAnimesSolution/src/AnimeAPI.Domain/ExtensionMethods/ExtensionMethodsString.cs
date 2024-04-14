namespace AnimeAPI.Domain.ExtensionMethods;

public static class ExtensionMethodsString 
{
    public static bool IsNullOrEmptyOrWhiteSpace(this string str)
    {
        return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    }
}
