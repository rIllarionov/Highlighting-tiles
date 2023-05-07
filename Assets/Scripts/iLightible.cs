using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iLightible : MonoBehaviour
{
    [SerializeField] 
    private Renderer _renderer; //сюда передаем рендер префаба чтобы был доступ к его цвету
    private Color _normalColor; //сюда запишем нормальный цвет объекта
    private Color _modifyColor; //сюда запишем модифицированный (светящийся) цвет
    
    void Start()
    {
        _normalColor = _renderer.material.color; //на старте считываем нормальный цвет 
        _modifyColor = _normalColor + Color.gray; //и модифицируем (создаем его светящийся вариант)
    }

    public void LightsOn() //метод который меняет цвет нашего объекта на светящийся
    {
        _renderer.material.color = _modifyColor;
    }

    public void LightsOff() //метод меняющий цвет объекта на базовый
    {
        _renderer.material.color = _normalColor;
    }
    
}
