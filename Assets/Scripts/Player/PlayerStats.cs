using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ������ Unity (1 ������ �� �������) | ������: 0
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private Image hpBar;


    private float curHp;
    private float curHunger;

    // ��������� Unity | ������: 0
    void Start()
    {
        curHp = maxHp;
        hpBar.fillAmount = curHp / maxHp;
    }

    // ������: 0
    public void TakeDamage(float dmg)
    {
        curHp -= dmg;
        hpBar.fillAmount = curHp / maxHp;
        Debug.Log($"DAMAGE: {dmg} CURRENT HP: {curHp} MAX HP: {maxHp}");
        if (curHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
