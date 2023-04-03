using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherAPIController : MonoBehaviour
{
    public string apiKey = "3c048ebccdde6a122a3acd36c9f24b31"; // Your OpenWeather API key.
    private List<string> capitalZACities = new List<string> {
        "Johannesburg",
        "Nelspruit",
        "Pietermaritzburg",
        "Polokwane",
        "Cape Town",
        "Bloemfontein",
        "Port Elizabeth",
        "Pretoria"
    };

    private void Start()
    {
        foreach (string city in capitalZACities)
        {
            StartCoroutine(GetWeatherData(city));
        }
    }

    private IEnumerator GetWeatherData(string city)
    {
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={city},ZA&appid={apiKey}";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Weather API request failed for {city}: {webRequest.error}");
            }
            else
            {
                string data = webRequest.downloadHandler.text;
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(data);
                float celsius = weatherData.main.temp - 273.15f;
                Debug.Log($"Current temperature in {city}: {celsius} degrees Celsius");
            }
        }
    }

    [System.Serializable]
    private class WeatherData
    {
        public MainData main;
    }

    [System.Serializable]
    private class MainData
    {
        public float temp;
    }
}

