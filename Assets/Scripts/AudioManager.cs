using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource snowStep, stoneStep;


    public void PlaySnowStep()
    {
        snowStep.Play();
    }

    public void PlayStoneStep()
    {
        stoneStep.Play();
    }

    
}
