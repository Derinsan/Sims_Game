using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwitching : MonoBehaviour
{
    [SerializeField] private GameObject[] _player;
    private PlayerController playerController1;
    private PlayerController playerController2;

    private void Start()
    {
        GameObject player1 = _player[0];
        playerController1 = player1.GetComponent<PlayerController>();
        
        GameObject player2 = _player[1];
        playerController2 = player2.GetComponent<PlayerController>();
        
        playerController1.enabled = true;
        playerController2.enabled = false;
    }

    public void FirstCharacter()
    {
        playerController1.enabled = true;
        playerController2.enabled = false;
    }

    public void SecondCharacter()
    {
        playerController1.enabled = false;
        playerController2.enabled = true;
    }
}
