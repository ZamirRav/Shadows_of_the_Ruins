using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoonChanger : MonoBehaviour
{
    public SpriteRenderer sr1, sr2;
    public Light2D light2d;
    public AudioSource audioSource;
    void Start()
    {
        if (GameSettings.IsDevilModOn)
        {
            audioSource.clip = Resources.Load<AudioClip>("Audio/Devil");
            audioSource.Play();
            sr1.color = new Color(1, 0, 0, 1);
            sr2.color = new Color(1, 0, 0, 1);
            light2d.color = new Color(1, 0, 0, 1);
            light2d.intensity = 10;
        }
        ;
    }

    void Update()
    {

    }
}
