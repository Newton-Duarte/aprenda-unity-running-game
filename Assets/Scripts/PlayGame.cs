using UnityEngine;

public class PlayGame : MonoBehaviour
{
    OptionsController _optionsController;
    TransitionController _transitionController;

    private void Start()
    {
        _optionsController = FindObjectOfType(typeof(OptionsController)) as OptionsController;
        _transitionController = FindObjectOfType(typeof(TransitionController)) as TransitionController;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _optionsController.StartCoroutine(_optionsController.changeMusic(_optionsController.startClip));
            _transitionController.startFade(2);
        }
    }
}
