using HarmonyLib;
using UnityEngine;

namespace SmolHatchlingStoryMode
{
    public class StoryController : MonoBehaviour
    {
        public static StoryController Instance;
        public bool _busted;

        public void Awake()
        {
            Instance = this;
            Harmony.CreateAndPatchAll(typeof(StoryController));
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CharacterDialogueTree), nameof(CharacterDialogueTree.EndConversation))]
        public static void EndConversation()
        {
            if (DialogueConditionManager.s_instance.GetConditionState("Busted") && !Instance._busted)
            {
                Instance._busted = true;
                Locator.GetShipBody().GetComponentInChildren<ShipCockpitController>().LockUpControls(Mathf.Infinity);
                NotificationManager.s_instance.PostNotification(new NotificationData(NotificationTarget.Player, "SHIP HAS BEEN DISABLED BY GROUND CONTROL", 5f), false);
                NotificationManager.s_instance.PostNotification(new NotificationData(NotificationTarget.Ship, "SHIP DISABLED"), true);
            }
        }
    }
}