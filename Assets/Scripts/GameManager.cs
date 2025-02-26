using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject currentObject;
    public bool isPlayer;

    private PlayerManager playerScript;
    private Cat catScript;


    public static GameManager Instance;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        isPlayer = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPlayer = !isPlayer;
        }
    }



}
