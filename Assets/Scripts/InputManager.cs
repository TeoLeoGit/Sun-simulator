using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] Polar solar;

    [SerializeField] InputField longitudeInput;
    [SerializeField] InputField latitudeInput;
    [SerializeField] InputField dayInput;
    [SerializeField] InputField monthInput;
    [SerializeField] InputField yearInput;
    [SerializeField] InputField hourInput;
    [SerializeField] InputField minuteInput;
    [SerializeField] Text resultTxt;

    [SerializeField] Button excBtn;

    private void Start()
    {
        excBtn.onClick.AddListener(() =>
        {
            resultTxt.text = "";
            string dateInput = monthInput.text + "/" + dayInput.text + "/" + yearInput.text;
            DateTime validDate;
            float validLongitude, validLatitude;
            int validHour, validMinute;
            if (DateTime.TryParse(dateInput, out validDate))
            {
                if (float.TryParse(longitudeInput.text, out validLongitude) && float.TryParse(latitudeInput.text, out validLatitude))
                {
                    if ( -180f <= validLongitude && validLongitude <= 180f && validLatitude >= -90f && validLatitude <= 90f)
                    {
                        if (int.TryParse(hourInput.text, out validHour) && int.TryParse(minuteInput.text, out validMinute))
                        {
                            if (validHour >= 0 && validHour <= 24 && validMinute >= 0 && validMinute <= 59)
                            {
                                solar.SimulatePosition(validDate.DayOfYear, validHour, validMinute, validLongitude, validLatitude, out float elevationAngle, out float azimuthAngle, out Vector3 polarPosition);
                                resultTxt.text = "Elevation angle: " + elevationAngle.ToString("0.0000") + "\n" + "Azimuth angle: " + azimuthAngle.ToString("0.0000") 
                                        + "\n" + "Solar coordinate: " + "( " + polarPosition.x + ", " + polarPosition.z + " )" + "\nSolar altitude: " + polarPosition.y + "\nSimulated distance (to the Sun): " + solar.SimulateDistance;
                            }
                            else
                                resultTxt.text += "Invalid time in day!\n";
                        }
                        else
                        {
                            resultTxt.text += "Invalid time in day!\n";
                        }
                    }
                    else
                    {
                        resultTxt.text += "Invalid coordinate!\n";
                    }
                }
                else
                {
                    resultTxt.text += "Invalid coordinate!\n";
                }
            } 
            else
            {
                resultTxt.text += "Invalid datetime!\n";
            }
        });
    }
}
