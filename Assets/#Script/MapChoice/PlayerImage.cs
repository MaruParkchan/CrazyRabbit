using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImage : MonoBehaviour
{
    [SerializeField] Sprite[] characterImageList;
    private Image characterImage;
    private int player1 = 0;
    private int player2 = 0;
    private void Awake()
    {
        player1 = PlayerPrefs.GetInt("Player1");
        player2 = PlayerPrefs.GetInt("Player2");
        characterImage = GetComponent<Image>();
        PlayerCheck();
    }

    public void PlayerCheck()
    {
        if (player1 == 0)
            characterImage.sprite = characterImageList[0];
        else if (player1 == 1)
            characterImage.sprite = characterImageList[1];

        if (player2 == 0)
            characterImage.sprite = characterImageList[2];
        else if (player2 == 1)
            characterImage.sprite = characterImageList[3];
    }
}
