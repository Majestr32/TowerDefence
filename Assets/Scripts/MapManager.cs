using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMap;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase,TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePosition, 0.1f);
             if (IsTileOpenShoot(mousePosition) && colliders.Length == 0)
             {
                 Vector3Int gridPosition = GetGridPosition(mousePosition);
                 Vector3 globalPosition = tileMap.GetCellCenterWorld(gridPosition);

                 TowersManager.Instance.SelectedCellPosition = globalPosition;
                 TurretMenuPannel.Instance.OpenPlanningMenu();
             }
        }
    }
    public void UpgradeTower()
    {

    }
    public void PlaceTurret()
    {

    }
    void OpenSpawnCreationMenu()
    {

    }

    public bool IsTileOpenShoot(Vector2 mousePosition)
    {
        Vector3Int gridPosition = GetGridPosition(mousePosition);
        TileBase clickedTile = tileMap.GetTile(gridPosition);
        return dataFromTiles[clickedTile].canPlaceTurret;
    }
    private Vector3Int GetGridPosition(Vector2 mousePosition)
    {
        return tileMap.WorldToCell(mousePosition);
    }
}
