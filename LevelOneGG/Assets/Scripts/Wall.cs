using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private List<Sprite> m_sprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        int activeSpriteIndex = Random.Range(0, m_sprites.Count);
        m_spriteRenderer.sprite = m_sprites[activeSpriteIndex];
    }
}