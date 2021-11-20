using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWave 
{
    #region Variable Declaration
    public const int samplerate = 44100;
    public const float length = 2;

    public float m_Frequency = 440;
    public int m_Position = 0;
    float m_WaveFactor;
	private float v;

	public AudioClip Clip { set; get; }
    #endregion

    public AudioWave(float a_Frequency)
    {
        m_Frequency = a_Frequency;
        m_WaveFactor = 2 * Mathf.PI * m_Frequency / samplerate;
        Clip = AudioClip.Create("", (int)(samplerate * length), 1, samplerate, true, OnAudioRead, OnAudioSetPosition);
    }

    void OnAudioRead(float[] data)
    {
        int count = 0;
        while (count < data.Length)
        {
            //data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
            data[count] = Mathf.Sin(m_WaveFactor * m_Position);
            m_Position++;
            count++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        m_Position = newPosition;
    }

    public void SetPlayer(AudioSource a_Src)
	{
        a_Src.loop = true;
	}
}
