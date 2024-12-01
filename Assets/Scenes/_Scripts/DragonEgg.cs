using UnityEngine;
using UnityEngine.Serialization;

public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f;
    public AudioSource audioSource;

    [FormerlySerializedAs("isDestroyed")] public bool isDestroyed = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (transform.position.y < -8f && !isDestroyed)
        {
            var ps = GetComponent<ParticleSystem>();
            var em = ps.emission;
            em.enabled = true;
            var rend = GetComponent<Renderer>();
            rend.enabled = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            isDestroyed = true;
            var apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }

        if (transform.position.y < bottomY) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}