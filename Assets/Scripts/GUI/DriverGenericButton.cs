using UnityEngine;
using System.Collections;

public class DriverGenericButton : MonoBehaviour 
{
	[SerializeField]
	private string sceneName;
	
	private void OnClick()
	{
		Application.LoadLevel(this.sceneName);
	}
}
