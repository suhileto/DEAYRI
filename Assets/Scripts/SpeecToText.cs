using System.IO;
using UnityEngine;
using System;
using Google.Cloud.Speech.V1;


public class SpeecToText : MonoBehaviour
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
        

        RecognitionAudio audio1 = RecognitionAudio.FromFile("Sound/SpeechSample.flac");
        RecognitionAudio audio2 = RecognitionAudio.FetchFromUri("https://.../HostedSpeech.flac");
        RecognitionAudio audio3 = RecognitionAudio.FromStorageUri("gs://my-bucket/my-file");

        byte[] bytes = ReadAudioData(); // For example, from a database
        RecognitionAudio audio4 = RecognitionAudio.FromBytes(bytes);

        using (Stream stream = OpenAudioStream()) // Any regular .NET stream
        {
            RecognitionAudio audio5 = RecognitionAudio.FromStream(stream);
        }
        
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
