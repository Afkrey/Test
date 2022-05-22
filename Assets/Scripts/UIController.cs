using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text TextHp;
    [SerializeField] private Text TextGold;

    public int HealthInterface = 20;
    public int GoldInterface = 100;

    void Update()
    {
        TextHp.text = Convert.ToString(HealthInterface);
        TextGold.text = Convert.ToString(GoldInterface);
    }
}
