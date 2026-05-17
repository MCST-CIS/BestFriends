using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("key picked up");
            foreach (BoxCollider2D boxCol in door.GetComponents<BoxCollider2D>())
            {
                if (!boxCol.isTrigger)
                {
                    boxCol.enabled = false;
                }
            }
            this.gameObject.SetActive(false);
        }
    }
}