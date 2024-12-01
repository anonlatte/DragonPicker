using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public Text scoreGT;
    public FloatOS score;

    private void Start()
    {
        var scoreGO =
            GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = score.Value.ToString();
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision coll)
    {
        var Collided = coll.gameObject;
        var apScript = Camera.main.GetComponent<DragonPicker>();
        switch (Collided.tag)
        {
            case "Dragon Bomb":
                Destroy(Collided);
                apScript.BombDestroyed();
                break;
            case "Dragon Egg":
                Destroy(Collided);
                apScript.DragonEggDestroyed();
                apScript.BombDestroyed();
                break;
            case "Dragon Heal":
                Destroy(Collided);
                apScript.DragonEggDestroyed();
                apScript.BombDestroyed();
                break;
        }
    }
}