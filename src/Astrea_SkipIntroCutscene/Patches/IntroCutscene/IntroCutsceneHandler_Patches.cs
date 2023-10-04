using Clearings;
using HarmonyLib;

namespace Astrea_SkipIntroCutscene.Patches.IntroCutscene
{
    [HarmonyPatch(typeof(IntroCutsceneHandler), nameof(IntroCutsceneHandler.Update))]
    public class IntroCutsceneHandler_Update
    {
        public static bool Prefix(IntroCutsceneHandler __instance)
        {
            if (__instance.gameController != null)
            {
                __instance.gameController.GoToMainMenu();
                return false;
            }
            else
            {
                Plugin.PluginLogger.LogMessage($"{typeof(IntroCutsceneHandler)}.{nameof(__instance.gameController)} is null.");
            }

            return true;
        }
    }
}
