using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Dynamic;

public class Map : MonoBehaviour
{
    public static Map ins;
    GridLayoutGroup gridLayout;
    [SerializeField] int column;
    [SerializeField] int row;
    [SerializeField] Cell cell;
    [SerializeField] public PoliceCar car;
    [SerializeField] CermentTruck truck;
    public Cell cellOnCar;
    public Cell[,] MatrixCells;
    [SerializeField] public CameraSet cam;
    [SerializeField] Sprite fixedHoleSprite;
    [SerializeField] Image hole;
    [SerializeField] Image phone;
    public int[,] CanMove =
    {
        {1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0},
        {0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1},
        {0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1},
        {1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1},
        {0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1}
    };

    public int rowHole = 4;
    public int colHole = 28;

    int rowPhone = 1;
    int colPhone = 27;

    private void Awake()
    {
        ins = this;
        gridLayout = GetComponent<GridLayoutGroup>();
        MatrixCells = new Cell[row, column];
        InstantiateCell();
        InstantiateCar();
        gridLayout.constraintCount = column;

    }

    private void InstantiateCell()
    {
        for(int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                MatrixCells[i, j] = Instantiate(cell, transform.position, Quaternion.identity, transform);
                MatrixCells[i, j].indexRow = i;
                MatrixCells[i, j].indexCol = j;
            }
        }
    }

    void InstantiateCar()
    {
        cellOnCar = MatrixCells[0, 0];
        //car.transform.position = cellOnCar.transform.position;
       
    }

    public void UpdatePositionCar(int newRow, int newCol)
    {
        cellOnCar = MatrixCells[newRow, newCol];
        if (cellOnCar.indexCol == colPhone && cellOnCar.indexRow == rowPhone)
        {
            if (phone.gameObject)
            {
                Destroy(phone.gameObject);
            }
            if (truck) truck.gameObject.SetActive(true);
        }

        if (cellOnCar.indexCol == 32 && cellOnCar.indexRow == 1)
        {
            Debug.Log("EndGame");
        }
    }

    public void FixedHole()
    {
        hole.sprite = fixedHoleSprite;
        CanMove[rowHole, colHole] = 1;
    }

    public void SetTrueCellBridge()
    {
        CanMove[2, 5] = 1;
        CanMove[2, 6] = 1;
        CanMove[2, 7] = 1;
        CanMove[2, 8] = 1;
    }

    public void SetFalseCellBridge()
    {
        CanMove[2, 5] = 0;
        CanMove[2, 6] = 0;
        CanMove[2, 7] = 0;
        CanMove[2, 8] = 0;
    }


}
