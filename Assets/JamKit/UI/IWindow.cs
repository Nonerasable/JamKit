namespace JamKit {
    public interface IWindow {
        bool IsOpen { get; }
        void Show();
        void Hide();
    }
}