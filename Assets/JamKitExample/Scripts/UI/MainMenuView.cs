using UnityEngine;
using UnityEngine.UI;

namespace JamKit.Example {
    public class MainMenuView : MonoBehaviour, IWindow {

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private LevelConfig _firstLevelConfig;

        public bool IsOpen => gameObject.activeSelf;
        
        private void Awake() {
            _playButton.onClick.AddListener(HandlePlayButtonClick);
            _quitButton.onClick.AddListener(HandleQuitButtonClick);
        }

        private void HandlePlayButtonClick() {
            var loader = ServiceLocator.Get<SceneLoader>();
            loader.LoadLevel(_firstLevelConfig);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        private void HandleQuitButtonClick() {
            Application.Quit();
        }
    }
}