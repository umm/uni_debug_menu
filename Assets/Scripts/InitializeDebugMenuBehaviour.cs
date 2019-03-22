using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniDebugMenu
{
    public class InitializeDebugMenuBehaviour : MonoBehaviour
    {
        private TopListCreator ListCreator;

        private void Awake()
        {
            if (Debug.isDebugBuild)
            {
                this.ListCreator = new TopListCreator();
                this.ListCreator.Init();
                SceneManager.LoadScene("UniDebugMenuScene", LoadSceneMode.Additive);
                UniDebugMenuScene.mOnOpen += () => DMType.BUTTON_COL_3.Open(this.ListCreator);
            }
        }
    }
}