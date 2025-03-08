using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject currentObject;
    public bool isPlayer;

    public GameObject player, cat;

    private PlayerManager playerScript;
    private Cat catScript;

    public string nextLevel;

    public CinemachineCamera cinemachineCamera;

    public static GameManager Instance;

    private int reachedEndCount = 0;
    private bool playerReachedEnd = false;
    private bool catReachedEnd = false;

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
        if (Input.GetKeyDown(KeyCode.E) && !Cat.isDead)
        {
            isPlayer = !isPlayer;
            UpdateCameraTarget(); // Kamera hedefini güncelle
        }
        CatIsDead();
    }

    private void UpdateCameraTarget()
    {
        if (isPlayer)
        {
            cinemachineCamera.Target.TrackingTarget = player.transform;
        }
        else
        {
            cinemachineCamera.Target.TrackingTarget = cat.transform;
        }
    }

    public void CharacterReachedEnd(GameObject character)
    {
        if (character == player && !playerReachedEnd)
        {
            playerReachedEnd = true;
            reachedEndCount++;
        }
        else if (character == cat && !catReachedEnd)
        {
            catReachedEnd = true;
            reachedEndCount++;
        }

        if (reachedEndCount >= 2) // İki karakter de ulaştıysa
        {
            LevelManager.Instance.LoadScene(nextLevel); // Yeni sahneye geç
            reachedEndCount = 0;
            playerReachedEnd = false;
            catReachedEnd = false;
        }
    }

    public void CatIsDead()
    {
        if (Cat.isDead)
        {
            cinemachineCamera.Target.TrackingTarget = player.transform;
            Animator player_anm = player.GetComponent<Animator>();
            SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
            player_anm.enabled = false;
            renderer.flipX = false;
            Invoke("LoadFinalScene", 5f);
        }
    }

    void LoadFinalScene()
    {
        LevelManager.Instance.LoadScene("FinalScene");
    }
}
