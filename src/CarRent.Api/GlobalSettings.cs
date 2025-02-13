using Microsoft.AspNetCore.Mvc;

namespace CarRent.Api;

public static class GlobalSettings
{
    public static ApiVersion ApiVer => new ApiVersion(DateTime.Parse("03/05/2024 00:00"), 1, 0);
    public const string API_VERSION = "1";
}
