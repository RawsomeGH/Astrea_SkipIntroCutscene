using Clearings;
using HarmonyLib;

namespace Astrea_SkipIntroCutscene.Patches.Shops
{
    public class ShopItem_Patches
    {
        [HarmonyPatch(typeof(ShopItem), nameof(ShopItem.GetCost))]
        public class ShopItem_GetCost
        {
            public static bool Prefix(ref int __result)
            {
                if (Plugin.PluginConfig.OverrideForgeShopPrices.Value)
                {
                    __result = Plugin.PluginConfig.ForgeShopPrice.Value;
                    return false;
                }

                // If override is disabled, let the game handle this.
                return true;
            }
        }
    }
}
