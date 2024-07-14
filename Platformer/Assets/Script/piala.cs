using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class Piala : MonoBehaviour
{
    public Text tulisanCanvas; // Referensi ke objek Text pada canvas
    private bool telahDisentuh = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pemain") && !telahDisentuh)
        {
            tulisanCanvas.text = "Anda menyentuh piala!";
            telahDisentuh = true;
        }
    }
}

