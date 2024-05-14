using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class coinsCollect : MonoBehaviour
{
    player player;
    TextMeshProUGUI meshPro;
    int coins = 0;
    void Start(){
        player = GameObject.Find("Player").GetComponent<player>();
        meshPro = GetComponent<TextMeshProUGUI>();
    }
    void Update (){
        coins = player.coinsAmmount;
        meshPro.text = "score: " + coins.ToString();
    }
}
