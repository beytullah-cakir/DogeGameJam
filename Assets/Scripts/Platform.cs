using UnityEngine;

public class Platform : MonoBehaviour
{
    Animator anm;

    private void Start()
    {
        anm = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anm.SetTrigger("Fall");
        }
    }
}
