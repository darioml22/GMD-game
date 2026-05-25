using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
        public GameObject settingsPanel;
    public Slider volumeSlider;

    public Animator cameraAnimator;
    public float animationDuration = 2.5f;

    private bool isTransitioning = false;

    void Start()
    {
        settingsPanel.SetActive(false);

        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;
    }

    public void PlayGame()
    {
        if (isTransitioning) return;        
        StartCoroutine(PlaySequence());
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }

    IEnumerator PlaySequence()
    {
        isTransitioning = true;

        cameraAnimator.SetTrigger("Play");

        yield return new WaitForSeconds(animationDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}