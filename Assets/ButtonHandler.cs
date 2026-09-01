using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [Header("Button References")]
    public Button quitButton;
    public Button creditsButton;
    // Button inside the credits submenu
    public Button exitCreditsButton;
    [SerializeField] private int score;

    [Header("Submenu Panels")]
    public GameObject creditsMenu;

    [SerializeField] private TMP_Text scoreText; 

    public void Awake()
    {
        if (creditsMenu)
        {
            creditsMenu.SetActive(false);
        }
    }
    public void OnEnable()
    {
        quitButton.onClick.AddListener(HandlePressQuit);
        creditsButton.onClick.AddListener(() => SetCreditsSubmenuActive(true));
        exitCreditsButton.onClick.AddListener(() => SetCreditsSubmenuActive(false));
    }

    public void OnDisable()
    {
        creditsButton.onClick.RemoveAllListeners();
        exitCreditsButton.onClick.RemoveAllListeners();
    }

    public void SetCreditsSubmenuActive(bool isActive)
    {
        if (creditsMenu)
        {
            creditsMenu.SetActive(isActive);
            if (isActive)
            {
                score++;
                scoreText.SetText(score.ToString());
            }
            Debug.Log($"Settings submenu visibility set to: {isActive}");
        }
    }

    public void HandlePressQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
