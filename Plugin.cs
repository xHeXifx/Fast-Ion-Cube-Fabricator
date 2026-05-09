using System.Runtime.Serialization;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

[BepInPlugin("com.hexif.fastioncubefabricator", "Fast Ion Cube Fabricator", "1.0.0")]
public class IonCubeSpeedMod : BaseUnityPlugin
{
    internal static ConfigEntry<float> ScanTime;

    private void Awake()
    {
        ScanTime = Config.Bind(
            "General",
            "Scan Duration",
            10f,
            "Time in seconds for ion cube regeneration"
        );

        ScanTime.SettingChanged += OnScanTimeChanged;

        var harmony = new Harmony("com.hexif.fastioncubefabricator");
        harmony.PatchAll();
        Logger.LogInfo("Fast Ion Cube Fabricator loaded");
    }

    private void OnScanTimeChanged(object sender, System.EventArgs e)
    {
        Logger.LogInfo("Scan time updated: " + ScanTime.Value);
    }
}