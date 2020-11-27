// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomNameInputField.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Let the room input his name to be saved as the network room Name, viewed by alls rooms above each  when in the same room. 
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

/*
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.PunBasics
{
	/// <summary>
	/// Room name input field. Let the user input his name, will appear above the room in the game.
	/// </summary>
	[RequireComponent(typeof(InputField))]
	public class RoomNameInputField : MonoBehaviour
	{
		#region Private Constants

		// Store the RoomPref Key to avoid typos
		const string roomNamePrefKey = "RoomName";

		#endregion

		#region MonoBehaviour CallBacks
		
		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
		void Start () {
		
			string defaultName = string.Empty;
			InputField _inputField = this.GetComponent<InputField>();

			if (_inputField!=null)
			{
				if (RoomPrefs.HasKey(roomNamePrefKey))
				{
					defaultName = RoomPrefs.GetString(roomNamePrefKey);
					_inputField.text = defaultName;
				}
			}

			PhotonNetwork.NickName =	defaultName;
		}

		#endregion
		
		#region Public Methods

		/// <summary>
		/// Sets the name of the room, and save it in the RoomPrefs for future sessions.
		/// </summary>
		/// <param name="value">The name of the Room</param>
		public void SetRoomName(string value)
		{
			// #Important
		    if (string.IsNullOrEmpty(value))
		    {
                Debug.LogError("Room Name is null or empty");
		        return;
		    }
			PhotonNetwork.NickName = value;

			RoomPrefs.SetString(roomNamePrefKey, value);
		}
		
		#endregion
	}
}
*/