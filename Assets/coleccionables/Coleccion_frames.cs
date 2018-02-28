using UnityEngine;
using UnityEngine.UI;

public class Coleccion_frames : MonoBehaviour
{
    public Sprite[] frames;
    SpriteRenderer uiImage;
    public float frameRate = 0.1f;

    private int currentImage = 0;

    private float timer = 0;

    private void Start()
    {
        uiImage = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > frameRate)
        {
            ChangeImage();
            timer = 0;
        }
    }

    private void ChangeImage()
    {
        currentImage += 1;
        if (currentImage == frames.Length)
            currentImage = 0;
        uiImage.sprite = frames[currentImage];
    }
}
