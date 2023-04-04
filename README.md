Unity Task 1: Moving Cube Game

In this task, we'll be creating a simple game where the player controls a cube that moves around the screen, changing color as it goes. We'll also be setting up a main menu and a loading screen to transition between scenes.

Step 1: Create Scenes

Create two scenes: Main Menu and Level One. The Main Menu scene will contain a UI Button that will load in the Level One scene when the button is clicked.
Step 2: Load Level One

Create a script to handle the loading of Level One. In the Main Menu scene, attach the script to the UI Button so that the Level One scene is loaded when the button is clicked.
Step 3: Set Camera to Orthographic

In the Level One scene, set the camera to 'orthographic'. This will allow us to create a 2D game with a fixed camera view.
Step 4: Add a cube to the Level One scene and set its position so that it is in the middle of the camera view.
Step 5: Move the Cube

Write a script that moves the cube with physics using a rigidbody on the cube. The cube should move up, down, left and right using the WASD keys. The script should also change the color of the cube depending on the direction it's moving in (e.g. blue if moving left, yellow if moving down, etc).
Step 6: Teleport the Cube

If the cube reaches the edges of the camera view, it should re-appear on the opposite edge of the view (e.g. if the cube goes off the left side of the view, it should re-appear on the right side of the screen).
Step 7: Change the Velocity

Give the player the ability to change the velocity the cube travels at. This could be done through either UI or keyboard inputs. Use your discretion to implement this.

Unity Weather App

This project is a simple weather app built with Unity that uses the OpenWeather API to display the weather information for the capital cities of each province in South Africa.
Getting Started

To get started with this project, you'll need to do the following:

    Sign up for a free account on OpenWeather to get an API key.
    Clone or download this repository.
    Open the WeatherApp scene in Unity.

How to Use

Upon opening the WeatherApp scene, the app will automatically call the OpenWeather API and display the latest weather data for the capital cities of each province in South Africa. The city name, current temperature, and weather description will be displayed on the UI.
Implementation Details

The app was built using Unity's C# scripting language and the TextMeshPro UI framework.

The code calls the OpenWeather API using the UnityWebRequest class and receives a JSON response, which is parsed using the JsonUtility class. The app then displays the relevant weather information on the UI using TextMeshPro.
Credits

    OpenWeather for providing the weather data and API.
    TextMeshPro for the UI text framework.

License

This project is licensed under the MIT License. See the LICENSE file for details.

