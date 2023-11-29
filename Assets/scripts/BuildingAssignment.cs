using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingAssignment : MonoBehaviour
{
    private string[,] riddles;
    private string[] buildingList;

    // Start is called before the first frame update
    void Start()
    {
        riddles = new string[9, 2];
        buildingList = new string[9];

        riddles[0, 0] = "Where the honky-tonk tunes and the sasparilla flow, where troubles are forgotten and laughter's aglow. What am I?";
        riddles[0, 1] = "With swinging doors and a rowdy crowd, where the piano plays and voices are loud. What am I?";
        riddles[1, 0] = "From plows to lassos, and hats for your head, where the shelves are stocked, and dreams are fed. What am I?";
        riddles[1, 1] = "With jars of pickles and sacks of grain, where you can find all you need, from rope to chain. What am I?";
        riddles[2, 0] = "With thick walls and guards at the door, where riches are kept safe, and nothing is more. What am I?";
        riddles[2, 1] = "A vault of security, where dollars are stored, a place that's impregnable, and carefully floored. What am I?";
        riddles[3, 0] = "With anvils that ring and sparks that fly, where metal bends to the will, and horses nearby. What am I?";
        riddles[3, 1] = "A forge of creation, where metal meets fire, where tools are born and shaped with desire. What am I?";
        riddles[4, 0] = "With striped poles and combs in sight, where folks come in shaggy and leave feeling light. What am I?";
        riddles[4, 1] = "Where the scissors snip and the razors sing, a place for a trim and a gentleman's fling. What am I?";
        riddles[5, 0] = "With pews in rows and a cross on high, where hymns fill the air and sinners come by. What am I?";
        riddles[5, 1] = "Where the preacher preaches and the choir sings, a place for the faithful, where hope brings wings. What am I?";
        riddles[6, 0] = "With stamps and parcels, and letters in line, a place for correspondences, both near and divine. What am I?";
        riddles[6, 1] = "Where mailboxes wait and clerks assist, a hub of communication that cannot be missed. What am I?";
        riddles[7, 0] = "With cleavers that chop and knives that slice, where meat is abundant and prices are nice. What am I?";
        riddles[7, 1] = "A place of cuts and sausages too, where the aroma of fresh meat lingers for you. What am I?";
        riddles[8, 0] = "With cells of steel and bars that bind, a place where justice is defined. What am I?";
        riddles[8, 1] = "Badges gleam, hats worn with pride, in this realm where law will abide. What am I";

        buildingList[0] = "Saloon";
        buildingList[1] = "GeneralStore";
        buildingList[2] = "Bank";
        buildingList[3] = "Blacksmith";
        buildingList[4] = "BarberShop";
        buildingList[5] = "Church";
        buildingList[6] = "PostOffice";
        buildingList[7] = "Butcher";
        buildingList[8] = "SheriffOffice";

        int buildingAIndex = Random.Range(0, 8);
        int riddleA = Random.Range(0, 1);
        int buildingBIndex = Random.Range(0, 8);
        while (buildingBIndex == buildingAIndex)
        {
            buildingBIndex = Random.Range(0, 8);
        }
        int riddleB = Random.Range(0, 1);

        GameObject dartBuilding = GameObject.FindGameObjectWithTag(buildingList[buildingAIndex]);
        GameObject hammerBuilding = GameObject.FindGameObjectWithTag(buildingList[buildingBIndex]);

        dartBuilding.GetComponent<BuildingTransition>().LoadMinigame("DartScene");
        hammerBuilding.GetComponent<BuildingTransition>().LoadMinigame("HammerScene");

        print(riddles[buildingAIndex, riddleA]);
        print(riddles[buildingBIndex, riddleB]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
