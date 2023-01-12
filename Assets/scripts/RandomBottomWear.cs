using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Utils = AvatarSysUtil.Utils;

public class RandomBottomWear : MonoBehaviour
{
    
    [SerializeField] private Button btnRandomBottomWear;
    
    [SerializeField] private SkinnedMeshRenderer[] bottom;
    // Start is called before the first frame update
    void Start()
    {
        btnRandomBottomWear.onClick.AddListener(() => Execute());
    }

    private void Execute()
    {
        var randomID = Utils.ID2String(Random.Range(1, 20));
        btnRandomBottomWear.GetComponentInChildren<Text>().text = "bottom: " + randomID;

        foreach (var smr in bottom)
        {
            var meshPath = String.Format("res/{0}/mesh_Bottom", randomID);
            smr.sharedMesh = Resources.Load<Mesh>(meshPath);
            var materialPath = String.Format("res/{0}/mat_Bottom", randomID);
            smr.sharedMaterial = Resources.Load<Material>(materialPath);
        }
        
    }
}
