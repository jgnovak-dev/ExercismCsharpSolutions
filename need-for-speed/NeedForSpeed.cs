class RemoteControlCar {
    private const int NitroSpeed = 50;
    private const int NitroDrain = 4;
    
    public int Speed { get; }
    public int BatteryDrain { get; }

    private int _battery;
    private int _distance;

    public RemoteControlCar(int speed, int batteryDrain) {
        _battery = 100;
        _distance = 0;

        Speed = speed;
        BatteryDrain = batteryDrain;
    }
    
    public bool BatteryDrained() {
        return _battery - BatteryDrain < 0;
    }

    public int DistanceDriven() {
        return _distance;
    }

    public void Drive() {
        if (BatteryDrained()) {
            return;
        }

        _distance += Speed;
        _battery -= BatteryDrain;
    }

    public static RemoteControlCar Nitro() {
        return new RemoteControlCar(NitroSpeed, NitroDrain);
    }
}

class RaceTrack {
    private readonly int _distance;

    public RaceTrack(int distance) {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car) {
        var drives = 100 / car.BatteryDrain;
        var possibleDistance = drives * car.Speed;
        return possibleDistance >= _distance;
    }
}
