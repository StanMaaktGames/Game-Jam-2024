using UnityEngine;
using UnityEngine.UI;

public class AnimateImage : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the audio source
    public Image image; // Reference to the UI Image
    public float sensitivity = 100.0f; // Sensitivity for movement
    public float scaleFactor = 0.5f; // Factor by which the movement will be scaled

    private float[] samples = new float[256]; // Array to hold audio samples
    private RectTransform rectTransform; // Reference to the RectTransform of the image

    void Start()
    {
        rectTransform = image.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            audioSource.GetOutputData(samples, 0);
            float sum = 0f;

            // Sum the absolute values of the samples
            for (int i = 0; i < samples.Length; i++)
            {
                sum += Mathf.Abs(samples[i]);
            }

            // Calculate the average amplitude
            float average = sum / samples.Length;

            // Move the image up and down based on the amplitude
            float movement = average * sensitivity * scaleFactor;
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, movement -266, rectTransform.localPosition.z);
        }
    }
}

