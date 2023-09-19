using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI energy;
    // Start is called before the first frame update
    void Start()
    {
        energy.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateEnergy(int playerEnergy)
    {
        energy.text = playerEnergy.ToString();
    }
}
