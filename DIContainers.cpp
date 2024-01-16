#include <iostream>
#include <memory>
#include <boost/di.hpp>

using namespace std;
namespace di = boost::di;

// Define interfaces
class IEngine {
public:
    virtual void start() = 0;
};

class ITransmission {
public:
    virtual void shift() = 0;
};

class IStartupMotor {
public:
    virtual void start_motor() = 0;
};

class IFuelPump {
public:
    virtual void pump_fuel() = 0;
};

class IPrinter {
public:
    virtual void print_message(const string& message) = 0;
};


class ConsolePrinter : public IPrinter {
public:
    void print_message(const string& message) override {
        cout << message << endl;
    }
};

class Engine : public IEngine {
public:
    Engine(shared_ptr<IStartupMotor> startup_motor,
           shared_ptr<IFuelPump> fuel_pump,
           shared_ptr<IPrinter> printer)
        : startup_motor(startup_motor), fuel_pump(fuel_pump), printer(printer) {}

    void start() override {
        startup_motor->start_motor();
        fuel_pump->pump_fuel();
        printer->print_message("Engine started.");
    }

private:
    shared_ptr<IStartupMotor> startup_motor;
    shared_ptr<IFuelPump> fuel_pump;
    shared_ptr<IPrinter> printer;
};

class Transmission : public ITransmission {
public:
    explicit Transmission(shared_ptr<IPrinter> printer) : printer(printer) {}

    void shift() override {
        printer->print_message("Transmission shifted.");
    }

private:
    shared_ptr<IPrinter> printer;
};

class StartupMotor : public IStartupMotor {
public:
    explicit StartupMotor(shared_ptr<IPrinter> printer) : printer(printer) {}

    void start_motor() override {
        printer->print_message("Startup motor started.");
    }

private:
    shared_ptr<IPrinter> printer;
};

class FuelPump : public IFuelPump {
public:
    explicit FuelPump(shared_ptr<IPrinter> printer) : printer(printer) {}

    void pump_fuel() override {
        printer->print_message("Fuel pump activated.");
    }

private:
    shared_ptr<IPrinter> printer;
};

class Car {
public:
    Car(shared_ptr<IEngine> engine,
        shared_ptr<ITransmission> transmission,
        shared_ptr<IPrinter> printer)
        : engine(engine), transmission(transmission), printer(printer) {}

    void drive() {
        engine->start();
        transmission->shift();
        printer->print_message("Car is now driving.");
    }

private:
    shared_ptr<IEngine> engine;
    shared_ptr<ITransmission> transmission;
    shared_ptr<IPrinter> printer;
};

int main() {
    auto injector = di::make_injector(di::bind<IStartupMotor>().to<StartupMotor>(),
                                      di::bind<IFuelPump>().to<FuelPump>(),
                                      di::bind<IEngine>().to<Engine>(),
                                      di::bind<ITransmission>().to<Transmission>(),
                                      di::bind<IPrinter>().to<ConsolePrinter>());

    auto my_car = injector.create<Car>();
    my_car.drive();

    return 0;
}
