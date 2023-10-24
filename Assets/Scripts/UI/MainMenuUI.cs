using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject confirmQuitPanel;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        optionsPanel?.SetActive(false);
        confirmQuitPanel?.SetActive(false);
    }

    private void Start()
    {
        AudioManager.Instance?.PlayMusic("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ToggleOptions(bool value)
    {
        mainMenuPanel?.SetActive(!value);
        optionsPanel?.SetActive(value);

        if (AudioManager.Instance)
        {
            musicSlider.value = AudioManager.Instance.GetMusicVolume();
            sfxSlider.value = AudioManager.Instance.GetSFXVolume();
        }
    }

    public void QuitGame()
    {
        mainMenuPanel?.SetActive(false);
        confirmQuitPanel?.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void DeclineQuit()
    {
        mainMenuPanel?.SetActive(true);
       confirmQuitPanel?.SetActive(false);
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
