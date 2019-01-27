using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        WaitingToStart,
        Exploring,
        Returning
    }
    public static GameManager instance = null;

    [SerializeField] private TileManager m_tileManager;
    [SerializeField] private ItemsController m_itemController;
    [SerializeField] private GameObject m_character;
    [SerializeField] private BoxCollider2D returnPoint;
    [SerializeField] private Transform m_startPoint;
    [SerializeField] private GameObject m_returningLayover;
    [SerializeField] private GameObject m_returnSuccessObject;
    [SerializeField] private GameObject m_returnFailureObject;

    private float m_exploreTimer = 30f;

    private float m_returnTimer = 20f;

    private GameState m_gameState = GameState.WaitingToStart;

    public TileManager TileManager
    {
        get
        {
            return m_tileManager;
        }

        private set
        {
            m_tileManager = value;
        }
    }

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!TileManager.Initialized)
        {
            TileManager.Initialize();
        }
        if (m_gameState == GameState.WaitingToStart)
        {
            if (Input.anyKey)
            {
                StartExploring();
            }
        }
        if (m_gameState == GameState.Exploring)
        {
            m_exploreTimer -= Time.deltaTime;
            if (m_exploreTimer <= 0)
            {
                StartReturning();
            }
        }
        else if (m_gameState == GameState.Returning)
        {
            m_returnTimer -= Time.deltaTime;
        }
    }

    public void ResetGame()
    {
        m_exploreTimer = 5f;
        m_returnTimer = 5f;
        m_character.transform.position = m_startPoint.position;
        m_gameState = GameState.WaitingToStart;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_gameState == GameState.Returning &&
            collision.gameObject.GetComponent<CharacterController>() != null)
        {
            OnReturnSuccess();
        }
    }

    public void FinishReturnPhase()
    {
        m_returningLayover.SetActive(false);
        m_character.SetActive(false);
    }

    public void OnReturnSuccess()
    {
        m_returnSuccessObject.SetActive(true);
        FinishReturnPhase();
        ResetGame();
    }

    public void OnReturnFailure()
    {
        m_returnFailureObject.SetActive(true);
        FinishReturnPhase();
        ResetGame();
    }

    public void StartReturning()
    {
        m_returningLayover.SetActive(true);
        m_gameState = GameState.Returning;
        TileManager.ActivateMaze();
    }

    public void StartExploring()
    {
        m_returnFailureObject.SetActive(false);
        m_returnSuccessObject.SetActive(false);
        m_character.SetActive(true);
        m_gameState = GameState.Exploring;
    }
}
