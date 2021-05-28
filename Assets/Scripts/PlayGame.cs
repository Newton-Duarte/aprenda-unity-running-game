using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(1);
        } else if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
