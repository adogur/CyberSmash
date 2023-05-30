using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] RectTransform mainMenu;
    [SerializeField] RectTransform optionsMenu;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider effectsVolumeSlider;
    [SerializeField] private MixerContoller mixerController;


    private static void Show(Component component)
    {
        component.gameObject.SetActive(true);
    }

    private static void Hide(Component component)
    {
        component.gameObject.SetActive(false);
    }

    private void Start()
    {
        ShowMainMenu();
        UpdateSliders();
    }
    public void StartGame()
    {
        Scenes.LoadNextScene();
    }

    public void ExitGame()
    {
        Scenes.ExitGame();
    }

    public void ShowMainMenu()
    {
        Show(mainMenu);
        Hide(optionsMenu);
    }

    public void ShowOptionsMenu()
    {
        Hide(mainMenu);
        Show(optionsMenu);
    }

    private void UpdateSliders()
    {
        musicVolumeSlider.SetValueWithoutNotify(mixerController.MusicVolume);
        effectsVolumeSlider.SetValueWithoutNotify(mixerController.EffectsVolume);
    }
}
