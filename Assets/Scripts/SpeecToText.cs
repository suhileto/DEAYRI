using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Google.Cloud.Speech.V1;
using NAudio.Wave;
using NAudio.CoreAudioApi;

public class SpeecToText : MonoBehaviour
{
    public string credentialsPath;
    public string saveFile;

    void Start()
    {
        /*#region Environment Variable
        if (!File.Exists(credentialsPath))
        {
            Debug.LogError("failure" + credentialsPath);
            return;
        }
        else
        {
            Debug.Log("success: " + credentialsPath);
        }
        #endregion*/

	int outRate = 16000;
	var inFile = @"dump.wav";
	var outFile = @"resampled.wav";
	using (var reader = new WaveFileReader(inFile))
	{
		var outFormat = new WaveFormat(outRate, 1);
		using (var resampler = new MediaFoundationResampler(reader, outFormat))
			{
			    WaveFileWriter.CreateWaveFile(outFile, resampler);
			}
	}
		
        System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "/home/kali/Documents/GitHub/DEAYRI/solid-mountain-323117-23c33e1c114c.json");
        var speech = SpeechClient.Create();
        var response = speech.Recognize(new RecognitionConfig()
        {
            Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
            SampleRateHertz = 48000,
            AudioChannelCount = 2,
            LanguageCode = "tr-TR",
        }, RecognitionAudio.FromFile("/home/kali/Documents/GitHub/DEAYRI/dump.wav"));

	
	
        string Text = "";

        foreach (var result in response.Results)
        {
            foreach (var alternative in result.Alternatives)
            {
                Text = Text + " " + alternative.Transcript;
            }
        }
        
        Debug.Log(Text);

    }
}
