using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance { get; private set; }

    [SerializeField] private GameObject RedPrefab;
    [SerializeField] private GameObject GreenPrefab;
    [SerializeField] private GameObject YellowPrefab;
    [SerializeField] private GameObject SlotPrefab;

    private List<GameObject> _greens = new List<GameObject>();
    private List<GameObject> _reds = new List<GameObject>();
    private List<GameObject> _yellows = new List<GameObject>();
    private List<GameObject> _slots = new List<GameObject>();
    private List<GameObject> _allGreens = new List<GameObject>();
    private List<GameObject> _allReds = new List<GameObject>();
    private List<GameObject> _allYellows = new List<GameObject>();
    private List<GameObject> _allSlots = new List<GameObject>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearScene()
    {
        foreach (var obj in _allGreens)
        {
            if (obj.activeSelf == true)
            {
                obj.SetActive(false);
                _greens.Add(obj);
            }
        }
        foreach (var obj in _allYellows)
        {
            if (obj.activeSelf == true)
            {
                obj.SetActive(false);
                _yellows.Add(obj);
            }
        }
        foreach (var obj in _allReds)
        {
            if (obj.activeSelf == true)
            {
                obj.SetActive(false);
                _reds.Add(obj);
            }
        }
        foreach (var obj in _allSlots)
        {
            if (obj.activeSelf == true)
            {
                obj.SetActive(false);
                _slots.Add(obj);
            }
        }
    }

    #region unImplemented


    /* public void TakeStarToPool(GameObject go)
     {
         go.SetActive(false);
         _stars.Add(go);
     }*/

    /* public GameObject GetNewStar(SlotModel slotModel,string place)
     {
         GameObject go;
             if (_stars.Count == 0)
             {
                 go = Instantiate(StarPrefab,slotModel.SlotView.GetPos(place),StarPrefab.transform.rotation);
                 _allStars.Add(go);
                 return go;
             }
          go = _stars[0];
         _stars.RemoveAt(0);
         go.SetActive(true);
         go.transform.position = slotModel.SlotView.GetPos(place);
         return go;
     }   *unimplemented* */
    #endregion



    public void TakeToPool(GameObject obj)
    {
        if (obj.CompareTag("Green"))
            _greens.Add(obj);
        else if (obj.CompareTag("Red"))
            _reds.Add(obj);
        else 
            _yellows.Add(obj);
        obj.SetActive(false);
            
    }
    public GameObject GetNewObject(string color, Transform transform)
    {
        GameObject obj;
        switch (color)
        {
            case "green":
                if (_greens.Count > 0)
                {
                    obj = _greens[0];
                    obj.gameObject.SetActive(true);
                    // obj.gameObject.transform.parent = transform;
                    obj.gameObject.transform.position = transform.position;
                    _greens.RemoveAt(0);
                    return obj;
                }

                obj = Instantiate(GreenPrefab, transform);
                _allGreens.Add(obj);
                return obj;
            case "red":
                if (_reds.Count > 0)
                {
                    obj = _reds[0];
                    obj.gameObject.SetActive(true);
                    //obj.gameObject.transform.parent = transform;
                    obj.gameObject.transform.position = transform.position;
                    _reds.RemoveAt(0);
                    return obj;
                }

                obj = Instantiate(RedPrefab, transform);
                _allReds.Add(obj);
                return obj;
            case "yellow":
                if (_yellows.Count > 0)
                {
                    obj = _yellows[0];
                    obj.gameObject.SetActive(true);
                    //  obj.gameObject.transform.parent = transform;
                    obj.transform.position = transform.position;
                    _yellows.RemoveAt(0);
                    return obj;
                }

                obj = Instantiate(YellowPrefab, transform);
                _allYellows.Add(obj);
                return obj;
            default:
                Debug.LogError("Tryna get wrong color");
                return null;
        }
    }

    public GameObject GetNewObject(string color, Vector3 vector)
        {
            GameObject obj;
            switch (color) {
                case "green":
                    if (_greens.Count > 0)
                    {
                        obj = _greens[0];
                        obj.gameObject.SetActive(true);
                        obj.gameObject.transform.position = vector;
                        _greens.RemoveAt(0);
                        return obj;
                    }
                    obj = Instantiate(GreenPrefab, vector,GreenPrefab.transform.rotation);
                    _allGreens.Add(obj);
                    return obj;
                case "red":
                    if (_reds.Count > 0)
                    {
                        obj = _reds[0];
                        obj.gameObject.SetActive(true);
                        obj .gameObject.transform.position = vector;
                        _reds.RemoveAt(0);
                        return obj;
                    }
                    obj = Instantiate(RedPrefab, vector,RedPrefab.transform.rotation);
                    _allReds.Add(obj);
                    return obj;
                case "yellow":
                    if (_yellows.Count > 0)
                    {
                        obj = _yellows[0];
                        obj.gameObject.SetActive(true);
                        obj.transform.position = vector; 
                        _yellows.RemoveAt(0);
                        return obj;
                    }
                    obj = Instantiate(YellowPrefab, vector, YellowPrefab.transform.rotation);
                    _allYellows.Add(obj);
                    return obj;
                default:
                    Debug.LogError("Tryna get wrong color");
                    return null;
            }

    }


    public int RemainingActiveObjects()
    {
        int reds = _allReds.Count - _reds.Count;
        int greens = _allGreens.Count - _greens.Count;
        int yellows = _allYellows.Count - _yellows.Count;

        Debug.Log($"remaining reds {reds}, remaining greens {greens}, remaining yellows {yellows}");
        return reds + yellows + greens;

    }
    public GameObject GetNewSlot(Transform transform)
    {
        GameObject obj;
        if (_slots.Count > 0)
        {
            obj = _slots[0];
            obj.gameObject.SetActive(true);
            obj.transform.position = transform.position;
            _slots.RemoveAt(0);
            return obj;
        }
        obj = Instantiate(SlotPrefab, transform.position,SlotPrefab.transform.rotation);
        _allSlots.Add(obj);
        return obj;
    }    
    public GameObject GetNewSlot(Vector3 vector)
    {
        GameObject obj;
        if (_slots.Count > 0)
        {
            obj = _slots[0];
            obj.gameObject.SetActive(true);
            obj.transform.position = vector;
            _slots.RemoveAt(0);
            return obj;
        }
        obj = Instantiate(SlotPrefab, vector,SlotPrefab.transform.rotation);
        _allSlots.Add(obj);
        return obj;
    }


    
}
