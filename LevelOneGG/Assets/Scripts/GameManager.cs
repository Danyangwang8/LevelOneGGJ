using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    [SerializeField] private TileManager m_tileManager;
    [SerializeField] private ItemsController m_itemController;

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
        
    }
}
