using UnityEngine;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    private GameObject currentObject;
    public bool isPlayer;

    public GameObject player, cat;

    private PlayerManager playerScript;
    private Cat catScript;

    public CinemachineCamera cinemachineCamera;

    
    public static GameManager Instance;

    private int reachedEndCount = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isPlayer = true;
        UpdateCameraTarget(); // Oyunun başında doğru hedefe odaklanmasını sağla
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPlayer = !isPlayer;
            UpdateCameraTarget(); // Kamera hedefini güncelle
        }
    }

    private void UpdateCameraTarget()
    {
        if (isPlayer)
        {
           cinemachineCamera.Target.TrackingTarget=player.transform;
        }
        else
        {
            cinemachineCamera.Target.TrackingTarget=cat.transform;
        }
    }

    public void CharacterReachedEnd()
    {
        reachedEndCount++;

        if (reachedEndCount >= 2) // İki karakter de ulaştıysa
        {
            LevelManager.Instance.LoadScene("Platform_2"); // Yeni sahneye geç
        }
    }
}
