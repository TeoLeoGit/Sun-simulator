# Sun simulation

## Table of contents
* [General info](#general-info)
* [Background](#background)
* [Set up](#set-up)
* [Result](#result)

## General info
This project is created to simulate the altitude and position of the sun base on the coordinates of a location on Earth at a specific time in a day of a year. 

This project was created in Unity Editor version 2021.3.10f1.

## Background
To calculate and simulate the altitude and position of the Sun at a coordinate on Earth, we need to measure the **elevation angle** and the **azimuth angle** of the Sun.
* **Elevation angle**: The solar elevation is the angular distance between the imaginary horizontal plane on which you are standing and the sun in the sky. It is also known as the solar latitude angle and measured in degrees. In simple words, it tells at what height the sun is in the sky. In the morning and evening, the sun is low in the sky, near the horizon. So, the solar elevation is close to 0°, whereas, at solar noon, the solar elevation angle is highest since the sun is overhead.

  ![Elevation angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-elevation-angle-noon-morning-evening.png)
* **Azimuth angle**: The solar azimuth angle is a way to identify the position of the sun in the sky. It defines the horizontal position of the sun on the local horizontation of solar panels.

  ![Azimuth angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-azimuth-angle-direction.png)

* When we have measured these two angles, we can locate the position of the Sun.

  ![Position of the Sun](https://keisan.casio.com/keisan/lib/real/system/2006/1224682277/anglefigure.gif)

To achieve that, we need to first estimate the **hour angle**, and the **declination angle** for measuring the **solar elevation angle** and then we can be able to find the **azimuth angle**.

* The solar **hour angle** is a measure of the angular distance between the sun at the local solar time and the sun at solar noon. It is expressed in degrees or radians.

  ![Hour angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-hour-angle-suns.png)
  
### Solar hour angle formula
Let LST be the local solar time in the 24-hour format. The solar hour angle (h) in degrees is as follows:

  ![Hour angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-hour-angle-formula.svg)
 
In the above equation, the local solar time (LST) is in hours. We can convert LST in hours to LST in minutes.
  
  ![Hour angle formula - minute](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-hour-angle-formula-min.svg)

* The solar **declination angle** is the angle between the rays of the sun and the equator of the earth. It is usually denoted by “δ.” Solar declination angle is very useful in calculating the sun elevation and the azimuth angle.
  
  ![Declination angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/declination-angle-earth-sun.png)
  
* The solar **declination angle** changes time-to-time; it is not a constant number. It will be different every single day. However, the angle restricts itself between 23.44° and −23.44°. It oscillates between these two numbers; it will never cross 23.44° or fall behind −23.44°. Thus, we can conclude, the maximum value of the solar declination angle is 23.44°, and the minimum is −23.44°.

  ![Declination angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/equinox-solstice.png)
  
### Solar declination angle formula
We can calculate the solar declination angle using the following formula:

  ![Declination angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/declination-angle-formula.svg)

In the above formula, d is the number of days since January 1st (UTC 00:00:00). For example, On March 3rd (UTC 00:00:00), d = 31 + 28 + 2 = 61. On December 31st (UTC 00:00:00), d = 364.

Now we can measure the **elevation angle**. 

* The solar elevation is the angular distance between the imaginary horizontal plane on which you are standing and the sun in the sky. It is also known as the solar latitude angle and measured in degrees. In simple words, it tells at what height the sun is in the sky. In the morning and evening, the sun is low in the sky, near the horizon. So, the solar elevation is close to 0°, whereas, at solar noon, the solar elevation angle is highest since the sun is overhead.

  ![Elevation angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-elevation-angle-noon-morning-evening.png)

The solar elevation is the measurement of the height (or altitude) of the sun in the sky.

### Solar elevation angle formula

The solar elevation formula is as follows:

  ![Elevation angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/declination-angle-formula.svg)
  
Here, ɑ is the solar elevation angle, δ is the declination angle, ɸ is the latitude of your location, and h is the solar hour angle.

Therefore, we require three variables (latitude, declination, hour angle) to calculate the elevation of the sun.

Final step, measuring the **azimuth angle**.

* The **solar azimuth** angle defines the horizontal coordinates of the sun relative to the observer. It is defined as the angular distance between the projection of the sun on the imaginary horizontal plane on which the observer is standing and the reference direction. In solar technology, the reference direction is north.

### Solar azimuth angle formula

The azimuth angle is calculated using the following formula:

  ![Azimuth angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/azimuth-angle-formula.svg)

Here, A is the azimuth angle, δ is the declination angle, φ is the latitude, h is the hour angle, and ɑ is the solar elevation angle.

The hour angle (h) can be positive (after solar noon) and negative (before the solar noon). When h is positive, we have to subtract A from 360°.

  ![Azimuth angle formula 2](https://solarsena.wpengine.com/wp-content/uploads/2021/04/azimuth-angle-example-noon.svg)

### References
For more information, you can check the links listed below:
* Solar hour angle: https://solarsena.com/solar-hour-angle-calculator-formula/
* Solar declination angle: https://solarsena.wpengine.com/solar-declination-angle-calculator/
* Solar elevation angle: https://solarsena.wpengine.com/solar-elevation-angle-altitude/
* Solar azimuth angle: https://solarsena.com/solar-azimuth-angle-calculator-solar-panels/

## Set up

* Setting up the objects.

 ![Setup objects](https://github.com/TeoLeoGit/Sun-simulator/blob/main/Documents/Setup%20objects.PNG)
 
* Setting up the directions: The z-axis direction will point North, therefore the opposite direction will be South. The x-axis direction will point East, therefore the opposite direction will be West. And the y-axis will be the altitude.

 ![Setup directions](https://github.com/TeoLeoGit/Sun-simulator/blob/main/Documents/Setup%20directions.png)
 
* Setting up the UI: Including input fields for datetime and coordinate, a button to execute the calculating function and show the result on screen. A component named **InputManager** is attached to the UICanvas for validating inputs from the user.

 ![Setup UIs](https://github.com/TeoLeoGit/Sun-simulator/blob/main/Documents/Setup%20UI.png)
 
### Implementing the formulas

The formulas to calculate all the needed variables for measuring the altitude and position of the Sun were implemented in the class named **Polar** as below:

```csharp
    float CalculateSolarHourAngle(int hour, int minute) //Formula to calculate the hour angle
    {
        float localSolarTime = hour * 60 + minute;
        float solarHourAngle = 15 * (localSolarTime / 60 - 12);
        return solarHourAngle;
    }

    float CalculateDeclinationAngle(int dayOfYear) //Formula to calculate the declination angle
    {
        int daySinceJan1st = dayOfYear - 1;
        float declinationAngle = -23.44f * Mathf.Cos(360f / 365f * (daySinceJan1st + 10) * Mathf.PI / 180f);
        return declinationAngle;
    }

    float CalculateElevationAngle(float declinationAngle, float latitude, float solarHourAngle) //Formula to calculate the Elevation angle
    {
        //Convert from degree to radian
        declinationAngle = declinationAngle * Mathf.PI / 180f;
        latitude = latitude * Mathf.PI / 180f;
        solarHourAngle = solarHourAngle * Mathf.PI / 180f;

        float sinOfElevationAngle = Mathf.Sin(latitude) * Mathf.Sin(declinationAngle) + Mathf.Cos(latitude) * Mathf.Cos(declinationAngle) * Mathf.Cos(solarHourAngle);
        return Mathf.Asin(sinOfElevationAngle) * (180f / Mathf.PI);
    }

    float CalculateSolarAzimuthAngle(float declinationAngle, float latitude, float hourAngle, float elevationAngle) //Formula to calculate the azimuth angle
    {
        //Convert from degree to radian
        declinationAngle = declinationAngle * Mathf.PI / 180f;
        latitude = latitude * Mathf.PI / 180f;
        hourAngle = hourAngle * Mathf.PI / 180f;
        elevationAngle = elevationAngle * Mathf.PI / 180f;

        float cosOfAzimuthAngle = (Mathf.Sin(declinationAngle) * Mathf.Cos(latitude) - Mathf.Cos(declinationAngle) * Mathf.Sin(latitude) * Mathf.Cos(hourAngle)) / Mathf.Cos(elevationAngle);
        if (cosOfAzimuthAngle < -1 || cosOfAzimuthAngle > 1) cosOfAzimuthAngle = Mathf.Round(cosOfAzimuthAngle); //The fomula may return odd value like -1.00001/1.00001 
        float azimuthAngle = Mathf.Acos(cosOfAzimuthAngle) * (180f / Mathf.PI);
        if (hourAngle > 0f) azimuthAngle = 360f - azimuthAngle;
        return azimuthAngle;
    }
```
The function that takes the inputs from the user and measures the altitude and position of the Sun (based on a simulated horizon line length, in this project I settled the length to 20) was implemented in the same class.

```csharp
    public void SimulatePosition(int dayOfYear, int hour, int minute, float longitude, float latitude, out float elevationAngle, out float azimuthAngle, out Vector3 polarPosition)
    {
        float solarHourAngle = CalculateSolarHourAngle(hour, minute);
        float declinationAngle = CalculateDeclinationAngle(dayOfYear);
        elevationAngle = CalculateElevationAngle(declinationAngle, latitude, solarHourAngle);
        azimuthAngle = CalculateSolarAzimuthAngle(declinationAngle, latitude, solarHourAngle, elevationAngle);
        
        //Find the coordinates on XZ, center is (0, 0)
        float x = horizonLineLength * Mathf.Sin(azimuthAngle * Mathf.PI / 180f);
        float z = horizonLineLength * Mathf.Cos(azimuthAngle * Mathf.PI / 180f);

        //Find the height (y)
        float y = horizonLineLength * Mathf.Tan(elevationAngle * Mathf.PI / 180f);

        this.transform.position = new Vector3(x, y, z);
        polarPosition = transform.position;
        lightSource.LookAt(Vector3.zero);

    }
```

The formulas didn't need longitude as a variable, I will put more research on this in the near future (if I get hired).

After measuring all the angles, we can calculate the altitude and position of the Sun with a simulated horizon line based on the geometry study of azimuth angle and elevation angle.

  ![Position of the Sun](https://keisan.casio.com/keisan/lib/real/system/2006/1224682277/anglefigure.gif)

```csharp
  //Find the coordinates on XZ, center is (0, 0)
  float x = horizonLineLength * Mathf.Sin(azimuthAngle * Mathf.PI / 180f);
  float z = horizonLineLength * Mathf.Cos(azimuthAngle * Mathf.PI / 180f);

  //Find the height (y)
  float y = horizonLineLength * Mathf.Tan(elevationAngle * Mathf.PI / 180f);
```

Assume that the lightning direction will be the direction from the solar to the pillar. We just need the light source to look at the coordinate (0, 0) (where the pillar at) and then we can simulate the shadow direction and length of the pillar.

```csharp
  lightSource.LookAt(Vector3.zero);
```

## Result
Here are some test results I conducted with the same date and coordinate inputs and different times in the day.

* At 6:30 the Sun rises in the East.

  ![Position of the Sun](https://github.com/TeoLeoGit/Sun-simulator/blob/main/Documents/Sun%206h30.PNG)

* At 12:00 the Sun reaches the highest altitude.

  ![Position of the Sun](https://github.com/TeoLeoGit/Sun-simulator/blob/main/Documents/Sun%2012h.PNG)

* At 17:00 the Sun sets in the West.

  ![Position of the Sun](https://github.com/TeoLeoGit/Sun-simulator/blob/main/Documents/Sun%2017h.PNG)
