using UnityEngine;

namespace JamKit {
    public class BaseWindow : MonoBehaviour, IWindow {
        
        public bool IsOpen => gameObject.activeSelf;

        public virtual void Show() {
            gameObject.SetActive(true);
        }

        public virtual void Hide() {
            gameObject.SetActive(false);
        }

        protected void Close() {
            ServiceLocator.Get<UIManager>().HideWindow(this);
        }
    }
}