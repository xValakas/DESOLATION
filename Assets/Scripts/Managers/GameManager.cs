using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedcharacter;
    public GameObject Player;

    private Sprite playersprite;
    void Start()
    {
        playersprite = selectedcharacter.GetComponent<SpriteRenderer>().sprite;

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;

    }


}
