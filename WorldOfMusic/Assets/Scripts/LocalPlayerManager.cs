using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoxUnity;

public class LocalPlayerManager : MonoBehaviour
{
    [SerializeField]
    private VivoxVoiceManager voiceManager;
    [SerializeField]
    private ServerManager serverManager;

    private bool bChannel = true;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (serverManager.bServeur)
            return;
        
        if (voiceManager.LoginState==LoginState.LoggedOut)
            ConnectVoice();
        
        if (voiceManager.LoginState==LoginState.LoggedIn && bChannel)
            ConnectChannel();
        
    }

    void ConnectVoice()
    {
        voiceManager.Login("Test");
    }

    void ConnectChannel()
    {
        bChannel = false;
        voiceManager.JoinChannel("Test", ChannelType.NonPositional, VivoxVoiceManager.ChatCapability.AudioOnly);
        //voiceManager.OnSpeechDetectedEvent += OnSpeechDetected;
    }
    
    void OnSpeechDetected(string participantUri, ChannelId id, bool isSpeaking)
    {
        Debug.Log("OnSpeechDetected: " + participantUri + " isSpeaking: " + isSpeaking);
    }
}
