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

    [SerializeField] Button excBtn;

    private void Start()
    {
        excBtn.onClick.AddListener(() =>
        {
            string dateInput = monthInput.text + "/" + dayInput.text + "/" +yearInput.text;
            print("Check intput: " + dateInput);
            DateTime validDate;
            float validLongitude, validLatitude;
            int validHour, validMinute;
            if (DateTime.TryParse(dateInput, out validDate) && float.TryParse(longitudeInput.text, out validLongitude)
                && float.TryParse(latitudeInput.text, out validLatitude) && int.TryParse(hourInput.text, out validHour)
                && int.TryParse(minuteInput.text, out validMinute))
            {
                solar.SimulatePosition(validDate.DayOfYear, validHour, validMinute, validLongitude, validLatitude);
            }
            else
            {
                print("Input error!");
            }
            
        });
    }
}
