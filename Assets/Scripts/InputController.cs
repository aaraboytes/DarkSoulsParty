using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController {

	public enum PlayerNumber {
		One, Two, Three, Four, PC
	}

	public static string GetPrefix(PlayerNumber playerNumber) {
		switch (playerNumber) {
		case PlayerNumber.One:
			return "P1.";
			break;
		case PlayerNumber.Two:
			return "P2.";
			break;
		case PlayerNumber.Three:
			return "P3.";
			break;
		case PlayerNumber.Four:
			return "P4.";
			break;
		case PlayerNumber.PC:
			return "";
			break;
		default:
			return "";
			break;
		}
	}
}