using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LetterToLetter : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] string phrase;
    [SerializeField] float typeDelay;

    private void Start()
    {
        StartCoroutine(typeLetter());
    }

    IEnumerator typeLetter()
    {
        text.text = "";

        for (int letter = 0; letter < phrase.Length; letter++)
        {
            text.text += phrase[letter];
            yield return new WaitForSeconds(typeDelay);
        }
    }
}
