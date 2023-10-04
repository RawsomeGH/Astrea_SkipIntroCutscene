using Astrea_SkipIntroCutscene.Configuration;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using System.Reflection;

namespace Astrea_SkipIntroCutscene
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess(Constants.GAME_PROCESS_NAME)]
    public class Plugin : BasePlugin
    {
        internal static ManualLogSource PluginLogger;
        internal static PluginConfig PluginConfig;

        public Plugin()
        {
            // Keep the default plugin log source around so we don't have to create ManualLogSources everywhere.
            PluginLogger = Log;
        }

        public override void Load()
        {
            PluginConfig = GetBoundPluginConfig();

            var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        private PluginConfig GetBoundPluginConfig()
        {
            var config = new PluginConfig
            {
                OverrideForgeShopPrices = Config.Bind(
                    ConfigKeys.ForgeShopPriceOverride.CATEGORY,
                    ConfigKeys.ForgeShopPriceOverride.ENABLED,
                    false,
                    $"If true, forge shop prices are overriden (price configurable via {ConfigKeys.ForgeShopPriceOverride.PRICE})."),
                ForgeShopPrice = Config.Bind(
                    ConfigKeys.ForgeShopPriceOverride.CATEGORY,
                    ConfigKeys.ForgeShopPriceOverride.PRICE,
                    50,
                    "Price to set forge shop items to."
                    )
            };

            return config;
        }
    }
}