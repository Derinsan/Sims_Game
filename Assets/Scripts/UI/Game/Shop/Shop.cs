using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _panelShop;
    public static bool _isShopOpen;
    [SerializeField] private GameObject _bakePrefab;
    private Vector3 _instantiate = new Vector3(0, -2f, 0);
    private int _bakeCount = 0;

    public static event Action ActionCanvasActive;

    private void Start()
    {
        _panelShop.SetActive(false);
    }

    public void OpenShop()
    {
        SwitchOpenShop(_isShopOpen);
    }

    private void SwitchOpenShop(bool status)
    {
        _isShopOpen = !status;
        _panelShop.SetActive(!status);
    }

    public void BuyBake()
    {
        if (_bakeCount == 0)
        {
            GameObject newBake = Instantiate(_bakePrefab, _instantiate, Quaternion.identity);
            _bakeCount++;
            ActionCanvasActive?.Invoke();
        }
    }

    public void RotateObject(float angle)
    {
        transform.Rotate(Vector3.forward, angle);
    }
}
