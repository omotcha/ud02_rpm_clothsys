using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvatarSysUtil;

public class ModelResExtractorTrigger : MonoBehaviour
{
    private string[] _ids = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"
        , "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"};
    // private string[] _ids = { "01", "02", "03", "04"};
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(var id in _ids){
            var extractor = new ModelResExtractor(id,string.Format("models/{0}", id));
            extractor.Extract("Wolf3D_Hair");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
