using UnityEditor.Search;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameoverUI;
    [SerializeField] GameObject winUI;
    
    enum eState
    {
        TITLE,
        GAME,
        WIN,
        LOSE
    }

    eState state = eState.TITLE;
    float time = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        switch (state)
        {
            case eState.TITLE:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    OnStartGame();
                }
                break;
            case eState.GAME:
                break;
            case eState.WIN:
                print("You sunk in the sink!");
                break;
            case eState.LOSE:
                break;
            default:
                break;
        }
    }

    public void OnStartGame()
    {
        titleUI.SetActive(false);
        state = eState.GAME;
    }

    public void SetGameOver()
    {
        state = eState.WIN;
    }
}
