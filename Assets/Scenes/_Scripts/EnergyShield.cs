using UnityEngine;
using UnityEngine.UI;

public class EnergyShield : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceBomb;
    public Text scoreGT;
    public FloatOS score;

    private void Start()
    {
        var scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = score.Value.ToString();
    }

    private void Update()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        var pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        var Collided = coll.gameObject;
        switch (Collided.tag)
        {
            case "Dragon Bomb":
            {
                Destroy(Collided);
                var apScript = Camera.main.GetComponent<DragonPicker>();
                apScript.DragonEggDestroyed();
                apScript.BombDestroyed();
                break;
            }
            case "Dragon Egg":
                Destroy(Collided);
                score.Value += 1;
                scoreGT.text = score.Value.ToString();
                audioSource.Play();
                break;
            case "Dragon Heal":
            {
                Destroy(Collided);
                var apScript =
                    Camera.main.GetComponent<DragonPicker>();
                apScript.HealDestroyed();
                audioSource.Play();
                break;
            }
        }
    }
}