using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Adapted from this youtube video: https://www.youtube.com/watch?v=HCt_CYOW9jg

namespace ErikOverflow.YardDefender
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager instance;
        public Tilemap walkable = null;
        BoundsInt bounds;
        public Vector3Int[,] spots;
        Astar astar;

        Camera mainCamera = null;

        private void Awake()
        {
            instance = this;
            mainCamera = Camera.main;
            walkable.CompressBounds();
            bounds = walkable.cellBounds;

            CreateGrid();
            astar = new Astar(spots, bounds.size.x, bounds.size.y);
        }

        private void CreateGrid()
        {
            spots = new Vector3Int[bounds.size.x, bounds.size.y];
            for (int x = bounds.xMin, i = 0; i < bounds.size.x; x++, i++)
            {
                for (int y = bounds.yMin, j = 0; j < bounds.size.y; y++, j++)
                {
                    if (walkable.HasTile(new Vector3Int(x, y, 0)))
                    {
                        spots[i, j] = new Vector3Int(x, y, 0);
                    }
                    else
                    {
                        spots[i, j] = new Vector3Int(x, y, 1);
                    }
                }
            }
        }

        public List<Spot> GetPath(Vector3 startingPos, Vector3 endingPos)
        {
            Vector3Int startPos = walkable.WorldToCell(startingPos);
            Vector3Int endPos = walkable.WorldToCell(endingPos);
            List<Spot> path = astar.CreatePath(spots, new Vector2Int(startPos.x, startPos.y), new Vector2Int(endPos.x, endPos.y), 1000);
            path.Reverse();
            return path;
        }

        public Vector2 GetSpotWorldPosition(Spot spot)
        {
            return walkable.CellToWorld(new Vector3Int(spot.X, spot.Y, 0)) + new Vector3(0.5f, 0.5f, 0);
        }
    }
}