using System;

class RemoteControlCar {

    private int _distanceDriven;
    private int _batteryLevel;

    public RemoteControlCar() {
        _distanceDriven = 0;
        _batteryLevel = 100;
    }

    public static RemoteControlCar Buy() => new();

    public string DistanceDisplay() {
        return $"Driven {_distanceDriven} meters";
    }

    public string BatteryDisplay() {
        return _batteryLevel == 0 ? "Battery empty" : $"Battery at {_batteryLevel}%";
    }

    public void Drive() {

        if (_batteryLevel <= 0) {
            return;
        }

        _batteryLevel--;
        _distanceDriven += 20;

    }
}
