using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace JamKit {
    
    public class LoadingScreenController : MonoBehaviour {
        
        [SerializeField] private Slider progressBar;

        private void Start() {
            StartCoroutine(LoadAsync());
        }

        private IEnumerator LoadAsync() {
            yield return ServiceLocator.Get<SceneLoader>().LoadTargetLevelAsync(
                progress => progressBar.value = progress
            );
        }
    }
}