using UnityEngine;

namespace JamKit {
    
    [CreateAssetMenu(menuName = "JamKit/Level Config", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject {
        public string LevelId;
        public string LevelName;
    }
}