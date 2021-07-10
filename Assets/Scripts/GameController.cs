using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    TransitionController _transitionController;
    OptionsController _optionsController;
    private Player _player;

    [Header("Player Config.")]
    public float minBoundaryX;
    public float maxBoundaryX;
    public float minBoundaryY;
    public float maxBoundaryY;

    [Header("Object Config.")]
    public GameObject bridgePrefab;
    public float bridgeSize;
    public float objectSpeed;
    public float objectDestroyDistance;
    public Vector3 objectInstantiatePosition;

    [Header("Keg Config.")]
    public GameObject kegPrefab;
    public int orderInLayerTop;
    public int orderInLayerDown;
    public float posYTop;
    public float posYDown;
    public float spawnTime;

    [Header("Globals")]
    public float posXPlayer;
    public Text scoreTxt;
    private int scorePoints;

    [Header("FX Config.")]
    public AudioSource fxSource;
    public AudioClip fxPoints;

    // Start is called before the first frame update
    void Start()
    {
        _transitionController = FindObjectOfType(typeof(TransitionController)) as TransitionController;
        _optionsController = FindObjectOfType(typeof(OptionsController)) as OptionsController;
        _player = FindObjectOfType(typeof(Player)) as Player;
        StartCoroutine(kegSpawn());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        posXPlayer = _player.transform.position.x;
    }

    IEnumerator kegSpawn()
    {
        yield return new WaitForSeconds(spawnTime);

        int     rand = Random.Range(0, 100);
        float   posY;
        int     order;

        if (rand < 50)
        {
            posY = posYTop;
            order = orderInLayerTop;
        } else
        {
            posY = posYDown;
            order = orderInLayerDown;
        }

        GameObject temp = Instantiate(kegPrefab);
        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;

        StartCoroutine(kegSpawn());
    }

    public void score(int points)
    {
        scorePoints += points;
        scoreTxt.text = "Score: " + scorePoints.ToString();
        fxSource.PlayOneShot(fxPoints);
    }

    public void gameOver()
    {
        _optionsController.StartCoroutine(_optionsController.changeMusic(_optionsController.gameoverClip));
        _transitionController.startFade(4);
    }
}
