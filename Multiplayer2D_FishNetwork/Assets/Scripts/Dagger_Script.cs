using UnityEngine;

public class Dagger_Script : PlayerController
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!base.IsOwner)
            return;
        if (other.CompareTag(TagManager.Team1))
            return;
        if (other.CompareTag(TagManager.Team2))
        {
            ServerDamager(other.GetComponent<HP_Script>());
        }
    }
}
