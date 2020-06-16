using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    // public ITilemap mainTile;
    public Tilemap mainTileMap;
    public Tilemap meepleTileMap;

    public Grid grid; //  You can also use the Tilemap object

    public Tile mainTile;

    public GameObject gridLayout;

    public GameObject endText;
    public GameObject questionMenu;
    public GameObject sideMenu;

    public GameObject mainMenu;
    public GameObject escMenu;
    public Camera camera;

    private bool isEscMenuOpened = false;

    private bool voted = false;

    private int startX = 50;
    private int startY = 50;

    private List<List<string>> tiles  = new List<List<string>>(); // tile = {NW, N, NE, W, C, E, SW, S, SE} C = Center
    private List<List<int>> map = new List<List<int>>();         // map = {tile, x, y}
    private List<List<string>> mapPos = new List<List<string>>();         // map = {NW, N, NE, W, C, E, SW, S, SE}

    private List<Vector3Int> mapAvaible = new List<Vector3Int>();         // map = {tile, Angle, x, y}

    private List<List<Vector3Int>> coordsMeeples = new List<List<Vector3Int>>();

    private List<Vector3Int> coordsScore = new List<Vector3Int>();

    private List<int> randomCards = new List<int>();

    private int curCardIndex;
    private int tileCount;
    private int tileAvaibleCount;

    private void CreateMap()
    {
        // mainTileMap.ClearAllTiles();
        mainTile = Resources.Load<Tile>("BackSide");

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                mainTileMap.SetTile(new Vector3Int(i, j, 0), mainTile);
            }
        }
    }

    private void InitTiles()
    {
        // g = grass
        // w = water
        // r = road
        // m = monastery
        // t = town
        // ts = town + shield


        tiles .Add(new List<string>{ "g", "g", "g", "g", "m", "g", "g", "g", "g"}); // 0
        tiles .Add(new List<string>{ "g", "t", "g", "g", "g", "g", "g", "g", "g"}); // 1
        tiles .Add(new List<string>{ "t", "g", "t", "t", "t", "t", "t", "g", "t"}); // 2
        tiles .Add(new List<string>{ "g", "t", "t", "g", "g", "t", "g", "g", "t"}); // 3
        tiles .Add(new List<string>{ "g", "t", "g", "g", "g", "g", "g", "t", "g"}); // 4
        tiles .Add(new List<string>{ "g", "t", "g", "g", "g", "t", "g", "g", "t"}); // 5
        tiles .Add(new List<string>{ "t", "g", "t", "t", "ts", "t", "t", "g", "t"}); // 6
        tiles .Add(new List<string>{ "g", "t", "ts", "g", "g", "t", "g", "g", "t"}); // 7
        tiles .Add(new List<string>{ "t", "t", "t", "t", "t", "t", "t", "g", "t"}); // 8
        tiles .Add(new List<string>{ "t", "t", "t", "t", "ts", "t", "t", "g", "t"}); // 9
        tiles .Add(new List<string>{ "t", "t", "t", "t", "ts", "t", "t", "t", "t"}); // 10
        tiles .Add(new List<string>{ "g", "g", "g", "g", "w", "g", "g", "w", "g"}); // 11
        tiles .Add(new List<string>{ "g", "g", "g", "w", "w", "w", "g", "g", "g"}); // 12
        tiles .Add(new List<string>{ "g", "g", "g", "w", "w", "g", "g", "w", "g"}); // 13
        tiles .Add(new List<string>{ "g", "t", "g", "w", "w", "w", "g", "t", "g"}); // 14
        tiles .Add(new List<string>{ "g", "t", "t", "w", "w", "t", "g", "w", "t"}); // 15
        tiles .Add(new List<string>{ "g", "g", "g", "g", "m", "g", "g", "r", "g"}); // 16
        tiles .Add(new List<string>{ "g", "g", "g", "r", "r", "r", "g", "g", "g"}); // 71
        tiles .Add(new List<string>{ "g", "g", "g", "r", "r", "g", "g", "r", "g"}); //18
        tiles .Add(new List<string>{ "g", "g", "g", "r", "r", "r", "g", "r", "g"}); // 19
        tiles .Add(new List<string>{ "g", "r", "g", "r", "r", "r", "g", "r", "g"}); // 20
        tiles .Add(new List<string>{ "g", "t", "g", "r", "r", "r", "g", "g", "g"}); // 21
        tiles .Add(new List<string>{ "g", "t", "g", "r", "r", "g", "g", "r", "g"}); // 22
        tiles .Add(new List<string>{ "g", "t", "g", "g", "r", "r", "g", "r", "g"}); // 23
        tiles .Add(new List<string>{ "g", "t", "g", "r", "r", "r", "g", "r", "g"}); // 24
        tiles .Add(new List<string>{ "g", "t", "t", "r", "r", "t", "g", "r", "t"}); // 25
        tiles .Add(new List<string>{ "g", "t", "ts", "r", "r", "t", "g", "r", "t"}); // 26
        tiles .Add(new List<string>{ "t", "t", "t", "t", "t", "t", "t", "r", "t"}); // 27
        tiles .Add(new List<string>{ "t", "t", "t", "t", "ts", "t", "t", "r", "t"}); // 28
        tiles .Add(new List<string>{ "g", "g", "g", "w", "m", "w", "g", "r", "g"}); // 29
        tiles .Add(new List<string>{ "g", "r", "g", "w", "r", "w", "g", "r", "g"}); // 30
        tiles .Add(new List<string>{ "g", "r", "g", "w", "w", "r", "g", "w", "g"}); // 31
        tiles .Add(new List<string>{ "g", "t", "g", "w", "r", "w", "g", "r", "g"}); // 32

    }

    private void CheckAvaiblePos()
    {
        for (int i = 0; i < tileCount; i++)
        {
            int curX = map[i][1];
            int curY = map[i][2];

            Vector3Int positionN = new Vector3Int(curX, curY + 1, 0);
            Vector3Int positionW = new Vector3Int(curX - 1, curY, 0);
            Vector3Int positionE = new Vector3Int(curX + 1, curY, 0);
            Vector3Int positionS = new Vector3Int(curX, curY - 1, 0);
            Vector3Int curPosition = new Vector3Int(curX, curY, 0);
            Vector3Int position;

            if (isClearTile(positionN))
            {
                // UP
                position = positionN;
                mainTile = Resources.Load<Tile>("plus");
                mainTileMap.SetTile(position, mainTile);
                if (!isSetable(position))
                {
                    mapAvaible.Add(position);
                    tileAvaibleCount++;
                }
                
            }

            if (isClearTile(positionW))
            {
                // Left
                position = positionW;
                mainTile = Resources.Load<Tile>("plus");
                mainTileMap.SetTile(position, mainTile);
                if (!isSetable(position))
                {
                    mapAvaible.Add(position);
                    tileAvaibleCount++;
                }
            }

            if (isClearTile(positionE))
            {
                // Right
                position = positionE;
                mainTile = Resources.Load<Tile>("plus");
                mainTileMap.SetTile(position, mainTile);
                if (!isSetable(position))
                {
                    mapAvaible.Add(position);
                    tileAvaibleCount++;
                }
            }

            if (isClearTile(positionS))
            {
                // Down
                position = positionS;
                mainTile = Resources.Load<Tile>("plus");
                mainTileMap.SetTile(position, mainTile);
                if (!isSetable(position))
                {
                    mapAvaible.Add(position);
                    tileAvaibleCount++;
                }
            }

        }
    }

    private void SetTile(int tileName, int angle, int x, int y)
    {
        mainTile = Resources.Load<Tile>(tileName.ToString());
        Vector3Int position = new Vector3Int(x, y, 0);

        mainTileMap.SetTile(position, mainTile);

        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f * ((4 - angle) % 4)), Vector3.one);

        mainTileMap.SetTransformMatrix(new Vector3Int(x, y, 0), matrix);

        if (isSetable(position))
        {
            mapAvaible.Remove(position);
            tileAvaibleCount--;
        }

        map.Add(new List<int> { tileName, x, y});

        List<string> backUp_list = new List<string>();

        backUp_list.Add(tiles[tileName][0].ToString());
        backUp_list.Add(tiles[tileName][1].ToString());
        backUp_list.Add(tiles[tileName][2].ToString());
        backUp_list.Add(tiles[tileName][3].ToString());
        backUp_list.Add(tiles[tileName][4].ToString());
        backUp_list.Add(tiles[tileName][5].ToString());
        backUp_list.Add(tiles[tileName][6].ToString());
        backUp_list.Add(tiles[tileName][7].ToString());
        backUp_list.Add(tiles[tileName][8].ToString());


        List<string> new_list = new List<string>();
        for (int i = 0; i < 9; i++)
        {
            new_list.Add("0");
            new_list[i] = backUp_list[i];
        }


        for (int j = 0; j < angle; j++)
        {
            new_list[0] = backUp_list[6].ToString();
            new_list[1] = backUp_list[3].ToString();
            new_list[2] = backUp_list[0].ToString();
            new_list[3] = backUp_list[7].ToString();
            new_list[4] = backUp_list[4].ToString();
            new_list[5] = backUp_list[1].ToString();
            new_list[6] = backUp_list[8].ToString();
            new_list[7] = backUp_list[5].ToString();
            new_list[8] = backUp_list[2].ToString();

            for (int i = 0; i < 9; i++)
            {
                backUp_list[i] = new_list[i];
            }

        }
        mapPos.Add(new List<string> { new_list[0], new_list[1], new_list[2], new_list[3], new_list[4], new_list[5], new_list[6], new_list[7], new_list[8] });
        tileCount++;

        CheckAvaiblePos();
    }


    private void SetMeeple(int delta_x=0, int delta_y=0)
    {
        int i = 0;
        foreach (string name in GlobalVariables.playersNames)
        {
            if (name == GlobalVariables.curPlayer)
            {
                break;
            }
            i++;
        }

        mainTile = Resources.Load<Tile>(GlobalVariables.playersColors[i]);

        int curX = map[tileCount - 1][1];
        int curY = map[tileCount - 1][2];

        Vector3Int position= new Vector3Int(curX, curY, 0);
        Vector3Int position_center = new Vector3Int(curX * 3 + delta_x + 1, curY * 3 + delta_y + 1, 0);
        meepleTileMap.SetTile(position_center, mainTile);

        coordsMeeples[GlobalVariables.curPlayerIndex].Add(position);

        GlobalVariables.playersMeeples[GlobalVariables.curPlayerIndex]--;
    }

    private bool isClearTile(Vector3Int position)
    {
        for (int i = 0; i < tileCount; i++)
        {
            if (map[i][1] == position.x && map[i][2] == position.y)
            {
                return false;
            }
        }
        return true;
    }

    private void CreateRandomCards(int[] count) 
    {
        var rand = new System.Random();
        for (int i = 0; i < GlobalVariables.curCards; i++)
        {
            randomCards.Add(0);
        }

        bool isNotFull = true;
        int j;
        while (isNotFull)
        {
            isNotFull = false;

            for (int i = 0; i < GlobalVariables.curCards; i++)
            {
                if (randomCards[i] == 0)
                {
                    j = 0;
                    while (count[j] < 0)
                    {
                        j = rand.Next(0, 32);
                    }
                    randomCards[i] = j;
                    count[j]--;

                    isNotFull = true;
                }
            }

        }
        // Debug.Log("Randomed!");

    }

    private void SetNextMove()
    {
        GlobalVariables.curPlayerIndex = (GlobalVariables.curPlayerIndex + 1) % (int)GlobalVariables.playerCount;
        GlobalVariables.curPlayer = GlobalVariables.playersNames[GlobalVariables.curPlayerIndex];
        GlobalVariables.curCard = randomCards[0].ToString();

        curCardIndex = randomCards[0];
        randomCards.Remove(randomCards[0]);

        GlobalVariables.curCards--;

    }

    private int GetScore(Vector3Int position_center)
    {
        int scores = 1;
        foreach (Vector3Int pos in coordsScore)
        {
            if (pos.x == position_center.x && pos.y == position_center.y)
            {
                return 0;
            }

        }
        coordsScore.Add(position_center);

        Vector3Int positionN = new Vector3Int(position_center.x, position_center.y + 1, 0);
        Vector3Int positionW = new Vector3Int(position_center.x - 1, position_center.y, 0);
        Vector3Int positionE = new Vector3Int(position_center.x + 1, position_center.y, 0);
        Vector3Int positionS = new Vector3Int(position_center.x, position_center.y - 1, 0);

        int card = GetCard(position_center);

        int cardN = GetCard(positionN);
        int cardW = GetCard(positionW);
        int cardE = GetCard(positionE);
        int cardS = GetCard(positionS);

        if (cardN >= 0)
        {
            if (mapPos[card][4] == mapPos[card][1])
            {

                scores += GetScore(positionN);
            } 
        }

        if (cardW >= 0)
        {
            if (mapPos[card][4] == mapPos[card][3])
            {

                scores += GetScore(positionW);
            }
        }

        if (cardE >= 0)
        {
            if (mapPos[card][4] == mapPos[card][5])
            {

                scores += GetScore( positionE);
            }
        }

        if (cardS >= 0)
        {
            if (mapPos[card][4] == mapPos[card][7])
            {

                scores += GetScore(positionS);
            }
        }

        return scores;
    }

    private void PrintTile(List<string> new_list)
    {
        Debug.Log(new_list[0] + " " + new_list[1] + " " + new_list[2]);
        Debug.Log(new_list[3] + " " + new_list[4] + " " + new_list[5]);
        Debug.Log(new_list[6] + " " + new_list[7] + " " + new_list[8]);
    }

    private bool isChangeble(List<string> new_list, Vector3Int second_position, int side)
    {
        int card = GetCard(second_position);
        List<string> placed_card = mapPos[card];
       

        if (placed_card[side] == new_list[8 - side] || (placed_card[side] == "ts" && new_list[8 - side] == "t") || placed_card[side] == "t" && new_list[8 - side] == "ts")
        {
            return true;
        }
        return false;
    }

    private int CorrectPosition(Vector3Int position)
    {
        Vector3Int positionN = new Vector3Int(position.x, position.y + 1, 0);
        Vector3Int positionW = new Vector3Int(position.x - 1, position.y, 0);
        Vector3Int positionE = new Vector3Int(position.x + 1, position.y, 0);
        Vector3Int positionS = new Vector3Int(position.x, position.y - 1, 0);

        int card = int.Parse(GlobalVariables.curCard);

        List<string> backUp_list = new List<string>();
        backUp_list.Add(tiles[card][0].ToString());
        backUp_list.Add(tiles[card][1].ToString());
        backUp_list.Add(tiles[card][2].ToString());
        backUp_list.Add(tiles[card][3].ToString());
        backUp_list.Add(tiles[card][4].ToString());
        backUp_list.Add(tiles[card][5].ToString());
        backUp_list.Add(tiles[card][6].ToString());
        backUp_list.Add(tiles[card][7].ToString());
        backUp_list.Add(tiles[card][8].ToString());

        bool canPlaced = true;
        int angle = -1;

        List<string> new_list = new List<string>();
        for (int i = 0; i < 9; i++)
        {
            new_list.Add("0");
            new_list[i] = backUp_list[i];
        }

        for (int j = 0; j < 4; j++)
        {
            canPlaced = true;

            if (!isClearTile(positionN))
            {
                if (!isChangeble(new_list, positionN, 7))
                {
                    canPlaced = false;
                }
            }

            if (!isClearTile(positionW))
            {
                if (!isChangeble(new_list, positionW, 5))
                {
                    canPlaced = false;
                }
            }

            if (!isClearTile(positionE))
            {
                if (!isChangeble(new_list, positionE, 3))
                {
                    canPlaced = false;
                }
            }

            if (!isClearTile(positionS))
            {
                if (!isChangeble(new_list, positionS, 1))
                {
                    canPlaced = false;
                }
            }

            if (canPlaced)
            {
                angle = j;
                break;
            }

            new_list[0] = backUp_list[6].ToString();
            new_list[1] = backUp_list[3].ToString();
            new_list[2] = backUp_list[0].ToString();
            new_list[3] = backUp_list[7].ToString();
            new_list[4] = backUp_list[4].ToString();
            new_list[5] = backUp_list[1].ToString();
            new_list[6] = backUp_list[8].ToString();
            new_list[7] = backUp_list[5].ToString();
            new_list[8] = backUp_list[2].ToString();

            for (int i = 0; i < 9; i++)
            {
                backUp_list[i] = new_list[i];
            }

        }

        // Check the sides of tiles 

        return angle;
    }

    private int GetCard(Vector3Int position)
    {
        for (int i = 0; i < tileCount; i++)
        {
            if (map[i][1] == position.x && map[i][2] == position.y)
            {
                return i;
            }
        }
        return -1;
    }

    private bool isSetable(Vector3Int position)
    {
        for (int i = 0; i < tileAvaibleCount; i++)
        {
            if (mapAvaible[i] == position)
            {
                return true;
            }
        }
        return false;
    }

    private void GenerateStartTile()
    {
        for (int i = 0; i < (int)GlobalVariables.playerCount; i++)
        {
            coordsMeeples.Add(new List<Vector3Int>());
        }

        SetTile(29, 0, startX, startY);

        SetTile(1, 0, startX, startY + 1);

        GlobalVariables.curCards -= 3;

    }

    // Start is called before the first frame update
    void Start()
    {
    
        escMenu.SetActive(false);
        int[] countTiles = { 4, 5, 1, 3, 3, 2, 2, 2, 3, 1, 1, 2, 2, 2, 1, 1, 2, 8, 9, 4, 1, 4, 3, 3, 3, 3, 2, 1, 2, 1, 1, 1, 1 };

        countTiles[29]--;
        countTiles[1]--;
        CreateMap();


        InitTiles();

        GenerateStartTile();


        CreateRandomCards(countTiles);

        GlobalVariables.curPlayer = GlobalVariables.playersNames[0];
        GlobalVariables.curCard = randomCards[0].ToString();


        curCardIndex = randomCards[0];
        randomCards.Remove(randomCards[0]);


        // Debug.Log(tiles [0][0]);

        // Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);

        // mainTileMap.SetTransformMatrix(new Vector3Int(21, 9, 0), matrix);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscMenuOpened)
            {
                escMenu.SetActive(false);
                isEscMenuOpened = false;
            }
            else
            {
                escMenu.SetActive(true);
                isEscMenuOpened = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            escMenu.SetActive(true);
            isEscMenuOpened = true;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            escMenu.SetActive(false);
            isEscMenuOpened = false;
        }

        if (Input.GetKeyUp(KeyCode.F5))
        {
            var rand = new System.Random();
            // mainTileMap.ClearAllTiles();

            // mainTile = Resources.Load<Tile>(rand.Next(1, 32).ToString());

            for (int i = 0; i < 30; i += rand.Next(1, 10))
            {
                for (int j = 0; j < 30; j += rand.Next(1, 10))
                {
                    mainTile = Resources.Load<Tile>(rand.Next(1, 32).ToString());
                    mainTileMap.SetTile(new Vector3Int(i, j, 0), mainTile);
                }
            }

        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = mainTileMap.WorldToCell(worldPoint);

            foreach (Vector3Int pos in coordsMeeples[GlobalVariables.curPlayerIndex])
            {
                if (pos == position)
                {
                    coordsMeeples[GlobalVariables.curPlayerIndex].Remove(pos);
                    GlobalVariables.playersMeeples[GlobalVariables.curPlayerIndex]++;
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Vector3Int new_pos = new Vector3Int(position.x * 3 + i, position.y * 3 + j, 0);
                            mainTile = Resources.Load<Tile>("null");
                            meepleTileMap.SetTile(new_pos, mainTile);
                        }
                    }
                    break;
                }
            }
        }

        if (GlobalVariables.curCards > 1)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) && !voted)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
                Vector3Int position = mainTileMap.WorldToCell(worldPoint);

                if (isSetable(position))
                {
                    int angle = CorrectPosition(position);
                    if (angle >= 0)
                    {
                        GlobalVariables.SoundButton();
                        SetTile(int.Parse(GlobalVariables.curCard), angle, position.x, position.y);

                        if (GlobalVariables.playersMeeples[GlobalVariables.curPlayerIndex] > 0)
                        {
                            questionMenu.SetActive(true);
                            // DO YOU WANT TO PLACE A MEEPLE?
                        }

                    }

                }
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
                Vector3Int position = mainTileMap.WorldToCell(worldPoint);

                Debug.Log(position);
            }
        }
        else
        {
            int border = (int)GlobalVariables.playerCount;
            for (int i = 0; i < border; i++)
            {
                for (int j = 0; j < coordsMeeples[i].Count; j++)
                {
                    coordsScore = new List<Vector3Int>();
                    GlobalVariables.playersScore[i] = GetScore(coordsMeeples[i][j]);
                    coordsMeeples[i].Remove(coordsMeeples[i][j]);
                }

            }

            endText.SetActive(true);
        }
       
    }

    public void SelectSide(int delta)
    {
        int delta_x = 0;
        int delta_y = 0;

        switch (delta)
        {
            case 1:
                delta_x = -1;
                break;
            case 4:
                delta_x = -1;
                break;
            case 7:
                delta_x = -1;
                break;
            case 3:
                delta_x = 1;
                break;
            case 6:
                delta_x = 1;
                break;
            case 9:
                delta_x = 1;
                break;
        }

        switch (delta)
        {
            case 1:
                delta_y = 1;
                break;
            case 2:
                delta_y = 1;
                break;
            case 3:
                delta_y = 1;
                break;
            case 7:
                delta_y = -1;
                break;
            case 8:
                delta_y = -1;
                break;
            case 9:
                delta_y = -1;
                break;
        }

        SetMeeple((int)delta_x, (int)delta_y);
        
        sideMenu.SetActive(false);
        voted = false;
        SetNextMove();
    }

    public void Yes()
    {
        voted = true;
        GlobalVariables.setMeeple = true;
        questionMenu.SetActive(false);
        sideMenu.SetActive(true);


    }

    public void No()
    {
        voted = false;
        GlobalVariables.setMeeple = false;
        questionMenu.SetActive(false);
        SetNextMove();
    }

    public void AddScores()
    {
        int count = 0;

        GlobalVariables.SoundButton();

        GlobalVariables.playersScore[0] += 100;
        GlobalVariables.playersMeeples[0] -= 1;

        GlobalVariables.playersScore[1] += 50;
        GlobalVariables.playersMeeples[1] += 1;

        GlobalVariables.curCards--;
    }

}
