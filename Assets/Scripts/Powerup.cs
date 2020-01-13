using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Powerup : MonoBehaviour
{
    [System.Serializable]
    public struct PowerupData 
    {
        public float speed;
        public Color color;
        public Vector3 scale;
        [System.NonSerialized]
        public float mass;

        public enum ColorType { None, Custom, Random };
        public enum ScaleSize { None, Custom, Random };

        public ColorType colorType;
        public ScaleSize scaleSize;
    }
    [SerializeField]
    public PowerupData powerupData = new PowerupData
    {
        speed = 0,
        color = Color.white,
        scale = Vector3.zero,
        mass = 0,
        scaleSize = PowerupData.ScaleSize.None,
        colorType = PowerupData.ColorType.None
    };

    private void OnEnable()
    {
        PowerupManager.Instance.IncreasePowerups();
        //Debug.Log(PowerupManager.Instance.instancedPowerups);
    }
    private void OnTriggerEnter()
    {
        Destroy(gameObject);
        PowerupManager.Instance.DecreasePowerups();
        //Debug.Log(PowerupManager.Instance.instancedPowerups);
    }

}
