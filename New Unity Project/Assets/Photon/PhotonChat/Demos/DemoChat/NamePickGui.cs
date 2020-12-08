using UnityEngine;
using UnityEngine.UI;

using Photon.Chat;
using Photon.Realtime;
using AuthenticationValues = Photon.Chat.AuthenticationValues;
#if PHOTON_UNITY_NETWORKING
using Photon.Pun;
#endif

[RequireComponent(typeof (ChatGui))]
public class NamePickGui : MonoBehaviour
{
    private const string UserNamePlayerPref = "NamePickUserName";

    public ChatGui chatNewComponent;

    public InputField idInput;

    public void Start()
    {
        this.StartChat();
        this.chatNewComponent = FindObjectOfType<ChatGui>();


        string prefsName = PlayerPrefs.GetString(NamePickGui.UserNamePlayerPref);
        if (!string.IsNullOrEmpty(prefsName))
        {
            this.idInput.text = prefsName;
        }
    }


    // new UI will fire "EndEdit" event also when loosing focus. So check "enter" key and only then StartChat.
    //public void EndEditOnEnter()
    //{
    //    this.StartChat();
        //if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        //{
        //    this.StartChat();
        //}
    //}

    public void StartChat()
    {
        ChatGui chatNewComponent = FindObjectOfType<ChatGui>();
        //chatNewComponent.UserName = this.idInput.text.Trim();
        chatNewComponent.UserName = PhotonNetwork.LocalPlayer.NickName;
		chatNewComponent.Connect();
        enabled = false;

        PlayerPrefs.SetString(NamePickGui.UserNamePlayerPref, chatNewComponent.UserName);
    }
}