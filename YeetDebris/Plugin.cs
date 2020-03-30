using HarmonyLib;
using IPA;
using System.Reflection;
namespace YeetDebris
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        const string harmonyID = "com.steven.yeet.debris";
        Harmony harmony;
        MethodInfo original;
        MethodInfo prefix;
        [Init]
        public void Init()
        {
            original = typeof(NoteDebrisSpawner).GetMethod("SpawnDebris");
            prefix = typeof(Plugin).GetMethod("Prefix");
        }
        [OnEnable]
        public void OnEnable()
        {
            harmony = new Harmony(harmonyID);
            BS_Utils.Utilities.BSEvents.gameSceneLoaded += GameSceneLoaded;
        }
        [OnDisable]
        public void OnDisable()
        {
            if (Harmony.HasAnyPatches(harmonyID))
                harmony.UnpatchAll(harmonyID);
            BS_Utils.Utilities.BSEvents.gameSceneLoaded -= GameSceneLoaded;
        }
        private void GameSceneLoaded()
        {
            if (!BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.playerSpecificSettings.reduceDebris)
                harmony.Patch(original, prefix:new HarmonyMethod(prefix));
            else if (Harmony.HasAnyPatches(harmonyID))
                harmony.UnpatchAll(harmonyID);
        }
        internal static bool Prefix() => false;
    }
}
