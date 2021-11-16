using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sweet : MonoBehaviour
{
    [SerializeField] Text sweetsText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().sweets += 1;
            sweetsText.text = "Sweets: " + other.gameObject.GetComponent<PlayerMovement>().sweets.ToString(); 
            this.gameObject.SetActive(false);
        }
    }
}
