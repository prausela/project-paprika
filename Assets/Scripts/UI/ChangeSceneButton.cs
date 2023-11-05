using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ChangeSceneButton : MonoBehaviour
    {
        [SerializeField] private string _loadSceneName;
        [SerializeField] private PlayerType _2PlayerType;
        [SerializeField] private float _AIDifficulty;
        
        public void ChangeScene(string sceneToLoad)
        {
            SceneParams.Player2Type = _2PlayerType;
            SceneParams.GameScene = sceneToLoad;
            SceneParams.AIDifficulty = _AIDifficulty;
            SceneManager.LoadScene(_loadSceneName);
        }

    }
}
