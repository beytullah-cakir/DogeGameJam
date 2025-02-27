using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soil, stoneStep;

    public static AudioManager Instanse;


    void Awake()
    {
        Instanse = this;
    }


    public void PlaySoilStep()
    {
        soil.Play();
    }

    public void PlayStoneStep()
    {
        stoneStep.Play();
    }

    public void ButtonClick(AudioSource buttonClick)
    {
       DontDestroyOnLoad(buttonClick.gameObject); // Sesi koru
        buttonClick.Play();
    }


}
