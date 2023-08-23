using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rigb;
    public int coinsCollected = 0;
    public bool gameWon = false;

    void Start()
    {
        rigb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigb.AddForce(movement * speed);

        if (gameWon == true && Input.GetKeyDown(KeyCode.Space))
        {
            QuitGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Debug.Log("Coin collected!");
            coinsCollected++;
            Destroy(collision.gameObject);

            if (coinsCollected >= 12)
            {
                Debug.Log("You collected all the coins! Press SPACE to exit the game.");
                gameWon = true;
            }
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
