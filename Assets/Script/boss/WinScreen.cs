using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    GameManager gameManager;
    Player player;
    PlayerMove playerMove;
    [SerializeField]
    Text[] scoreText;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        playerMove = FindObjectOfType<PlayerMove>();
    }

    void OnEnable()
    {
        scoreText[0].text = gameManager.timer.ToString();
        scoreText[1].text = player.playerHpBar.ToString();
        scoreText[2].text = playerMove.parryCount.ToString();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 12f) * Time.deltaTime);
    }
}
