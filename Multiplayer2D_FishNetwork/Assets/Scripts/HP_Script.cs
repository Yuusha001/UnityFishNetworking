using UnityEngine;

public class HP_Script : PlayerController
{
    [Header("Heath Point")]
    [SerializeField]
    int m_HP;

    [SerializeField]
    int m_MaxHP;

    [SerializeField]
    UnityEngine.UI.Image HPBar;

    private void Awake()
    {
        HP = MaxHP;
    }

    public int HP
    {
        get => m_HP;
        set => m_HP = value;
    }
    public int MaxHP
    {
        get => m_MaxHP;
        set => m_MaxHP = value;
    }

    public void UpdateHP(int Amount)
    {
        HP = Amount;
        HPBar.fillAmount = (float)HP / MaxHP;
        ObserverUpdateHP(HP);
        if (HP <= 0)
        {
            Debug.Log("I am Died");
        }
    }

    [FishNet.Object.ObserversRpc(BufferLast = true)]
    public void ObserverUpdateHP(int Amount)
    {
        HP = Amount;
        HPBar.fillAmount = (float)HP / MaxHP;
        if (HP <= 0)
        {
            Debug.Log("I am Died");
        }
    }
}
