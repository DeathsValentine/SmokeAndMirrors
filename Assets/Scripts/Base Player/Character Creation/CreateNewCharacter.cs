using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewCharacter : MonoBehaviour
{
    private BasePlayer newPlayer;
    private bool isScarlett;
    private bool isMerlyn;
    // Start is called before the first frame update
    void Start()
    {
        newPlayer= new BasePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        isScarlett=GUILayout.Toggle(isScarlett,"Scarlett");
        isMerlyn=GUILayout.Toggle(isMerlyn,"Merlyn");
        if(GUILayout.Button("Create"))
        {
            if(isScarlett)
            {
                newPlayer.PlayerClass=new ScarlettClass();
            }else if(isMerlyn)
            {
                newPlayer.PlayerClass=new MerlynClass();
            }
            newPlayer.PlayerLevel=1;
            newPlayer.Endurance=newPlayer.PlayerClass.Endurance;
            newPlayer.Strength=newPlayer.PlayerClass.Strength;
            newPlayer.Intelligence=newPlayer.PlayerClass.Intelligence;
            newPlayer.Dexterity=newPlayer.PlayerClass.Dexterity;
        }
    }
}
