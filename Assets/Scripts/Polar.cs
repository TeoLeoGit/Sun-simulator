using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polar : MonoBehaviour
{
    //Formulas
    [SerializeField] float horizonLineLength;
    [SerializeField] Transform lightSource;

    public float SimulateHorizonLineLength
    {
        get
        {
            return horizonLineLength;
        }
    }
    //Measuring unit: degree
    /*float CalculateFractionalYear(int dayOfYear, int hours)
    {
        float fractionalYear = (2 * Mathf.PI / 365) * (dayOfYear - 1 * (hours - 12) / 24);
        return fractionalYear;
    }*/
    
    float CalculateSolarHourAngle(int hour, int minute)
    {
        float localSolarTime = hour * 60 + minute;
        float solarHourAngle = 15 * (localSolarTime / 60 - 12);
        return solarHourAngle;
    }

    float CalculateDeclinationAngle(int dayOfYear)
    {
        int daySinceJan1st = dayOfYear - 1;
        float declinationAngle = -23.44f * Mathf.Cos(360f / 365f * (daySinceJan1st + 10) * Mathf.PI / 180f);
        return declinationAngle;
    }

    float CalculateElevationAngle(float declinationAngle, float latitude, float solarHourAngle)
    {
        //Convert from degree to radian
        declinationAngle = declinationAngle * Mathf.PI / 180f;
        latitude = latitude * Mathf.PI / 180f;
        solarHourAngle = solarHourAngle * Mathf.PI / 180f;

        float sinOfElevationAngle = Mathf.Sin(latitude) * Mathf.Sin(declinationAngle) + Mathf.Cos(latitude) * Mathf.Cos(declinationAngle) * Mathf.Cos(solarHourAngle);
        return Mathf.Asin(sinOfElevationAngle) * (180f / Mathf.PI);
    }

    float CalculateSolarAzimuthAngle(float declinationAngle, float latitude, float hourAngle, float elevationAngle)
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

    private void Start()
    {
        SimulatePosition(DateTime.Now.DayOfYear, 6, 0, 139.7447f, 35.6544f, out float elevationAngle, out float azimuthAngle, out Vector3 polarPosition);
    }

    public void SimulatePosition(int dayOfYear, int hour, int minute, float longitude, float latitude, out float elevationAngle, out float azimuthAngle, out Vector3 polarPosition)
    {
        float solarHourAngle = CalculateSolarHourAngle(hour, minute);
        float declinationAngle = CalculateDeclinationAngle(dayOfYear);
        elevationAngle = CalculateElevationAngle(declinationAngle, latitude, solarHourAngle);
        azimuthAngle = CalculateSolarAzimuthAngle(declinationAngle, latitude, solarHourAngle, elevationAngle);

        /*print("Elevation angle: " + elevationAngle + " - Decline angle: " + declinationAngle);
        print("Azimuth: " + azimuthAngle + " - Solar hour angle: " + solarHourAngle);*/

        //Find the coordinates on XZ, center is (0, 0)
        float x = horizonLineLength * Mathf.Sin(azimuthAngle * Mathf.PI / 180f);
        float z = horizonLineLength * Mathf.Cos(azimuthAngle * Mathf.PI / 180f);

        //Find the height (y)
        float y = horizonLineLength * Mathf.Tan(elevationAngle * Mathf.PI / 180f);

        this.transform.position = new Vector3(x, y, z);
        polarPosition = transform.position;
        lightSource.LookAt(Vector3.zero);

    }
}
