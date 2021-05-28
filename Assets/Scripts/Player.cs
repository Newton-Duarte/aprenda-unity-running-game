using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController _gameController;

    public float speed = 2;
    private Rigidbody2D playerRb;

    public float minBoundaryX;
    public float maxBoundaryX;
    public float minBoundaryY;
    public float maxBoundaryY;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float posX = transform.position.x;
        float posY = transform.position.y;

        playerRb.velocity = new Vector2(horizontal * speed, vertical * speed);

        if (posX < minBoundaryX)
        {
            transform.position = new Vector2(minBoundaryX, posY);
        } else if (posX > maxBoundaryX)
        {
            transform.position = new Vector2(maxBoundaryX, posY);
        } else if (posY < minBoundaryY)
        {
            transform.position = new Vector2(posX, minBoundaryY);
        } else if (posY > maxBoundaryY)
        {
            transform.position = new Vector2(posX, maxBoundaryY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameController.gameOver();
    }
}
