using UnityEngine;

namespace JamKit.Example {
    public class MainMenuStartup : MonoBehaviour {
        
        [SerializeField] private MainMenuView _mainMenuView;

        private void Start() {
            ServiceLocator.Get<UIManager>().ShowWindow(_mainMenuView);
        }
    }
}