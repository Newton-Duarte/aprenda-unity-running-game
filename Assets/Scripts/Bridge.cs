using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private GameController _gameController;
    private Rigidbody2D bridgeRb;
    private bool isInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        bridgeRb = GetComponent<Rigidbody2D>();

        bridgeRb.velocity = new Vector2(_gameController.objectSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInstantiated)
        {
            if (transform.position.x <= 0)
            {
                isInstantiated = true;

                GameObject temp = Instantiate(_gameController.bridgePrefab);
                temp.transform.position = new Vector3(transform.position.x + _gameController.bridgeSize, transform.position.y, 0);
            }
        }

        if (transform.position.x < _gameController.objectDestroyDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
