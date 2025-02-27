using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource jump, changePlayer;

    public static AudioManager Instanse;


    void Awake()
    {
        Instanse = this;
    }

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayChangePlayer()
    {
        changePlayer.Play();
    }



    public void ButtonClick(AudioSource buttonClick)
    {
        DontDestroyOnLoad(buttonClick.gameObject); // Sesi koru
        buttonClick.Play();
    }


}
