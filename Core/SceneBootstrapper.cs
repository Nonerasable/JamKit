using UnityEngine;
using UnityEngine.Audio;

namespace JamKit {
    public class SceneBootstrapper : MonoBehaviour {
        
        [SerializeField] AudioMixer _audioMixer;
        
        private void Awake() {
            ServiceLocator.EnsureInitialized(_audioMixer);
        }

        private void Update() {
            ServiceLocator.TickAll(Time.deltaTime);
        }
    }
}