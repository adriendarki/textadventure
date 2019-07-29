using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

	public Room currentRoom;


	Dictionary<string, Room> exitDictionary = new Dictionary<string, Room> ();
	GameController controller;

	void Awake()
	{
		controller = GetComponent<GameController> ();
	}

	public void UnpackExitsInRoom()
	{
		for (int i = 0; i < currentRoom.exits.Length; i++) 
		{
			exitDictionary.Add (currentRoom.exits [i].keyString, currentRoom.exits [i].valueRoom);
			controller.interactionDescriptionsInRoom.Add (currentRoom.exits [i].exitDescription);
		}
	}

	public void AttemptToChangeRooms(string directionNoun)
	{
		if (exitDictionary.ContainsKey (directionNoun)) {
			currentRoom = exitDictionary [directionNoun];
			controller.LogStringWithReturn ("Vous partez vers le  " + directionNoun);
			controller.DisplayRoomText ();
		} else 
		{
			controller.LogStringWithReturn ("Il n'y a pas de chemin vers le " + directionNoun);
		}

	}

	public void ClearExits()
	{
		exitDictionary.Clear ();
	}
}
