#include <bits/stdc++.h>
using namespace std;


class IObserver {
public:
    virtual void update(Thread* thread, int threadId) = 0;
};

class Thread {
    int id;
    string state;
    string priority;
    string culture;
    vector<IObserver*> observers;

    void notifyTheObservers() {
        for (auto observer : observers) {
            observer->update(this, id);
        }
    }

public:
    void setId(int threadId) {
        id = threadId;
    }

    void start() {
        state = "Starting";
        notifyTheObservers();
    }

    void abort() {
        state = "aborting";
        notifyTheObservers();
    }

    void sleep() {
        state = "sleeping";
        notifyTheObservers();
    }

    void wait() {
        state = "wait";
        notifyTheObservers();
    }

    void suspended() {
        state = "suspended";
        notifyTheObservers();
    }

    string getState() const {
        return state;
    }

    void subscribe(IObserver* observer) {
        observers.push_back(observer);
    }

    void unsubscribe(IObserver* observer) {
        observers.erase(remove(observers.begin(), observers.end(), observer), observers.end());
    }

    int getId() const {
        return id;
    }
};

class ConcreteObserver : public IObserver {
public:
    void update(Thread* thread, int threadId) override {
        cout << "Thread " << threadId << " has been updated. New state: " << thread->getState() << endl;
    }
};

