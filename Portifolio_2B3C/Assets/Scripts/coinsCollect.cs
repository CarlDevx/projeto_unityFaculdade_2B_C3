using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class coinsCollect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(this);
        }
    }
}
