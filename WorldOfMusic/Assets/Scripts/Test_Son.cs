using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Son : MonoBehaviour
{
    public static float[] samples = new float[512];//tableau de frequences
    public static float[] freqBand = new float[8];

    public AudioSource audio;// le fichier son joué

    public GameObject cube;

    [SerializeField] public int nSample;
    // Start is called before the first frame update
    void Start()
    {
     // audio = GetComponent<AudioSource>();
      cube = gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrumAudioSource()
    {
        audio.GetSpectrumData(samples,0,FFTWindow.Blackman); //Retourne le spectre de de la source audio 
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0f;
            int SampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                SampleCount += 2;
            }

            for (int j = 0; j < SampleCount; j++)
            {
                average += samples[count] * (count+1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;
        }
    }
}




/* prefab disco music 1
 bracket modif y
 body modif x
 */
