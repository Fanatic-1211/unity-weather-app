using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;


public class WeatherAPI : MonoBehaviour
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

    public TMP_Text cityNameText;
    public TMP_Text currentTempText;
    public TMP_Text descriptionWeatherText;

    private void Start()
    {
        foreach (string city in capitalZACities)
        {
            StartCoroutine(GetWeatherData(city)); //automatically call the API and update the latest weather data when the scene is played
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
                cityNameText.text = city;
                currentTempText.text = $"Temperature: {(weatherData.main.temp - 273.15f):F1} °C";
                //Debug.Log("descriptionText is " + (descriptionWeatherText == null ? "null" : "not null"));
                Debug.Log("weatherData is " + (weatherData == null ? "null" : "not null"));
                descriptionWeatherText.text = $"Description: {weatherData.weather[0].main}";
            }
        }
    }

    [System.Serializable]
    private class WeatherData
    {
        public MainData main;
        public WeatherInfo[] weather;
    }

    [System.Serializable]
    private class MainData
    {
        public float temp;
    }
}

