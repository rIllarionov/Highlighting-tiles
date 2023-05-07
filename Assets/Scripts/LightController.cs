using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private iLightible _currentObject;//сюда будем записывать найденный объект способный светиться
    
    void Update()
    {
        var ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);//создали луч

        if (Physics.Raycast(ray,out RaycastHit info,50f))//если луч попал в объект
        {
            if (info.collider.TryGetComponent<iLightible>(out iLightible newObject))//проверяем подходит ли он нам
            {
                GetNewILightibleObject(newObject);//если подходит отправляем его в метод
            }
            else
            {
                GetAnotherObject();//иначе мы наткнулись на неподходящий объект
            }
        }
        
        else
        {
            GetAnotherObject();//если луч не нашел объект вовсе, так же запускаем метод
        }

    }

    void GetNewILightibleObject(iLightible newObject) //если нашли новый объект способный светиться
    {
        if (_currentObject!=null) //проверяем был ли у нас до этого такой объект
        {
            _currentObject.LightsOff(); //если да, то выключаем его свечение
        }

        _currentObject = newObject; //записываем новый объект в текущий
        _currentObject.LightsOn(); //и включаем его свечение
    }

    void GetAnotherObject() //если луч попал в неподходящий нам объект или не попал в объект совсем
    {
        if (_currentObject!=null) //проверяем есть ли сейчас светящийся объект.
        {
            _currentObject.LightsOff(); //если да, то гасим его
            _currentObject = null; //и обнулям текущий объект
        }
    }
}
