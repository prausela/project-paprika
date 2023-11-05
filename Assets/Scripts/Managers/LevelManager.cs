using System.Collections;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(LoadAsync());
        }

        IEnumerator LoadAsync()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneParams.GameScene);
            operation.allowSceneActivation = false;
            
            while (!operation.isDone)
            {
                if(operation.progress >= .9f)
                {
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
            var oldScene = SceneManager.GetActiveScene();
            var newScene = SceneManager.GetSceneByName(SceneParams.GameScene);
            if(!newScene.IsValid()) yield break;
            SceneManager.SetActiveScene(newScene);
            SceneManager.UnloadSceneAsync(oldScene);
        }
    }
}
