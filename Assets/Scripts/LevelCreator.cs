using UnityEngine;
using Random = System.Random;

public class LevelCreator : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Sector;
    public GameObject CylinderRoot;
    public Game Game;
    public int platformNumberMin = 5;
    public int platformNumberMax = 10;
    private float _distance = 1.5f;
    private float _rotation = 30;
    private Random _random;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        _random = new Random(levelIndex);
        int platformNumber = RandomRange(platformNumberMin, platformNumberMax + 1);
        for (int i = 0; i < platformNumber; i++)
        {
            CreatePlatform(i);
        }
        CreatePlatform(platformNumber, true);

        float cylinderRootScale = (platformNumber + 1) * _distance;
        CylinderRoot.transform.localScale = new Vector3(1, cylinderRootScale, 1);
    }

    private int RandomRange(int min, int max)
    {
        int number = _random.Next();
        int length = max - min;
        number %= length;
        return number + min;
    }

    private void CreatePlatform(int platformNumber)
    {
        CreatePlatform(platformNumber, false);
    }

    private void CreatePlatform(int platformNumber, bool isFinish)
    {
        GameObject platform = Instantiate(Platform, transform);
        platform.transform.localPosition = new Vector3(0, -_distance * platformNumber, 0);
        platform.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (isFinish)
        {
            for (int i = 0; i < 12; i++)
                CreateSector(i, false, true, platform.transform);
            platform.name = "Finish Platform";
            return;
        }
        int sectorNumber = RandomRange(4, 12);
        int badSectorNumber = RandomRange(0, sectorNumber / 2 - 1);
        int startSector = 0;
        if (platformNumber == 0)
        {
            CreateSector(0, platform.transform);
            startSector++;
            sectorNumber--;
            platform.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        for (int i = startSector; i < 12; i++)
        {
            if (sectorNumber > 0 && (sectorNumber == 11 - i || RandomRange(0, 100) > 33))
            {
                sectorNumber--;
                if (badSectorNumber > 0 && (badSectorNumber == sectorNumber + 1 || RandomRange(0, 100) > 74))
                {
                    badSectorNumber--;
                    CreateSector(i, true, platform.transform);
                } else
                {
                    CreateSector(i, platform.transform);
                }
            }
        }
    }

    private void CreateSector(int sectorNumber, Transform platform)
    {
        CreateSector(sectorNumber, false, false, platform);
    }

    private void CreateSector(int sectorNumber, bool isBad, Transform platform)
    {
        CreateSector(sectorNumber, isBad, false, platform);
    }

    private void CreateSector(int sectorNumber, bool isBad, bool isFinish, Transform platform)
    {
        GameObject sector = Instantiate(Sector, platform);
        sector.transform.localPosition = new Vector3(0, 0, 0);
        sector.transform.localRotation = Quaternion.Euler(0, _rotation * sectorNumber, 0);
        Sector ssector = sector.GetComponent<Sector>();
        ssector.IsFinish = isFinish;
        ssector.IsBad = isBad;
        ssector.UpdateMaterial();
    }
}
