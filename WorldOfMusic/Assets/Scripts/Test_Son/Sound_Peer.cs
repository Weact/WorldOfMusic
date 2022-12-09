using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound_Peer : MonoBehaviour
{
    public AudioSource audio;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];

    private float[] freqBandHighest = new float[8];
    public static float[] audioBand = new float[8];
    //public float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];
    //public float[] audioBandBuffer = new float[8];
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrum();
        MakeFrequencyBands();
        BandBuffer();
        createAudioBand();
    }

    void createAudioBand()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void GetSpectrum()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (freqBand[g] > bandBuffer[g])
            {
                bandBuffer[g] = freqBand[g];
                bufferDecrease[g] = 0.005f;
            }

            if (freqBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
            Debug.Log(bufferDecrease[g]);
        }   
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0f;                                         
            int SampleCount = (int)Mathf.Pow(2, i) * 2;        /*2 - 4 - 8 - 16 - 32 - 64 - 128 - 256 */         
            if (i == 7)
            {
                SampleCount += 2;                               /* 258 */
            }

            for (int j = 0; j < SampleCount; j++)
            {
                average += samples[count] * (count+1);          /*  */
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;
        }
    }
}
