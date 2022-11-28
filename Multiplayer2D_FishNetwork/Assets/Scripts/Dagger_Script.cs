using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger_Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.Team1))
            return;
        if (other.CompareTag(TagManager.Team2))
        {
            other.GetComponent<HP_Script>().TakeDmg(10);
        }
    }
}
