using HarmonyLib;

namespace YeetDebris.Patches
{
    [HarmonyPatch(typeof(NoteDebrisSpawner))]
    [HarmonyPatch("SpawnDebris")]
    internal class NoteDebrisSpawner_SpawnDebris
    {
        private static bool Prefix() => !BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.playerSpecificSettings.reduceDebris;
    }
}