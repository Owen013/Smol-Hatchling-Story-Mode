using OWML.Common;
using OWML.ModHelper;

namespace SmolHatchlingStoryMode
{
    public class SmolHatchlingStoryMode : ModBehaviour
    {
        // Config
        public bool _storyEnabled;

        // Other
        public static SmolHatchlingStoryMode Instance;
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
            // Ready
            ModHelper.Console.WriteLine($"Smol Hatchling Story Mode is ready to go!", MessageType.Success);
        }
    }
}