using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JamKit {
    public class SceneLoader : IService {
        
        private const string LOADING_SCENE_NAME = "LoadingScene";
        private const string MAIN_MENU_SCENE_NAME = "MainMenu";
        
        private LevelConfig _currentLevelConfig;
        
        public void Initialize() { }

        public void LoadLevel(LevelConfig config) {
            _currentLevelConfig = config;
            SceneManager.LoadScene(LOADING_SCENE_NAME);
        }

        public void LoadMainMenu() {
            SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ServiceLocator.TryGet<InputMapController>().SetInputMode(InputMode.UI);
        }

        public LevelConfig GetCurrentLevelConfig() {
            return _currentLevelConfig;
        }

        public IEnumerator LoadTargetLevelAsync(Action<float> onProgress) {
            var async = SceneManager.LoadSceneAsync(_currentLevelConfig.LevelId);
            async.allowSceneActivation = false;

            var fakeProgress = 0.0f;
            while (fakeProgress < 1f) {
                fakeProgress += Time.deltaTime * 0.5f;
                var realProgress = Mathf.Min(fakeProgress, async.progress/0.9f);
                onProgress?.Invoke(realProgress);

                if (fakeProgress >= 1.0f && async.progress >= 0.9f) {
                    break;
                }
                yield return null;
            }
            onProgress?.Invoke(1.0f);
            async.allowSceneActivation = true;
        }
    }
}