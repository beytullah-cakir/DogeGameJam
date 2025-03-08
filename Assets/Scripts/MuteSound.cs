using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public AudioSource bg;


    public void Update()
    {
        MuteBGSound();
    }


    public void MuteBGSound()
    {
        if (Cat.isDead)
        {
            bg.volume = 0;
        }
    }
}
