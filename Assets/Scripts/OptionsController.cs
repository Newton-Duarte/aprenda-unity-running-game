using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [Header("Audio Config.")]
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] internal AudioSource musicSource;
    [SerializeField] Text musicVolumeText;
    [SerializeField] GameObject optionsPanelOverlay;
    [SerializeField] internal AudioClip titleClip;
    [SerializeField] internal AudioClip startClip;
    [SerializeField] internal AudioClip gameplayClip;
    [SerializeField] internal AudioClip gameoverClip;

    // Start is called before the first frame update
    void Start()
    {
        initializePlayerPrefs();
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseGame();
        }
    }

    void initializePlayerPrefs()
    {
        if (PlayerPrefs.GetInt("FirstPlaythrough") == 0)
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            PlayerPrefs.SetInt("FirstPlaythrough", 1);
        }
        float musicVolume = PlayerPrefs.GetFloat("musicVolume");

        musicSource.volume = musicVolume;
        musicVolumeSlider.value = musicVolume;

        musicSource.clip = titleClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    void pauseGame()
    {
        optionsPanelOverlay.SetActive(!optionsPanelOverlay.activeInHierarchy);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void setMusicVolume()
    {
        musicSource.volume = musicVolumeSlider.value;
        musicVolumeText.text = Mathf.Round(musicVolumeSlider.value * 100).ToString();
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }

    public IEnumerator changeMusic(AudioClip clip)
    {
        float currentVolume = musicSource.volume;

        for (float v = currentVolume; v > 0; v -= 0.01f)
        {
            musicSource.volume = v;
            yield return new WaitForEndOfFrame();
        }
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();

        for (float v = 0; v < currentVolume; v += 0.01f)
        {
            musicSource.volume = v;
            yield return new WaitForEndOfFrame();
        }
    }
}
