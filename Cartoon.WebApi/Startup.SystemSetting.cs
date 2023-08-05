using Cartoon.Core.Configs;

namespace Cartoon.WebApi
{
    public static class StartupSystemSetting
    {
        public static IServiceCollection AddSystemSetting(this IServiceCollection services, SystemSettingModel systemSettingModel)
        {
            SystemSettingModel.Instance = systemSettingModel ?? new SystemSettingModel();

            return services;
        }
    }
}
