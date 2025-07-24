using JamKit.Example.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JamKit.Example {
    public class PlayerInputController : MonoBehaviour {
        
        [SerializeField] private PauseWindow _pauseWindow;

        private InputActions _inputActions;
        
        private void Start() {
            var inputMapController = ServiceLocator.Get<InputMapController>();
            inputMapController.SetInputMode(InputMode.Game);
            _inputActions = inputMapController.InputActions;
            _inputActions.Game.Pause.performed += HandlePausePerformed;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDestroy() {
            if (_inputActions != null) {
                _inputActions.Game.Pause.performed -= HandlePausePerformed;
            }
        }

        private void HandlePausePerformed(InputAction.CallbackContext obj) {
            var uiManager = ServiceLocator.Get<UIManager>();
            uiManager.ShowWindow(_pauseWindow);
        }
    }
}