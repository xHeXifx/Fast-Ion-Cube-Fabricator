using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

[HarmonyPatch(typeof(AnteChamber), "UpdateScanAmountMaterials")]
public class AnteChamber_ScanSpeedPatch
{
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (var code in instructions)
        {
            if (code.opcode == OpCodes.Ldc_R4 && code.operand is float f && f == 120f)
            {
                code.operand = IonCubeSpeedMod.ScanTime.Value;
            }

            yield return code;
        }
    }
}