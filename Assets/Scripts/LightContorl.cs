using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightControl : MonoBehaviour
{
    public Light2D sceneLight; 

    void Start()
    {
        
    }

    void Update()
    {
        
        ChangeColor();
    }

    public void ChangeColor()
    {
        if (Cat.isDead)
        {
            
            if (sceneLight != null)
            {
                sceneLight.color = Color.red;
            }
        }
        else
        {
            
            if (sceneLight != null)
            {
                sceneLight.color = Color.white; // Normal ýþýk rengi
            }
        }
    }
}
