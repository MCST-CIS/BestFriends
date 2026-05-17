using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float bounce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            float multiplier = 1f;

            if (player != null && player.isPlayerOne && player.abilityActive)
            {
                multiplier = 2f;
            }

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce * multiplier, ForceMode2D.Impulse);
        }
    }
}