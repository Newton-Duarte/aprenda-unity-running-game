using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    [SerializeField] Animator animator;
    int sceneIdToGo;

    internal void startFade(int sceneIndex)
    {
        sceneIdToGo = sceneIndex;
        animator.SetTrigger("FadeOut");
    }

    internal void OnSceneComplete()
    {
        SceneManager.LoadScene(sceneIdToGo);
    }
}
