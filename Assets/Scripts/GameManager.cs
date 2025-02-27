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
}
