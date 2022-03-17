using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public GameObject blockPrefab;

    private float initialDelay = 0.1f;
    private float delay = 0.05f;

    // Relative positions per player for DEMO
    private Vector3[][] opponent1BlockPosititions = new Vector3[][]
    {
        new Vector3[] { },
        new Vector3[] { new Vector3(0, 0, -1), new Vector3(1, 0, 0) },
        new Vector3[] { new Vector3(1, 0, -1), new Vector3(0, 0, -2) },
        new Vector3[] { new Vector3(1, 0, -2), new Vector3(0, 0, -3) },
        new Vector3[] { new Vector3(1, 0, -3) },
    };


    private Vector3[][] opponent2BlockPosititions = new Vector3[][]
    {
        new Vector3[] { },
        new Vector3[] { new Vector3(1, 0, 0) },
        new Vector3[] { new Vector3(2, 0, 0), new Vector3(1, 0, 1) },
        new Vector3[] { new Vector3(2, 0, 1) },
        new Vector3[] { new Vector3(3, 0, 1), new Vector3(2, 0, 2) },
        new Vector3[] { new Vector3(3, 0, 2) },
        new Vector3[] { new Vector3(4, 0, 2) },
        new Vector3[] { new Vector3(5, 0, 2) },
        new Vector3[] { new Vector3(6, 0, 2), new Vector3(5, 0, 1) },
        new Vector3[] { new Vector3(6, 0, 1) },
        new Vector3[] { new Vector3(7, 0, 1), new Vector3(6, 0, 0) },
        new Vector3[] { new Vector3(7, 0, 0) },
        new Vector3[] { new Vector3(8, 0, 0) },
    };

    private Vector3[][] playerBlockPosititions = new Vector3[][]
    {
        new Vector3[] { new Vector3(0, 0, 0) },
        new Vector3[] { new Vector3(1, 0, 0), new Vector3(0, 0, 1) },
        new Vector3[] { new Vector3(2, 0, 0), new Vector3(1, 0, 1), new Vector3(0, 0, 2), new Vector3(-1, 0, 1) },
        new Vector3[] { new Vector3(3, 0, 0), new Vector3(-1, 0, 2) },
        new Vector3[] { new Vector3(4, 0, 0), new Vector3(3, 0, 1), new Vector3(-2, 0, 2) },
        new Vector3[] { new Vector3(4, 0, 1) },
        new Vector3[] { new Vector3(5, 0, 1), new Vector3(4, 0, 2) },
        new Vector3[] { new Vector3(5, 0, 2) },
        new Vector3[] { new Vector3(6, 0, 2), new Vector3(5, 0, 3) },
        new Vector3[] { new Vector3(6, 0, 3), new Vector3(5, 0, 4) },
        new Vector3[] { new Vector3(6, 0, 4), new Vector3(5, 0, 5) },
        new Vector3[] { new Vector3(6, 0, 5), new Vector3(5, 0, 6) },
        new Vector3[] { new Vector3(6, 0, 6) },
    };


    // Start is called before the first frame update
    void Start()
    {
        var blockPositions = name switch
        {
            "Opponent1Block" => opponent1BlockPosititions,
            "Opponent2Block" => opponent2BlockPosititions,
            "PlayerBlock" => playerBlockPosititions,
            _ => throw new System.ArgumentOutOfRangeException(nameof(name), $"No such block for demo: {name}"),
        };

        StartCoroutine(SpawnDemoBlocks(blockPositions));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnDemoBlocks(Vector3[][] blockPositions)
    {
        yield return new WaitForSeconds(initialDelay);
        for (int i = 0; i < blockPositions.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            foreach (Vector3 relativePosition in blockPositions[i])
            {
                var position = transform.position + relativePosition;
                var block = Instantiate(blockPrefab) as GameObject;
                block.transform.position = position;
                yield return new WaitForSeconds(0.01f);
            }
            if (i == 0) yield return new WaitForSeconds(0.5f);
        }
    }
}
