using HarmonyLib;
using IPA;
using System.Reflection;

namespace YeetDebris
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private const string HarmonyID = "com.steven.yeet.debris";

        private Harmony? _harmonyInstance;

        [OnEnable]
        public void OnEnable()
        {
            _harmonyInstance = new Harmony(HarmonyID);
            _harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            _harmonyInstance?.UnpatchAll(HarmonyID);
            _harmonyInstance = null;
        }
    }
}