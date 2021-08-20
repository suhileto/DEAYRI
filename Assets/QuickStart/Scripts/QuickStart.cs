using System.IO;
using UnityEngine;
using System;
using Google.Cloud.TextToSpeech.V1;
public class QuickStart : MonoBehaviour
{
    public string credentialsPath;
    public string saveFile;

    void Start()
    {
        #region Environment Variable
        if (!File.Exists(credentialsPath))
        {
            Debug.LogError("failure" + credentialsPath);
            return;
        }
        else
        {
            Debug.Log("success: " + credentialsPath);
        }
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsPath);
        #endregion
        

        /*SpeechClient client = SpeechClient.Create();
        RecognitionConfig config = new RecognitionConfig
        {
            Encoding = AudioEncoding.Linear16,
            SampleRateHertz = 16000,
            LanguageCode = LanguageCodes.English.UnitedStates
        };
        RecognizeResponse response = client.Recognize(config, saveFile);
        Debug.Log(response);*/
        
        
        /*// Set the text input to be synthesized.
        SynthesisInput input = new SynthesisInput
        {
            Text = "Hello, World!"
        };

        // Build the voice request, select the language code ("en-US"),
        // and the SSML voice gender ("neutral").
        VoiceSelectionParams voice = new VoiceSelectionParams
        {
            LanguageCode = "tr-TR",
            SsmlGender = SsmlVoiceGender.Neutral
        };

        // Select the type of audio file you want returned.
        AudioConfig config = new AudioConfig
        {
            AudioEncoding = AudioEncoding.Mp3
        };

        // Perform the Text-to-Speech request, passing the text input
        // with the selected voice parameters and audio file type
        var response = client.SynthesizeSpeech(new SynthesizeSpeechRequest
        {
            Input = input,
            Voice = voice,
            AudioConfig = config
        });

        // Write the binary AudioContent of the response to an MP3 file.
        using (Stream output = File.Create(saveFile))
        {
            response.AudioContent.WriteTo(output);
            Debug.Log($"Audio content written to file " + saveFile);
        }
        #endregion*/

    }

}
