namespace JamKit {
    public class InputMapController : IService {

        public InputActions InputActions => _actions;
        
        private InputActions _actions;
        private InputMode _currentMode;
        public void Initialize() {
            _actions = new InputActions();
            SetInputMode(InputMode.UI);
        }

        public void SetInputMode(InputMode inputMode) {
            if (_currentMode == inputMode) return;
            
            _actions.Disable();
            _currentMode = inputMode;
            switch (_currentMode) {
                case InputMode.Game:
                    _actions.Game.Enable();
                    break;
                case InputMode.UI:
                    _actions.UI.Enable();
                    break;
            }
        }
    }
}