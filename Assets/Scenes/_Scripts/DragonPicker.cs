using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragonPicker : MonoBehaviour
{
    public AudioSource audioBomb;
    public GameObject energyShieldPrefab;
    public Image healBar;
    public int numEnergyShield = 3;
    public float energyShieldButtomY = -6f;
    public float energyShieldRadius = 1.5f;
    public int maxHeal = 4;
    public int currentHeal;
    public List<GameObject> basketList;

    private void Start()
    {
        basketList = new List<GameObject>();
        for (var i = 1; i <= numEnergyShield; i++)
        {
            var tBasketGo = Instantiate(energyShieldPrefab);
            tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
            tBasketGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            basketList.Add(tBasketGo);
        }

        currentHeal = basketList.Count;
    }

    private void Update()
    {
        currentHeal = basketList.Count;
        healBar.fillAmount = currentHeal / (float)maxHeal;
    }

    public void BombDestroyed()
    {
        audioBomb.Play();
    }

    public void DragonEggDestroyed()
    {
        var basketIndex = basketList.Count - 1;
        var tBasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);


        if (basketList.Count == 0) SceneManager.LoadScene("_0Scene");
    }

    public void HealDestroyed()
    {
        var basketCount = basketList.Count + 1;
        if (basketCount != 5)
        {
            var newBasketGo = Instantiate(energyShieldPrefab);
            newBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
            newBasketGo.transform.localScale = new Vector3(1 * basketCount, 1 * basketCount, 1 * basketCount);
            basketList.Add(newBasketGo);
        }
    }
}