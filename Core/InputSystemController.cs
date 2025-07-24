namespace JamKit {
    public static class InputSystemController {
        private static bool _blocked = false;

        public static void SetInputBlocked(bool blocked) {
            _blocked = blocked;
        }

        public static bool IsInputAllowed => !_blocked;
    }
}