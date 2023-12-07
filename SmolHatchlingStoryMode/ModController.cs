using OWML.Common;
using OWML.ModHelper;

namespace SmolHatchlingStoryMode
{
    public class ModController : ModBehaviour
    {
        public INewHorizons NewHorizonsAPI;
        public static ModController Instance;
        public StoryController _storyController;

        public override void Configure(IModConfig config)
        {
            base.Configure(config);
        }

        public void Awake()
        {
            Instance = this;
            gameObject.AddComponent<StoryController>();
        }

        public void Start()
        {
            NewHorizonsAPI = ModHelper.Interaction.TryGetModApi<INewHorizons>("xen.NewHorizons");
            NewHorizonsAPI.LoadConfigs(this);
            // Ready
            ModHelper.Console.WriteLine($"Smol Hatchling Story Mode is ready to go!", MessageType.Success);
        }
    }
}