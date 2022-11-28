using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Script : MonoBehaviour
{
    [ContextMenuItem("Test Take Damage", nameof(TestDmg))]
    [ContextMenuItem("Test Heal", nameof(TestHeal))]
    [Header("Heath Point")]
    [SerializeField]
    int m_HP;

    [SerializeField]
    int m_MaxHP;

    [SerializeField]
    UnityEngine.UI.Image HPBar;

    void TestDmg()
    {
        TakeDmg(10);
    }

    void TestHeal()
    {
        Heal(10);
    }

    public void TakeDmg(int dmg)
    {
        m_HP -= dmg;
        HPBar.fillAmount = (float)m_HP / m_MaxHP;
        if (m_HP <= 0)
        {
            Debug.Log("I am Died");
        }
    }

    public void Heal(int dmg)
    {
        m_HP += dmg;
        if (m_HP >= m_MaxHP)
        {
            m_HP = m_MaxHP;
        }
        HPBar.fillAmount = (float)m_HP / m_MaxHP;
    }

    private void Awake()
    {
        m_HP = m_MaxHP;
    }
}
