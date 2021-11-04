using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    private float _tileHeight = 0.2f, _tileWidth = 2f;
    private float index = 0;
    float hue;

    public static TilesSpawner instance = null;

    void Start()
    {

        if (instance == null) { instance = this; }
        if (_tilePrefab == null) { Debug.Log("Tile Prefab isnt set!"); }

        for (int i = 0; i < 10; i++)
            SpawnTile();
        ColorChange();

    }
    void ColorChange()
    {
        hue = Random.Range(0f, 1f);
        Camera.main.backgroundColor = Color.HSVToRGB(hue, 0.6f, 0.8f);
    }
    public void SpawnTile()
    {

        float RandomXPos;
        if (index == 0)
            RandomXPos = 0;
        else
            RandomXPos = Random.Range(-3f, 3f);

        Vector2 newPos = new Vector2(RandomXPos, index * 2.5f);

        GameObject tile = Instantiate(_tilePrefab, newPos, Quaternion.identity);
        tile.transform.SetParent(transform);
        tile.transform.localScale = new Vector2(_tileWidth, _tileHeight);
        SetStairColor();
        index++;

    }
    void SetStairColor()
    {

        hue += 0.08f;
        if (hue > 1)
            hue -= 1;

        _tilePrefab.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, 1f, 1f);
    }

}