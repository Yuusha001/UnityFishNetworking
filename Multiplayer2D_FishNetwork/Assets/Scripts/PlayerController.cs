using FishNet.Object;
using FishNet.Connection;
using FishNet.Component.Animating;

public class PlayerController : NetworkBehaviour
{
    protected NetworkAnimator networkAnimator;

    // Start is called before the first frame update
    void Start()
    {
        networkAnimator = GetComponentInChildren<NetworkAnimator>();
    }

    public override void OnOwnershipClient(NetworkConnection prevOwner)
    {
        base.OnOwnershipClient(prevOwner);
    }

    [ServerRpc]
    protected void ServerDamager(HP_Script oppHP)
    {
        oppHP.UpdateHP(oppHP.HP - 10);
    }

    protected void ServerHeal(HP_Script oppHP)
    {
        oppHP.UpdateHP(oppHP.HP + 10);
    }
}
