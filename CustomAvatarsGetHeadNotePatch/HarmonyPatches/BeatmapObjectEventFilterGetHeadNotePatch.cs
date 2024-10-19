using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using CustomAvatar.Utilities;

namespace CustomAvatarsGetHeadNotePatch.HarmonyPatches
{
    [HarmonyPatch(typeof(BeatmapObjectEventFilter), nameof(BeatmapObjectEventFilter.GetHeadNote))]
    public class BeatmapObjectEventFilterGetHeadNotePatch
    {
        static bool Prefix(NoteData noteData, ref NoteData __result, List<NoteData> ____burstSliderHeadNoteDatas)
        {
            __result = ____burstSliderHeadNoteDatas.FirstOrDefault(nd => nd.time <= noteData.time && nd.colorType == noteData.colorType) ?? noteData;
            return false;
        }
    }
}
