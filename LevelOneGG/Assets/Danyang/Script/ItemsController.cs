using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    public GameObject[] items;

    public float itemNumber;
    private Vector2 itemPos;
    public bool isPickUp = false;



    private void Start()
    {
        foreach(GameObject item in items)
        {
            item.GetComponent<Rigidbody2D>();
            item.GetComponent<BoxCollider2D>();
            item.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    void ShowUpItems()
    {
        for (int i = 0; i < itemNumber; i++)
        {
            itemPos.x = Random.Range(0, 200);
            itemPos.y = Random.Range(0, 200);

            items[i].transform.position = new Vector3(itemPos.x, itemPos.y, 0.0f);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPickUp = true;

        foreach(GameObject item in items)
        {
            Destroy(item);
        }
    }
}
