using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniDebugMenu
{
    public class InitializeDebugMenuBehaviour : MonoBehaviour
    {
        private const string SCENE_NAME = "UniDebugMenuScene";

        private TopListCreator ListCreator;

        private void Awake()
        {
            if (CanLoadScene() && Debug.isDebugBuild)
            {
                this.ListCreator = new TopListCreator();
                this.ListCreator.Init();
                SceneManager.LoadScene(SCENE_NAME, LoadSceneMode.Additive);
                UniDebugMenuScene.mOnOpen += () => DMType.BUTTON_COL_3.Open(this.ListCreator);
            }
        }

        private bool CanLoadScene()
        {
            return Enumerable
                .Range(0, SceneManager.sceneCountInBuildSettings)
                .Select(SceneUtility.GetScenePathByBuildIndex)
                .Select(Path.GetFileNameWithoutExtension)
                .Any(x => x == SCENE_NAME);
        }
    }
}
