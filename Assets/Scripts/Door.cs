using UnityEngine;

public class Door : MonoBehaviour
{
    private bool player1Inside = false;
    private bool player2Inside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement pm = collision.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                if (pm.isPlayerOne) player1Inside = true;
                else player2Inside = true;
            }

            if (player1Inside && player2Inside && !GameManager.Instance.isGameOver)
            {
                GameManager.Instance.WinRound();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement pm = collision.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                if (pm.isPlayerOne) player1Inside = false;
                else player2Inside = false;
            }
        }
    }

    public void ResetDoor()
    {
        player1Inside = false;
        player2Inside = false;
    }
}