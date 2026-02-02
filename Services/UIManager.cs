using System.Collections.Generic;
using UnityEngine;

namespace JamKit {
    public class UIManager : IService {

        private readonly List<IWindow> _openWindows = new();
        
        public void Initialize() { }

        public void ShowWindow(IWindow window) {
            if (window == null || window.IsOpen) return;
            
            window.Show();
            _openWindows.Add(window);
            UpdateInputState();
        }

        public void HideWindow(IWindow window) {
            if (window == null || !window.IsOpen) return;
            
            window.Hide();
            _openWindows.Remove(window);
            UpdateInputState();
        }

        public void CloseAll() {
            foreach (var window in _openWindows) {
                window.Hide();
            }
            _openWindows.Clear();
            UpdateInputState();
        }

        private void UpdateInputState() {
            var hasUI = _openWindows.Count > 0;
            Cursor.visible = hasUI;
            Cursor.lockState = hasUI ? CursorLockMode.None : CursorLockMode.Locked;
            var inputMapController = ServiceLocator.GetOrCreate<InputMapController>();
            inputMapController.SetInputMode(hasUI ? InputMode.UI : InputMode.Game);
        }
    }
}