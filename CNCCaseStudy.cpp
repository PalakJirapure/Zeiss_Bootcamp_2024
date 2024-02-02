#include <iostream>
using namespace std;


class Monitor {
public:
    virtual void monitor() const = 0;
};


class TemperatureMonitor : public Monitor {
public:
    void monitor() const override {
        cout << "Temperature Monitor: Checking temperature..." << endl;

    }
};


class DimensionMonitor : public Monitor {
public:
    void monitor() const override {
        cout << "Dimension Monitor: Checking dimension variation..." << endl;
       
    }
};


class DurationMonitor : public Monitor {
public:
    void monitor() const override {
        cout << "Duration Monitor: Checking continuous operation duration..." << endl;

    }
};


class SelfTestMonitor : public Monitor {
public:
    void monitor() const override {
        cout << "Self-Test Monitor: Checking self-test status..." << endl;
        
    }
};


class CNCMachine {
private:
    float temperature;
    float dimensionVariation;
    int continuousOperationDuration;
    int selfTestStatus;

public:
    CNCMachine(float temp, float variation, int duration, int status)
        : temperature(temp), dimensionVariation(variation), continuousOperationDuration(duration), selfTestStatus(status) {}

    void monitor(const Monitor& monitor) const {
        monitor.monitor();
    }
};


class AlertService {
public:
    void alert(const Monitor& monitor) const {
        cout << "Alert Service: ";
        monitor.monitor();
       
    }
};

int main() {
    CNCMachine cncMachine(36.0, 0.06, 380, 0x01);

    TemperatureMonitor temperatureMonitor;
    cncMachine.monitor(temperatureMonitor);

    DimensionMonitor dimensionMonitor;
    cncMachine.monitor(dimensionMonitor);

    DurationMonitor durationMonitor;
    cncMachine.monitor(durationMonitor);

    SelfTestMonitor selfTestMonitor;
    cncMachine.monitor(selfTestMonitor);

    return 0;
}
