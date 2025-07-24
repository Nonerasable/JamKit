using UnityEngine;
using UnityEngine.UI;

namespace JamKit.Example.UI {
    public class ThanksForPlayingWindow : BaseWindow {
        
        [SerializeField] Button _mainMenuButton;

        private void Awake() {
            _mainMenuButton.onClick.AddListener(HandleMainMenuButtonClicked);
        }

        private void HandleMainMenuButtonClicked() {
            Close();
            ServiceLocator.Get<SceneLoader>().LoadMainMenu();
        }
    }
}