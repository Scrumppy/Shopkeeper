using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        pauseMenuPanel?.SetActive(false);
        optionsPanel?.SetActive(false);

        //musicSlider.value = 0.5f;
        //ChangeMusicVolume();
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToggleOptions(bool value)
    {
        pauseMenuPanel?.SetActive(!value);
        optionsPanel?.SetActive(value);

        if (AudioManager.Instance)
        {
            musicSlider.value = AudioManager.Instance.GetMusicVolume();
            sfxSlider.value = AudioManager.Instance.GetSFXVolume();
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeMusicVolume()
    {
        AudioManager.Instance?.MusicVolume(musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        AudioManager.Instance?.SoundVolume(sfxSlider.value);
    }
}
