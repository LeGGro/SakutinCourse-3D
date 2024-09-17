using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;


public class VirtualClock : MonoBehaviour
{
    [SerializeField] private string _dateTimeFormat = "hh:mm:ss tt dd/MM/yy";
    [SerializeField] private TMP_Text _clock;
    [SerializeField] private TimeType _timeType = TimeType.Real;
    [SerializeField] private float _realRefreshTime = 1f;
    [SerializeField] private float _fakeTimeSecondsDuration = 0.5f;
    [Header("Format: hh:mm:ss dd/MM/yy")]
    [Space]
    [SerializeField] private string _fakeTimeStar;

    private DateTime _parsedFakeTimeStart;
    private DateTime _currentFakeTime;
    private WaitForSeconds _waitForRealRefresh;
    private WaitForSeconds _waitForFakeMinutes;
    private CultureInfo _cultureInfo = new CultureInfo("en-US");


    private void Start()
    {
        if (_timeType == TimeType.Fake)
            if (_fakeTimeStar != string.Empty && DateTime.TryParse(_fakeTimeStar, out DateTime date))
                _parsedFakeTimeStart = date;
            else
                Debug.LogWarning("Non parseble fakeDate");

        _waitForFakeMinutes = new WaitForSeconds(_fakeTimeSecondsDuration * 60f);
        _waitForRealRefresh = new WaitForSeconds(_realRefreshTime);
        _currentFakeTime = _parsedFakeTimeStart;
        _clock.text = _currentFakeTime.ToString(_dateTimeFormat, _cultureInfo);

        StartCoroutine(_timeType == TimeType.Real ? RealTiming() : FakeTiming());
    }

    private IEnumerator RealTiming()
    {
        while (true)
        {
            yield return _waitForRealRefresh;
            _clock.text = DateTime.Now.ToString(_dateTimeFormat, _cultureInfo);
        }
    }

    private IEnumerator FakeTiming()
    {
        while (true)
        {
            _currentFakeTime = _currentFakeTime.AddSeconds(_fakeTimeSecondsDuration);
            yield return _waitForFakeMinutes;
            _clock.text = _currentFakeTime.ToString(_dateTimeFormat, _cultureInfo);
        }
    }

}
public enum TimeType
{
    Real,
    Fake
}
