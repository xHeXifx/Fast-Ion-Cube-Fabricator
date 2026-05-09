using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

[HarmonyPatch(typeof(AnteChamber), "UpdateScanAmountMaterials")]
public class AnteChamber_ScanSpeedPatch
{
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        float safeScanTime = Mathf.Max(0.1f, IonCubeSpeedMod.ScanTime.Value);

        foreach (var code in instructions)
        {
            if (code.opcode == OpCodes.Ldc_R4 && code.operand is float f && f == 120f)
            {
                code.operand = safeScanTime;
            }

            yield return code;
        }
    }
}