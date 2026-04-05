using UnityEngine;
using UnityEngine.SceneManagement;

namespace GRIMMORPG
{
    /// <summary>
    /// Persistent game manager. Lives in the Bootstrap scene and survives scene loads.
    /// Handles scene transitions and global game state.
    /// </summary>
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Settings")]
        [SerializeField] private string _firstSceneName = "BeatriceRoom";

        public string CurrentSceneName { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            LoadScene(_firstSceneName);
        }

        public void LoadScene(string sceneName)
        {
            if (!string.IsNullOrEmpty(CurrentSceneName))
            {
                Scene currentScene = SceneManager.GetSceneByName(CurrentSceneName);
                if (currentScene.isLoaded)
                {
                    SceneManager.UnloadSceneAsync(currentScene);
                }
            }

            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += operation =>
            {
                CurrentSceneName = sceneName;
                Scene loadedScene = SceneManager.GetSceneByName(sceneName);
                SceneManager.SetActiveScene(loadedScene);
            };
        }
    }
}
