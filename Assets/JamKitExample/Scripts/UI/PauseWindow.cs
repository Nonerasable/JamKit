using UnityEngine;
using UnityEngine.UI;

namespace JamKit.Example.UI {
    public class PauseWindow : BaseWindow {
        
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _mainMenuButton;

        private void Awake() {
            _resumeButton.onClick.AddListener(Close);
            _mainMenuButton.onClick.AddListener(OnQuitToMenuPressed);
        }

        private void OnEnable() {
            Time.timeScale = 0f;
        }

        private void OnDisable() {
            Time.timeScale = 1f;
        }

        private void OnQuitToMenuPressed() {
            Time.timeScale = 1f;
            ServiceLocator.Get<SceneLoader>().LoadMainMenu();
        }
    }
}