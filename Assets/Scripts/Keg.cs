using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keg : MonoBehaviour
{
    private GameController _gameController;
    private Rigidbody2D kegRb;

    private bool isScored;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        kegRb = GetComponent<Rigidbody2D>();

        kegRb.velocity = new Vector2(_gameController.objectSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _gameController.objectDestroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (!isScored && transform.position.x <= _gameController.posXPlayer)
        {
            isScored = true;
            _gameController.score(1);
        }
    }
}
