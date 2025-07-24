using UnityEngine;

namespace JamKit {
    public class SceneBootstrapper : MonoBehaviour {
        private void Awake() {
            ServiceLocator.EnsureInitialized();
        }

        private void Update() {
            ServiceLocator.TickAll(Time.deltaTime);
        }
    }
}