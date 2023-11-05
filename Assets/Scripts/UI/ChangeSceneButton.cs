using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ChangeSceneButton : MonoBehaviour
    {
        [SerializeField] private string _loadSceneName;
        
        public void ChangeScene(string sceneToLoad)
        {
            SceneParams.GameScene = sceneToLoad;
            SceneManager.LoadScene(_loadSceneName);
        }

    }
}
